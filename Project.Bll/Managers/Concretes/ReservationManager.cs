using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class ReservationManager : BaseManager<ReservationDto, Reservation>, IReservationManager
    {
        private readonly IReservationRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IExtraServiceManager _extraServiceManager; // Yeni: Ekstra hizmetleri almak için
        private readonly IAppUserManager _appUserManager;                   // Yeni: Kullanıcı manager
        private readonly IAppUserProfileManager _appUserProfileManager;    // Yeni: Kullanıcı profil manager
        private readonly IRoomManager _roomManager;       // Yeni: Oda manager
        private readonly IReservationExtraServiceManager _reservationExtraServiceManager;
        private readonly IPaymentManager _paymentManager;

        public ReservationManager(IReservationRepository repository, IRoomRepository roomRepository, IMapper mapper, IExtraServiceManager extraServiceManager, IAppUserManager appUserManager, IAppUserProfileManager appUserProfileManager, IRoomManager roomManager, IReservationExtraServiceManager reservationExtraServiceManager, IPaymentManager paymentManager) : base(repository, mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _extraServiceManager = extraServiceManager;
            _appUserManager = appUserManager;
            _appUserProfileManager = appUserProfileManager;
            _roomManager = roomManager;
            _reservationExtraServiceManager = reservationExtraServiceManager;
            _paymentManager = paymentManager;
        }

        /// <summary>
        /// Belirtilen rezervasyonu iptal eder.
        /// Rezervasyonun statüsü "Deleted" yapılır ve durumu "Canceled" olarak güncellenir.
        /// </summary>
        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            // Rezervasyonu veritabanından alıyoruz
            Reservation reservation = await _repository.GetByIdAsync(reservationId);

            if (reservation != null)
            {
                // Rezervasyonun durumunu "Silinmiş" olarak güncelliyoruz
                reservation.Status = DataStatus.Deleted;
                reservation.DeletedDate = DateTime.Now;
                reservation.ReservationStatus = ReservationStatus.Canceled;

                // Mevcut entity'yi yeni haline göre güncelliyoruz
                Reservation newEntity = _mapper.Map<Reservation>(reservation);
                await _repository.UpdateAsync(reservation, newEntity);

                return true;
            }

            // Rezervasyon bulunamazsa false döner
            return false;
        }

        /// <summary>
        /// Belirtilen tarihler arasında, ilgili odanın müsait olup olmadığını kontrol eder.
        /// </summary>
        /// <returns>Eğer çakışan bir rezervasyon yoksa true, varsa false döner.</returns>
        public bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate)
        {
            return !_repository.Where(r =>
                r.RoomId == roomId &&
                r.DeletedDate == null && // Sadece aktif rezervasyonlar
                (
                    startDate < r.EndDate && endDate > r.StartDate // Tarih aralığı çakışma kontrolü
                )).Any();
        }

        /// <summary>
        /// Yeni bir rezervasyon oluşturur. Önce oda uygunluğu kontrol edilir, sonra rezervasyon kaydedilir.
        /// Eğer rezervasyon tarihi bugünü kapsıyorsa, ilgili odanın durumu "Occupied" yapılır.
        /// </summary>
        /// <param name="dto">Oluşturulacak rezervasyon bilgilerini taşıyan DTO</param>
        /// <returns>Başarı mesajı ya da oda doluluğu uyarısı</returns>
        public async Task<string> CreateReservation(ReservationDto dto)
        {
            // Oda doluluğu kontrolü
            if (!CheckAvailability(dto.RoomId, dto.StartDate, dto.EndDate))
            {
                return "Bu tarihler arasında oda dolu.";
            }

            // Toplam fiyat hesaplanıyor
            dto.TotalPrice = CalculatePrice(dto);

            // Rezervasyon veritabanına ekleniyor
            await CreateAsync(dto);

            // Eğer bugünün tarihi rezervasyon aralığında ise, oda durumu dolu (Occupied) yapılır
            if (DateTime.Today >= dto.StartDate && DateTime.Today < dto.EndDate)
            {
                Room room = await _roomRepository.GetByIdAsync(dto.RoomId);
                room.RoomStatus = RoomStatus.Occupied;
                await _roomRepository.UpdateAsync(room, room);
            }

            return "Rezervasyon başarıyla oluşturuldu.";
        }

        /// <summary>
        /// Belirtilen kullanıcıya ait tüm rezervasyonları getirir.
        /// Dönen DTO'da oda numarası, fiyat, tarih bilgileri ve rezervasyon durumu yer alır.
        /// </summary>
        /// <param name="userId">Kullanıcının ID'si</param>
        /// <returns>Kullanıcının rezervasyonlarını içeren DTO listesi</returns>
        public async Task<List<ReservationDto>> GetReservationsByUserIdAsync(int userId)
        {
            // Veritabanından AppUserId ile rezervasyonlar çekilir
            List<Reservation> reservations = await _repository.Where(r => r.AppUserId == userId).ToListAsync();

            // DTO listesine dönüştürülür
            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                RoomNumber = r.Room.RoomNumber,              // Oda numarası
                TotalPrice = r.TotalPrice,                   // Toplam fiyat
                StartDate = r.StartDate,                     // Başlangıç tarihi
                EndDate = r.EndDate,                         // Bitiş tarihi
                ReservationStatus = r.ReservationStatus,     // Durumu (Pending, Confirmed, vb.)
                Status = r.Status                            // DataStatus bilgisi
            }).ToList();
        }

        /// <summary>
        /// Rezervasyon tarih aralığının geçerli olup olmadığını kontrol eder.
        /// Başlangıç tarihi, bitiş tarihinden büyük ya da eşitse hata mesajı döner.
        /// </summary>
        /// <param name="startDate">Rezervasyon başlangıç tarihi</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi</param>
        /// <returns>Hata mesajı veya geçerliyse null</returns>
        public string ValidateReservationDates(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                return "Bitiş tarihi, başlangıç tarihinden önce olamaz.";

            return null; // Geçerli tarih aralığı
        }

        /// <summary>
        /// Rezervasyon için toplam fiyat hesaplamasını yapar.
        /// Paket, erken rezervasyon indirimi ve ekstra hizmetler dahil edilir.
        /// </summary>
        /// <param name="dto">Hesaplama yapılacak rezervasyon DTO'su</param>
        /// <returns>Toplam hesaplanan fiyat</returns>
        private decimal CalculatePrice(ReservationDto dto)
        {
            // Oda bilgisi alınıyor
            Room room = _roomRepository.GetByIdAsync(dto.RoomId).Result;

            // Kaç gece kalınacağı hesaplanıyor
            int nights = (dto.EndDate - dto.StartDate).Days;

            // Oda fiyatı × gece sayısı
            decimal basePrice = room.PricePerNight * nights;

            // Paket çarpanı uygulanıyor
            if (dto.PackageId.HasValue)
            {
                basePrice *= dto.PackageId == 1 ? 1.2m : 1.5m;
            }

            // Erken rezervasyon indirimi uygulanıyor
            int daysBefore = (dto.StartDate - DateTime.Today).Days;
            if (daysBefore >= 90)
            {
                basePrice *= 0.77m; // %23 indirim
            }
            else if (daysBefore >= 30)
            {
                basePrice *= dto.PackageId == 2 ? 0.82m : 0.84m; // %18 / %16 indirim
            }

            // Ekstra hizmet ücretleri toplanıyor
            decimal extraServiceTotal = 0m;
            if (dto.ExtraServices != null && dto.ExtraServices.Any())
            {
                foreach (ReservationExtraServiceDto extra in dto.ExtraServices)
                {
                    ExtraServiceDto extraService = _extraServiceManager.GetByIdAsync(extra.ExtraServiceId).Result;
                    if (extraService != null)
                    {
                        extraServiceTotal += extraService.Price;
                    }
                }
            }

            // Ekstra hizmetler gece sayısıyla çarpılıyor
            extraServiceTotal *= nights;

            // Toplam fiyat döndürülüyor
            return basePrice + extraServiceTotal;
        }

        /// <summary>
        /// Belirtilen kullanıcıya ait en son oluşturulan rezervasyonu getirir.
        /// </summary>
        /// <param name="userId">Kullanıcının ID'si</param>
        /// <returns>En son oluşturulmuş rezervasyon DTO'su</returns>
        public async Task<ReservationDto> GetLatestReservationByUserId(int userId)
        {
            Reservation? latestReservation = await _repository
                .Where(r => r.AppUserId == userId)
                .OrderByDescending(r => r.CreatedDate)
                .FirstOrDefaultAsync();

            return _mapper.Map<ReservationDto>(latestReservation);
        }

        /// <summary>
        /// Güncellenmek istenen rezervasyon için yeni tarih ve oda bilgisine göre çakışma olup olmadığını kontrol eder.
        /// Aynı odada, başka bir rezervasyonla tarih çakışması varsa false döner.
        /// </summary>
        /// <param name="reservationId">Güncellenmek istenen rezervasyonun ID'si</param>
        /// <param name="roomId">Yeni seçilen oda ID'si</param>
        /// <param name="newStartDate">Yeni başlangıç tarihi</param>
        /// <param name="newEndDate">Yeni bitiş tarihi</param>
        /// <returns>Müsaitlik varsa true, yoksa false</returns>
        public bool CheckAvailabilityForUpdate(int reservationId, int roomId, DateTime newStartDate, DateTime newEndDate)
        {
            return !_repository.Where(r =>
                r.RoomId == roomId &&              // Aynı odada
                r.Id != reservationId &&           // Aynı rezervasyon değil
                (
                    (newStartDate >= r.StartDate && newStartDate < r.EndDate) ||   // Başlangıç tarihi çakışıyor
                    (newEndDate > r.StartDate && newEndDate <= r.EndDate)          // Bitiş tarihi çakışıyor
                ))
                .Any();
        }

        /// <summary>
        /// Güncellenmiş rezervasyon fiyatını hesaplar.
        /// Paket tipi ve gece sayısına göre fiyat hesaplanır. İndirim veya ekstra servis dahil değildir.
        /// </summary>
        /// <param name="roomId">Oda ID'si</param>
        /// <param name="startDate">Yeni rezervasyon başlangıç tarihi</param>
        /// <param name="endDate">Yeni rezervasyon bitiş tarihi</param>
        /// <param name="packageId">Seçilen paket ID'si</param>
        /// <returns>Hesaplanan yeni toplam fiyat</returns>
        public decimal CalculateUpdatedPrice(int roomId, DateTime startDate, DateTime endDate, int? packageId)
        {
            Room room = _roomRepository.GetByIdAsync(roomId).Result;

            if (room == null)
            {
                throw new Exception($"Belirtilen RoomId ({roomId}) için oda bulunamadı.");
            }

            int nights = (endDate - startDate).Days;
            decimal basePrice = room.PricePerNight * nights;

            // Paket çarpanı uygulanıyor
            if (packageId.HasValue)
            {
                basePrice *= packageId == 1 ? 1.2m : 1.5m;
            }

            return basePrice;
        }

        /// <summary>
        /// Rezervasyon bilgilerini günceller.
        /// Tarih ve oda uygunluğu kontrolü yapılır, ardından rezervasyon bilgileri güncellenir.
        /// </summary>
        /// <param name="dto">Güncellenmiş rezervasyon bilgilerini içeren DTO</param>
        /// <returns>Güncelleme başarılıysa true, aksi halde false</returns>
        public async Task<bool> UpdateReservationAsync(ReservationDto dto)
        {
            Reservation existingReservation = await _repository.GetByIdAsync(dto.Id);
            if (existingReservation == null)
                return false;

            // Yeni tarihler ve oda çakışma yapıyor mu kontrolü
            bool isAvailable = CheckAvailabilityForUpdate(dto.Id, dto.RoomId, dto.StartDate, dto.EndDate);
            if (!isAvailable)
                return false;

            // Yeni fiyat hesaplanıyor
            dto.TotalPrice = CalculateUpdatedPrice(dto.RoomId, dto.StartDate, dto.EndDate, dto.PackageId);

            // Mevcut rezervasyon güncelleniyor
            existingReservation.StartDate = dto.StartDate;
            existingReservation.EndDate = dto.EndDate;
            existingReservation.RoomId = dto.RoomId;
            existingReservation.PackageId = dto.PackageId;
            existingReservation.TotalPrice = dto.TotalPrice;
            existingReservation.Status = DataStatus.Updated;
            existingReservation.ModifiedDate = DateTime.Now;
            existingReservation.DeletedDate = null;

            Reservation updatedEntity = _mapper.Map<Reservation>(existingReservation);
            await _repository.UpdateAsync(existingReservation, updatedEntity);

            return true;
        }

        /// <summary>
        /// Sistemdeki toplam rezervasyon sayısını döner.
        /// </summary>
        public async Task<int> GetTotalReservationCountAsync()
        {
            return await CountAsync();
        }

        /// <summary>
        /// Son 7 gün içerisinde başlayan rezervasyonların sayısını döner.
        /// </summary>
        public async Task<int> GetLast7DaysReservationCountAsync()
        {
            DateTime startDate = DateTime.Today.AddDays(-7);
            return await CountAsync(r => r.StartDate >= startDate);
        }

        /// <summary>
        /// Ödeme bekleyen (PendingPayment durumunda olan) rezervasyon sayısını döner.
        /// </summary>
        public async Task<int> GetPendingReservationCountAsync()
        {
            return await CountAsync(r => r.ReservationStatus == ReservationStatus.PendingPayment);
        }

        /// <summary>
        /// İptal edilmiş bir rezervasyonu tekrar aktif hale getirir.
        /// Durumunu "PendingPayment" yaparak yeniden ödeme yapılabilir hale getirir.
        /// </summary>
        /// <param name="reservationId">Reaktif edilecek rezervasyonun ID'si</param>
        public async Task ReactivateReservationAsync(int reservationId)
        {
            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
                throw new Exception("Rezervasyon bulunamadı.");

            // Rezervasyon durumu güncelleniyor
            reservation.ReservationStatus = ReservationStatus.PendingPayment; // Ödeme bekleniyor durumu
            reservation.Status = DataStatus.Updated;                          // Güncellenmiş veri olarak işaretle
            reservation.ModifiedDate = DateTime.Now;                         // Güncelleme zamanı
            reservation.DeletedDate = null;                                  // Silinme kaldırılır (soft delete)

            await _repository.UpdateAsync(reservation, reservation);
        }

        /// <summary>
        /// Belirtilen rezervasyona ait ekstra hizmetlerin toplam fiyatını hesaplayarak mevcut fiyata ekler.
        /// </summary>
        /// <param name="reservationId">Güncellenecek rezervasyonun ID'si</param>
        /// <param name="extraServiceIds">Eklenmek istenen ekstra hizmetlerin ID'leri</param>
        public async Task UpdateReservationPriceWithExtraServices(int reservationId, List<int> extraServiceIds)
        {
            Reservation reservationEntity = await _repository.GetByIdAsync(reservationId);
            if (reservationEntity == null)
                throw new Exception("Rezervasyon bulunamadı.");

            decimal extraTotal = 0m;

            // Her ekstra hizmetin fiyatı toplanıyor
            foreach (int extraId in extraServiceIds)
            {
                ExtraServiceDto extraService = await _extraServiceManager.GetByIdAsync(extraId);
                if (extraService != null)
                {
                    extraTotal += extraService.Price;
                }
            }

            // Mevcut toplam fiyata ekleniyor
            reservationEntity.TotalPrice += extraTotal;
            reservationEntity.ModifiedDate = DateTime.Now;
            reservationEntity.Status = DataStatus.Updated;

            await _repository.UpdateAsync(reservationEntity, reservationEntity);
        }

        /// <summary>
        /// Belirtilen rezervasyonun ödeme için uygun olup olmadığını kontrol eder.
        /// Onaylanmış (Confirmed) veya iptal edilmiş (Canceled) rezervasyonlara ödeme yapılamaz.
        /// </summary>
        /// <param name="reservationId">Kontrol edilecek rezervasyonun ID'si</param>
        /// <returns>Ödeme yapılabilirse true, yapılamazsa false</returns>
        public async Task<bool> IsReservationPayableAsync(int reservationId)
        {
            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
                return false;

            return reservation.ReservationStatus != ReservationStatus.Confirmed &&
                   reservation.ReservationStatus != ReservationStatus.Canceled;
        }

        /// <summary>
        /// Rezervasyonun durumunu "Confirmed" olarak işaretler.
        /// Bu işlem ödeme yapıldıktan sonra gerçekleştirilmelidir.
        /// </summary>
        /// <param name="reservationId">Onaylanacak rezervasyonun ID'si</param>
        public async Task ConfirmReservationAsync(int reservationId)
        {
            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
                throw new Exception("Rezervasyon bulunamadı.");

            reservation.ReservationStatus = ReservationStatus.Confirmed; // Durum güncellenir
            reservation.Status = DataStatus.Updated;
            reservation.ModifiedDate = DateTime.Now;

            Reservation newEntity = _mapper.Map<Reservation>(reservation);
            await _repository.UpdateAsync(reservation, newEntity);
        }

        /// <summary>
        /// Belirtilen rezervasyon ID'sine sahip, onaylanmış (Confirmed) rezervasyonu getirir.
        /// Eğer rezervasyon bulunamazsa veya durumu "Confirmed" değilse null döner.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Onaylanmış rezervasyonun DTO'su veya null</returns>
        public async Task<ReservationDto> GetConfirmedReservationByIdAsync(int reservationId)
        {
            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            return _mapper.Map<ReservationDto>(reservation);
        }

        /// <summary>
        /// Tüm onaylanmış rezervasyonlar üzerinden toplam gelir ve aylık gelir raporlarını döner.
        /// </summary>
        /// <returns>
        /// Tuple olarak toplam gelir (TotalRevenue) ve her ay için (Yıl, Ay, Tutar) içeren liste döner.
        /// </returns>
        public async Task<(decimal TotalRevenue, List<(int Year, int Month, decimal TotalRevenue)> MonthlyReports)> GetRevenueReportsAsync()
        {
            List<ReservationDto> reservations = await GetAllAsync(); // Tüm rezervasyonlar

            // Sadece Confirmed durumunda olanlar filtrelenir
            List<ReservationDto> confirmedReservations = reservations
                .Where(r => r.ReservationStatus == ReservationStatus.Confirmed)
                .ToList();

            // Toplam gelir hesaplanır
            decimal totalRevenue = confirmedReservations.Sum(r => r.TotalPrice);

            // Aylık raporlama: Yıla ve aya göre gruplama + toplam
            var monthlyReports = confirmedReservations
                .GroupBy(r => new { r.StartDate.Year, r.StartDate.Month })
                .Select(g => (Year: g.Key.Year, Month: g.Key.Month, TotalRevenue: g.Sum(r => r.TotalPrice)))
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            return (totalRevenue, monthlyReports);
        }

        /// <summary>
        /// Sistemdeki tüm rezervasyonları getirir ve kullanıcı, kullanıcı profili, oda gibi eksik bilgileri doldurur.
        /// Controller’a eksiksiz rezervasyon verisi sunar.
        /// </summary>
        /// <returns>Detay bilgileri doldurulmuş rezervasyon DTO listesi</returns>
        public async Task<List<ReservationDto>> GetReservationReportsAsync()
        {
            List<ReservationDto> reservations = await GetAllAsync(); // BaseManager'dan DTO listesi alınır

            foreach (ReservationDto reservation in reservations)
            {
                // Kullanıcı bilgileri
                if (reservation.AppUserId.HasValue)
                {
                    AppUserDto user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                    AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                    if (user != null && userProfile != null)
                    {
                        reservation.CustomerName = $"{userProfile.FirstName} {userProfile.LastName}";
                        reservation.CustomerEmail = user.Email;
                    }
                    else
                    {
                        reservation.CustomerName = "Bilinmeyen Kullanıcı";
                        reservation.CustomerEmail = "Email Yok";
                    }
                }
                else
                {
                    reservation.CustomerName = "Anonim Kullanıcı";
                    reservation.CustomerEmail = "Email Yok";
                }

                // Oda bilgisi
                RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
                reservation.RoomNumber = room != null ? room.RoomNumber.ToString() : "Bilinmeyen Oda";
            }

            return reservations;
        }

        /// <summary>
        /// Tüm rezervasyonları getirir, eksik bilgileri tamamlar ve filtreleme uygular.
        /// İsteğe bağlı olarak müşteri adı/e-posta, ödeme durumu ve rezervasyon durumu filtreleri uygulanabilir.
        /// </summary>
        /// <param name="search">Ad veya e-posta filtre metni</param>
        /// <param name="isPaid">true: Confirmed, false: PendingPayment</param>
        /// <param name="status">Opsiyonel durum filtresi (Confirmed, Canceled vs)</param>
        /// <returns>Filtrelenmiş ve zenginleştirilmiş DTO listesi</returns>
        public async Task<List<ReservationDto>> GetFilteredReservationReportsAsync(string search, bool? isPaid, ReservationStatus? status)
        {
            List<ReservationDto> reservations = await GetAllAsync();

            // Kullanıcı + oda bilgilerini doldur
            foreach (ReservationDto reservation in reservations)
            {
                if (reservation.AppUserId.HasValue)
                {
                    AppUserDto user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                    AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                    if (user != null && userProfile != null)
                    {
                        reservation.CustomerName = $"{userProfile.FirstName} {userProfile.LastName}";
                        reservation.CustomerEmail = user.Email;
                    }
                    else
                    {
                        reservation.CustomerName = "Bilinmeyen Kullanıcı";
                        reservation.CustomerEmail = "Email Yok";
                    }
                }
                else
                {
                    reservation.CustomerName = "Anonim Kullanıcı";
                    reservation.CustomerEmail = "Email Yok";
                }

                RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
                reservation.RoomNumber = room != null ? room.RoomNumber.ToString() : "Bilinmeyen Oda";
            }

            // Arama (isim veya e-posta)
            if (!string.IsNullOrEmpty(search))
            {
                reservations = reservations
                    .Where(r =>
                        r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        r.CustomerEmail.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Ödeme durumu filtresi
            if (isPaid.HasValue)
            {
                reservations = reservations.Where(r =>
                    isPaid.Value
                        ? r.ReservationStatus == ReservationStatus.Confirmed
                        : r.ReservationStatus == ReservationStatus.PendingPayment)
                    .ToList();
            }

            // Rezervasyon durumu filtresi (ör: sadece Canceled)
            if (status.HasValue)
            {
                reservations = reservations.Where(r => r.ReservationStatus == status.Value).ToList();
            }

            return reservations;
        }

        /// <summary>
        /// Belirtilen rezervasyon bilgilerini, ekstra hizmetleri ve reaktivasyon durumunu dikkate alarak rezervasyonu günceller.
        /// - Oda değişikliği varsa eski oda boş, yeni oda dolu yapılır.
        /// - Tarih çakışması kontrol edilir.
        /// - Fiyat yeniden hesaplanır.
        /// - Ekstra hizmetler güncellenir.
        /// - Reaktivasyon isteniyorsa rezervasyon yeniden aktif edilir.
        /// </summary>
        /// <param name="dto">Güncellenecek rezervasyon bilgilerini içeren DTO</param>
        /// <param name="extraServiceIds">Yeni atanacak ekstra hizmetlerin ID listesi</param>
        /// <param name="reactivateReservation">Rezervasyon yeniden aktif edilecekse true</param>
        /// <returns>Güncelleme başarılıysa true, aksi halde hata fırlatır</returns>
        public async Task<bool> UpdateReservationWithDetailsAsync(ReservationDto dto, List<int> extraServiceIds, bool reactivateReservation)
        {
            Reservation existingReservation = await _repository.GetByIdAsync(dto.Id);
            if (existingReservation == null)
                throw new Exception("Rezervasyon bulunamadı.");

            // Oda değişikliği varsa eskiyi boş, yeniyi dolu yap
            if (existingReservation.RoomId != dto.RoomId)
            {
                await _roomManager.UpdateRoomStatusAsync(existingReservation.RoomId, RoomStatus.Empty);
                await _roomManager.UpdateRoomStatusAsync(dto.RoomId, RoomStatus.Occupied);
            }

            // Çakışma kontrolü
            bool isAvailable = CheckAvailabilityForUpdate(dto.Id, dto.RoomId, dto.StartDate, dto.EndDate);
            if (!isAvailable)
                throw new Exception("Seçtiğiniz tarihler arasında oda dolu.");

            // Yeni fiyatı hesapla
            dto.TotalPrice = CalculateUpdatedPrice(dto.RoomId, dto.StartDate, dto.EndDate, dto.PackageId);

            // Rezervasyonu güncelle
            bool updateResult = await UpdateReservationAsync(dto);
            if (!updateResult)
                throw new Exception("Rezervasyon güncellenirken bir hata oluştu.");

            // Ekstra hizmetler varsa güncelle
            if (extraServiceIds != null && extraServiceIds.Any())
            {
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(dto.Id, extraServiceIds);
            }

            // Reaktivasyon işlemi yapılacaksa
            if (reactivateReservation)
            {
                await ReactivateReservationAsync(dto.Id);
            }

            return true;
        }

        /// <summary>
        /// Belirtilen rezervasyonun ödeme durumunu ve bağlı olduğu oda durumunu verilen yeni duruma göre günceller.
        /// - Eğer yeni durum Canceled ise: rezervasyon ve ödeme silinir, oda boşaltılır.
        /// - Confirmed veya PendingPayment durumlarında: veriler güncellenir ve oda dolu yapılır.
        /// </summary>
        /// <param name="reservationId">Hedef rezervasyonun ID'si</param>
        /// <param name="newStatus">Yeni atanacak rezervasyon durumu</param>
        /// <returns>İşlem başarılıysa true döner</returns>
        public async Task<bool> UpdateReservationPaymentStatusAsync(int reservationId, ReservationStatus newStatus)
        {
            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
                throw new Exception("Rezervasyon bulunamadı.");

            List<PaymentDto> payments = await _paymentManager.GetAllAsync();
            PaymentDto? payment = payments.FirstOrDefault(p => p.ReservationId == reservationId);
            if (payment == null)
                throw new Exception("Rezervasyona ait ödeme bilgisi bulunamadı.");

            // Önceki değerleri clone'la (güncelleme karşılaştırmaları için)
            Reservation originalReservation = _mapper.Map<Reservation>(reservation);
            PaymentDto originalPayment = _mapper.Map<PaymentDto>(payment);

            if (newStatus == ReservationStatus.Canceled)
            {
                reservation.Status = DataStatus.Deleted;
                reservation.DeletedDate = DateTime.Now;
                reservation.ModifiedDate = null;

                payment.Status = DataStatus.Deleted;
                payment.DeletedDate = DateTime.Now;
                payment.ModifiedDate = null;

                await _roomManager.UpdateRoomStatusAsync(reservation.RoomId, RoomStatus.Empty);
            }
            else if (newStatus == ReservationStatus.PendingPayment || newStatus == ReservationStatus.Confirmed)
            {
                reservation.Status = DataStatus.Updated;
                reservation.ModifiedDate = DateTime.Now;
                reservation.DeletedDate = null;

                payment.Status = DataStatus.Updated;
                payment.ModifiedDate = DateTime.Now;
                payment.DeletedDate = null;

                await _roomManager.UpdateRoomStatusAsync(reservation.RoomId, RoomStatus.Occupied);
            }

            reservation.ReservationStatus = newStatus;

            Reservation updatedReservation = _mapper.Map<Reservation>(reservation);
            PaymentDto updatedPayment = _mapper.Map<PaymentDto>(payment);

            await _repository.UpdateAsync(originalReservation, updatedReservation);
            await _paymentManager.UpdateAsync(updatedPayment);

            return true;
        }

        /// <summary>
        /// Belirtilen rezervasyonun detaylarını getirir.
        /// Müşteri adı, e-posta ve oda numarası gibi ek bilgilerle birlikte döner.
        /// </summary>
        /// <param name="id">Rezervasyon ID'si</param>
        /// <returns>Detayları doldurulmuş rezervasyon DTO’su veya null</returns>
        public async Task<ReservationDto> GetDetailedReservationByIdAsync(int id)
        {
            ReservationDto reservation = await GetByIdAsync(id);
            if (reservation == null)
                return null;

            // Kullanıcı bilgileri
            if (reservation.AppUserId.HasValue)
            {
                AppUserDto user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

                if (user != null && userProfile != null)
                {
                    reservation.CustomerName = $"{userProfile.FirstName} {userProfile.LastName}";
                    reservation.CustomerEmail = user.Email;
                }
                else
                {
                    reservation.CustomerName = "Bilinmeyen Kullanıcı";
                    reservation.CustomerEmail = "Email Yok";
                }
            }
            else
            {
                reservation.CustomerName = "Anonim Kullanıcı";
                reservation.CustomerEmail = "Email Yok";
            }

            // Oda bilgisi
            RoomDto room = await _roomManager.GetByIdAsync(reservation.RoomId);
            reservation.RoomNumber = room != null
                ? room.RoomNumber.ToString()
                : "Bilinmeyen Oda";

            return reservation;
        }
    }
}