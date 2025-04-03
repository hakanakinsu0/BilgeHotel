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

        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            // Rezervasyonu veritabanından alıyoruz
            var reservation = await _repository.GetByIdAsync(reservationId);

            if (reservation != null)
            {
                // Rezervasyonun durumunu 'Deleted' olarak güncelliyoruz
                reservation.Status = DataStatus.Deleted;  // Veritabanındaki Status alanı 'Deleted' olarak güncelleniyor
                reservation.DeletedDate = DateTime.Now;
                reservation.ReservationStatus = ReservationStatus.Canceled;

                // Veritabanındaki mevcut ve yeni entity'yi karşılaştırarak güncelleme işlemini yapıyoruz
                var newEntity = _mapper.Map<Reservation>(reservation);  // DTO'yu entity'ye çeviriyoruz
                await _repository.UpdateAsync(reservation, newEntity);  // Güncelleme işlemini gerçekleştiriyoruz
                return true;
            }

            return false;
        }


        // Çakışma kontrolü
        public bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate)
        {
            return !_repository.Where(r =>
                r.RoomId == roomId &&
                r.DeletedDate == null && 
                (
                    (startDate < r.EndDate && endDate > r.StartDate) 
                )).Any();
        }

        // Yeni rezervasyon ekleme
        public async Task<string> CreateReservation(ReservationDto dto)
        {
            if (!CheckAvailability(dto.RoomId, dto.StartDate, dto.EndDate))
            {
                return "Bu tarihler arasında oda dolu.";
            }

            // Toplam fiyat hesaplaması yapılıyor.
            dto.TotalPrice = CalculatePrice(dto);

            // Rezervasyonu oluşturuyoruz.
            await CreateAsync(dto);

            // Rezervasyon oluşturulduktan sonra, eğer bugünün tarihi rezervasyonun tarih aralığında ise,
            // ilgili odanın durumunu "Occupied" (dolu) olarak güncelliyoruz.
            if (DateTime.Today >= dto.StartDate && DateTime.Today < dto.EndDate)
            {
                var room = await _roomRepository.GetByIdAsync(dto.RoomId);
                room.RoomStatus = RoomStatus.Occupied;
                await _roomRepository.UpdateAsync(room, room);
            }

            return "Rezervasyon başarıyla oluşturuldu.";
        }

        public async Task<List<ReservationDto>> GetReservationsByUserIdAsync(int userId)
        {
            // Kullanıcıya ait rezervasyonları veritabanından alıyoruz
            var reservations = await _repository.Where(r => r.AppUserId == userId).ToListAsync();

            // Rezervasyonları DTO'ya çeviriyoruz ve Status'u da alıyoruz
            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                RoomNumber = r.Room.RoomNumber,
                TotalPrice = r.TotalPrice,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                ReservationStatus = r.ReservationStatus,
                Status = r.Status  // Status bilgisini de alıyoruz
            }).ToList();
        }

        public string ValidateReservationDates(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate) return "Bitiş tarihi, başlangıç tarihinden önce olamaz.";

            return null;
        }

        // Fiyat hesaplama
        // Toplam Fiyat = (Oda fiyati * Secilen Gece Sayisi * Secilen Pake * Erken Rezervasyon) + (Secilen Extra Hizmetler Toplami * Secilen Gece Sayisi)
        private decimal CalculatePrice(ReservationDto dto)
        {
            // Oda fiyatı ve rezervasyon süresi
            var room = _roomRepository.GetByIdAsync(dto.RoomId).Result;
            int nights = (dto.EndDate - dto.StartDate).Days;
            decimal basePrice = room.PricePerNight * nights;

            // Paket çarpanı uygulanıyor (örneğin, PaketId 1: Tam Pansiyon, 2: Her Şey Dahil)
            if (dto.PackageId.HasValue)
            {
                basePrice *= dto.PackageId == 1 ? 1.2m : 1.5m;
            }

            // Erken rezervasyon indirimi
            int daysBefore = (dto.StartDate - DateTime.Today).Days;
            if (daysBefore >= 90)
            {
                basePrice *= 0.77m; // %23 indirim
            }
            else if (daysBefore >= 30)
            {
                basePrice *= dto.PackageId == 2 ? 0.82m : 0.84m; // Her Şey Dahil: %18, diğer paketler: %16 indirim
            }

            // Ekstra hizmet ücretlerini hesaplama
            decimal extraServiceTotal = 0m;
            if (dto.ExtraServices != null && dto.ExtraServices.Any())
            {
                foreach (var extra in dto.ExtraServices)
                {
                    // Extra service bilgilerini çekiyoruz.
                    var extraService = _extraServiceManager.GetByIdAsync(extra.ExtraServiceId).Result;
                    if (extraService != null)
                    {
                        extraServiceTotal += extraService.Price;
                    }
                }
            }

            extraServiceTotal *= nights;

            return basePrice + extraServiceTotal;
        }

        public async Task<ReservationDto> GetLatestReservationByUserId(int userId)
        {
            var latestReservation = await _repository
                .Where(r => r.AppUserId == userId)
                .OrderByDescending(r => r.CreatedDate)
                .FirstOrDefaultAsync();

            return _mapper.Map<ReservationDto>(latestReservation);
        }

        public bool CheckAvailabilityForUpdate(int reservationId, int roomId, DateTime newStartDate, DateTime newEndDate)
        {
            return !_repository.Where(r => r.RoomId == roomId && r.Id != reservationId &&
                ((newStartDate >= r.StartDate && newStartDate < r.EndDate) ||
                 (newEndDate > r.StartDate && newEndDate <= r.EndDate)))
                .Any();
        }

        public decimal CalculateUpdatedPrice(int roomId, DateTime startDate, DateTime endDate, int? packageId)
        {
            var room = _roomRepository.GetByIdAsync(roomId).Result;

            if (room == null)
            {
                throw new Exception($"Belirtilen RoomId ({roomId}) için oda bulunamadı."); // Hata mesajı
            }

            int nights = (endDate - startDate).Days;
            decimal basePrice = room.PricePerNight * nights;

            if (packageId.HasValue)
            {
                basePrice *= packageId == 1 ? 1.2m : 1.5m;
            }

            return basePrice;
        }


        public async Task<bool> UpdateReservationAsync(ReservationDto dto)
        {
            var existingReservation = await _repository.GetByIdAsync(dto.Id);
            if (existingReservation == null)
            {
                return false;
            }

            bool isAvailable = CheckAvailabilityForUpdate(dto.Id, dto.RoomId, dto.StartDate, dto.EndDate);
            if (!isAvailable)
            {
                return false;
            }

            dto.TotalPrice = CalculateUpdatedPrice(dto.RoomId, dto.StartDate, dto.EndDate, dto.PackageId);

            existingReservation.StartDate = dto.StartDate;
            existingReservation.EndDate = dto.EndDate;
            existingReservation.RoomId = dto.RoomId;
            existingReservation.PackageId = dto.PackageId;
            existingReservation.TotalPrice = dto.TotalPrice;
            existingReservation.Status = DataStatus.Updated;
            existingReservation.ModifiedDate = DateTime.Now;
            existingReservation.DeletedDate = null; // ❗ Güncellenen rezervasyonun `DeletedDate` alanını NULL yapıyoruz.

            var updatedEntity = _mapper.Map<Reservation>(existingReservation);
            await _repository.UpdateAsync(existingReservation, updatedEntity);

            return true;
        }


        //

        public async Task<int> GetTotalReservationCountAsync()
        {
            return await CountAsync();
        }

        public async Task<int> GetLast7DaysReservationCountAsync()
        {
            var startDate = DateTime.Today.AddDays(-7);
            return await CountAsync(r => r.StartDate >= startDate);
        }

        public async Task<int> GetPendingReservationCountAsync()
        {
            return await CountAsync(r => r.ReservationStatus == ReservationStatus.PendingPayment);
        }

        public async Task ReactivateReservationAsync(int reservationId)
        {
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new Exception("Rezervasyon bulunamadı.");
            }

            // ✅ Rezervasyonu tekrar "Ödeme Bekleniyor" statüsüne çekiyoruz
            reservation.ReservationStatus = ReservationStatus.PendingPayment;
            reservation.Status = DataStatus.Updated;
            reservation.ModifiedDate = DateTime.Now;
            reservation.DeletedDate = null;

            await _repository.UpdateAsync(reservation, reservation);
        }


        public async Task UpdateReservationPriceWithExtraServices(int reservationId, List<int> extraServiceIds)
        {
            // Rezervasyonu veritabanından alıyoruz
            var reservationEntity = await _repository.GetByIdAsync(reservationId);
            if (reservationEntity == null)
            {
                throw new Exception("Rezervasyon bulunamadı.");
            }

            decimal extraTotal = 0m;

            // Seçilen her ekstra hizmetin fiyatını topluyoruz
            foreach (var extraId in extraServiceIds)
            {
                var extraService = await _extraServiceManager.GetByIdAsync(extraId);
                if (extraService != null)
                {
                    extraTotal += extraService.Price;
                }
            }

            // Mevcut toplam fiyata ekstra hizmetlerin ücretini ekliyoruz
            reservationEntity.TotalPrice += extraTotal;
            reservationEntity.ModifiedDate = DateTime.Now;
            reservationEntity.Status = DataStatus.Updated;

            // Rezervasyonu güncelliyoruz
            await _repository.UpdateAsync(reservationEntity, reservationEntity);
        }

        /// <summary>
        /// Belirtilen rezervasyonun ödeme işlemi için uygun olup olmadığını kontrol eder.
        /// Ödeme için uygunluk, rezervasyonun bulunması ve durumunun Confirmed veya Canceled olmamasıyla belirlenir.
        /// </summary>
        /// <param name="reservationId">Kontrol edilecek rezervasyonun ID'si</param>
        /// <returns>Ödeme için uygun ise true, değilse false</returns>
        public async Task<bool> IsReservationPayableAsync(int reservationId)
        {
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                return false; // Rezervasyon bulunamadıysa ödeme işlemi yapılamaz
            }

            // Rezervasyonun ödeme için uygunluğu: Confirmed veya Canceled durumda değilse ödeme yapılabilir
            return reservation.ReservationStatus != ReservationStatus.Confirmed &&
                   reservation.ReservationStatus != ReservationStatus.Canceled;
        }

        /// <summary>
        /// Belirtilen rezervasyonu onaylı hale getirir.
        /// Rezervasyon durumunu "Confirmed" yapar, ilgili tarih ve statü alanlarını günceller.
        /// </summary>
        /// <param name="reservationId">Onaylanacak rezervasyonun ID'si</param>
        /// <returns>Asenkron işlem için Task</returns>
        public async Task ConfirmReservationAsync(int reservationId)
        {
            // Rezervasyonu veritabanından alıyoruz
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new Exception("Rezervasyon bulunamadı.");
            }

            // Rezervasyonun durumunu güncelliyoruz
            reservation.ReservationStatus = ReservationStatus.Confirmed;
            reservation.Status = DataStatus.Updated;
            reservation.ModifiedDate = DateTime.Now;

            // Yeni entity oluşturup güncelleme işlemini gerçekleştiriyoruz
            var newEntity = _mapper.Map<Reservation>(reservation);
            await _repository.UpdateAsync(reservation, newEntity);
        }

        /// <summary>
        /// Belirtilen rezervasyon ID'sine sahip, onaylanmış (Confirmed) rezervasyonu getirir.
        /// Eğer rezervasyon bulunamaz veya durum onaylı değilse, null döndürür.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Onaylanmış rezervasyonun DTO'su veya null</returns>
        public async Task<ReservationDto> GetConfirmedReservationByIdAsync(int reservationId)
        {
            var reservation = await _repository.GetByIdAsync(reservationId);
            //if (reservation == null || reservation.ReservationStatus != ReservationStatus.Confirmed)
            //{
            //    return null;
            //}
            return _mapper.Map<ReservationDto>(reservation);
        }


        //public async Task<List<ReservationDto>> GetReservationReportsAsync() // Rapor DTO listesini asenkron getirir
        //{
        //    // BaseManager üzerinden tüm rezervasyon DTO'larını alıyoruz
        //    var reservations = await GetAllAsync(); // Tüm rezervasyonları getirir

        //    // Her rezervasyon için ek rapor bilgilerini dolduruyoruz
        //    foreach (var reservation in reservations) // Her rezervasyon üzerinde döner
        //    {
        //        // Kullanıcı profil bilgisini getiriyoruz (AppUser profil bilgileri CustomerName için)
        //        var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId ?? 0); // Kullanıcı profil bilgisi alınır
        //        reservation.CustomerName = userProfile != null
        //            ? $"{userProfile.FirstName} {userProfile.LastName}" // İsim ve soyisim birleştirilir
        //            : "Bilinmeyen Müşteri"; // Profil bulunamazsa default değer

        //        // Oda bilgisini getiriyoruz (RoomNumber için)
        //        var room = await _roomManager.GetByIdAsync(reservation.RoomId); // Oda bilgisi alınır
        //        reservation.RoomNumber = room != null
        //            ? room.RoomNumber // Oda numarası atanır
        //            : "Bilinmeyen Oda"; // Oda bilgisi bulunamazsa default değer

        //        // Ek olarak, müşteri e-postasını da getirebiliriz
        //        var user = await _appUserManager.GetByIdAsync(reservation.AppUserId ?? 0); // Kullanıcı bilgisi alınır
        //        reservation.CustomerEmail = user != null
        //            ? user.Email // Email bilgisi atanır
        //            : "Bilinmeyen Email"; // Kullanıcı bulunamazsa default değer
        //    }

        //    return reservations; // Güncellenmiş rezervasyon DTO listesini döner
        //}

        public async Task<(decimal TotalRevenue, List<(int Year, int Month, decimal TotalRevenue)> MonthlyReports)> GetRevenueReportsAsync()
        {
            // Tüm rezervasyon DTO'larını alıyoruz (ReservationDto kullanılarak)
            var reservations = await GetAllAsync(); // BaseManager'dan tüm rezervasyonları getirir

            // Yalnızca onaylanmış (Confirmed) rezervasyonları filtreliyoruz
            var confirmedReservations = reservations
                .Where(r => r.ReservationStatus == ReservationStatus.Confirmed)
                .ToList();

            // Tüm onaylanmış rezervasyonların toplam gelirini hesaplıyoruz
            decimal totalRevenue = confirmedReservations.Sum(r => r.TotalPrice);

            // Aylık bazda gelir hesaplaması: Rezervasyonları başlangıç tarihine göre gruplandırıyoruz
            var monthlyReports = confirmedReservations
                .GroupBy(r => new { r.StartDate.Year, r.StartDate.Month })
                .Select(g => (Year: g.Key.Year, Month: g.Key.Month, TotalRevenue: g.Sum(r => r.TotalPrice)))
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            return (totalRevenue, monthlyReports);
        }

        /// <summary>
        /// Tüm rezervasyon DTO'larını alır ve her rezervasyon için eksik bilgileri (kullanıcı, kullanıcı profili ve oda bilgileri) tamamlar.
        /// Bu metot sayesinde controller, yalnızca tamamlanmış rezervasyon verisini alır.
        /// </summary>
        /// <returns>Tamamlanmış rezervasyon DTO'larının listesini döndürür.</returns>
        public async Task<List<ReservationDto>> GetReservationReportsAsync()
        {
            // BaseManager üzerinden tüm rezervasyon DTO'larını alıyoruz
            var reservations = await GetAllAsync();

            // Her rezervasyon için eksik bilgileri tamamlıyoruz
            foreach (var reservation in reservations)
            {
                // Kullanıcı bilgilerini çekiyoruz
                if (reservation.AppUserId.HasValue)
                {
                    var user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                    var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

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

                // Oda bilgilerini çekiyoruz
                var room = await _roomManager.GetByIdAsync(reservation.RoomId);
                reservation.RoomNumber = room != null ? room.RoomNumber.ToString() : "Bilinmeyen Oda";
            }

            return reservations;
        }

        /// <summary>
        /// Tüm rezervasyon DTO'larını alır, eksik bilgileri (kullanıcı, kullanıcı profili ve oda bilgileri) tamamlar
        /// ve verilen filtre parametrelerine göre filtreleyerek döndürür.
        /// </summary>
        /// <param name="search">Kullanıcı adı veya e-posta araması</param>
        /// <param name="roomId">Oda numarasına göre filtre</param>
        /// <param name="status">Rezervasyon durumu filtre</param>
        /// <param name="isPaid">Ödeme durumu filtre (true: ödeme yapılmış, false: ödeme bekleniyor)</param>
        /// <returns>Filtrelenmiş ve eksik bilgileri tamamlanmış ReservationDto listesini döndürür.</returns>
        public async Task<List<ReservationDto>> GetFilteredReservationReportsAsync(string search, int? roomId, string status, bool? isPaid)
        {
            // Tüm rezervasyon DTO'larını alıyoruz
            var reservations = await GetAllAsync();

            // Her rezervasyon için eksik bilgileri tamamlıyoruz
            foreach (var reservation in reservations)
            {
                // Kullanıcı bilgilerini çekiyoruz
                if (reservation.AppUserId.HasValue)
                {
                    var user = await _appUserManager.GetByIdAsync(reservation.AppUserId.Value);
                    var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId.Value);

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

                // Oda bilgilerini çekiyoruz
                var room = await _roomManager.GetByIdAsync(reservation.RoomId);
                reservation.RoomNumber = room != null ? room.RoomNumber.ToString() : "Bilinmeyen Oda";
            }

            // Filtreleme işlemleri:
            // Kullanıcı adı veya e-posta ile arama
            if (!string.IsNullOrEmpty(search))
            {
                reservations = reservations.Where(r =>
                    r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    r.CustomerEmail.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // Oda numarasına göre filtreleme (r.RoomNumber, string tipinde tutulduğu varsayılmıştır)
            if (roomId.HasValue)
            {
                reservations = reservations.Where(r => r.RoomNumber == roomId.ToString()).ToList();
            }

            // Rezervasyon durumuna göre filtreleme
            if (!string.IsNullOrEmpty(status))
            {
                reservations = reservations.Where(r => r.ReservationStatus.ToString() == status).ToList();
            }

            // Ödeme durumuna göre filtreleme (Confirmed: ödeme yapılmış, PendingPayment: ödeme bekleniyor)
            if (isPaid.HasValue)
            {
                reservations = reservations.Where(r =>
                    isPaid.Value ? r.ReservationStatus == ReservationStatus.Confirmed : r.ReservationStatus == ReservationStatus.PendingPayment
                ).ToList();
            }

            return reservations;
        }


        /// <summary>
        /// Belirtilen rezervasyon bilgilerini, ekstra hizmetleri ve reaktivasyon durumunu dikkate alarak rezervasyonu günceller.
        /// Bu metot; oda değişikliği kontrolü, tarih kontrolü, fiyat hesaplaması, rezervasyon güncellemesi,
        /// ekstra hizmetlerin güncellenmesi ve gerekirse rezervasyonun reaktif edilmesi işlemlerini gerçekleştirir.
        /// </summary>
        /// <param name="dto">Güncellenecek rezervasyon bilgilerini içeren ReservationDto</param>
        /// <param name="extraServiceIds">Rezervasyona eklenmek istenen ekstra hizmetlerin ID listesi</param>
        /// <param name="reactivateReservation">Rezervasyonun reaktif edilip edilmeyeceğini belirler</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını gösteren boolean değer</returns>
        public async Task<bool> UpdateReservationWithDetailsAsync(ReservationDto dto, List<int> extraServiceIds, bool reactivateReservation)
        {
            // Mevcut rezervasyonu veritabanından alıyoruz
            var existingReservation = await _repository.GetByIdAsync(dto.Id);
            if (existingReservation == null)
            {
                throw new Exception("Rezervasyon bulunamadı.");
            }

            // Oda değişikliğini kontrol ediyoruz
            if (existingReservation.RoomId != dto.RoomId)
            {
                // Eski odanın durumunu boş (Empty) olarak güncelliyoruz
                await _roomManager.UpdateRoomStatusAsync(existingReservation.RoomId, RoomStatus.Empty);
                // Yeni odanın durumunu dolu (Occupied) olarak güncelliyoruz
                await _roomManager.UpdateRoomStatusAsync(dto.RoomId, RoomStatus.Occupied);
            }

            // Tarihler için oda doluluk kontrolü
            bool isAvailable = CheckAvailabilityForUpdate(dto.Id, dto.RoomId, dto.StartDate, dto.EndDate);
            if (!isAvailable)
            {
                throw new Exception("Seçtiğiniz tarihler arasında oda dolu.");
            }

            // Güncellenmiş toplam fiyatı hesaplıyoruz
            dto.TotalPrice = CalculateUpdatedPrice(dto.RoomId, dto.StartDate, dto.EndDate, dto.PackageId);

            // Rezervasyon güncelleme işlemini gerçekleştiriyoruz
            bool updateResult = await UpdateReservationAsync(dto);
            if (!updateResult)
            {
                throw new Exception("Rezervasyon güncellenirken bir hata oluştu.");
            }

            // Rezervasyona ait ekstra hizmetleri güncelliyoruz (varsa)
            if (extraServiceIds != null && extraServiceIds.Any())
            {
                // _reservationExtraServiceManager'ın UpdateExtraServicesForReservation metodunu kullanıyoruz
                await _reservationExtraServiceManager.UpdateExtraServicesForReservation(dto.Id, extraServiceIds);
            }

            // Eğer reaktivasyon isteniyorsa rezervasyonu tekrar aktif hale getiriyoruz
            if (reactivateReservation)
            {
                await ReactivateReservationAsync(dto.Id);
            }

            return true;
        }


        /// <summary>
        /// Belirtilen rezervasyonun ödeme durumunu ve ilgili oda durumunu, yeni duruma göre günceller.
        /// Rezervasyon ve ödeme objelerinin durumları; Confirmed, PendingPayment ve Canceled durumlarına göre ayarlanır.
        /// Eğer yeni durum Canceled ise rezervasyon ve ödeme objeleri 'Deleted' statüsüne alınır ve oda boşaltılır.
        /// Eğer yeni durum PendingPayment veya Confirmed ise objeler Updated statüsüne alınır ve oda dolu olarak ayarlanır.
        /// </summary>
        /// <param name="reservationId">Güncellenecek rezervasyonun ID'si</param>
        /// <param name="newStatus">Yeni rezervasyon durumu (ReservationStatus)</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer</returns>
        public async Task<bool> UpdateReservationPaymentStatusAsync(int reservationId, ReservationStatus newStatus)
        {
            // Rezervasyonu çekiyoruz
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
                throw new Exception("Rezervasyon bulunamadı.");

            // IPaymentManager üzerinden ödeme bilgilerini çekiyoruz
            var payments = await _paymentManager.GetAllAsync();
            var payment = payments.FirstOrDefault(p => p.ReservationId == reservationId);
            if (payment == null)
                throw new Exception("Rezervasyona ait ödeme bilgisi bulunamadı.");

            // Orijinal (eski) nesneleri oluşturuyoruz (clone işlemi)
            var originalReservation = _mapper.Map<Reservation>(reservation);
            var originalPayment = _mapper.Map<PaymentDto>(payment);

            // Durum güncelleme işlemleri
            if (newStatus == ReservationStatus.Canceled)
            {
                reservation.Status = DataStatus.Deleted;
                reservation.DeletedDate = DateTime.Now;
                reservation.ModifiedDate = null;

                payment.Status = DataStatus.Deleted;
                payment.DeletedDate = DateTime.Now;
                payment.ModifiedDate = null;

                // Oda durumunu boş (Empty) olarak güncelliyoruz
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

                // Oda durumunu dolu (Occupied) olarak güncelliyoruz
                await _roomManager.UpdateRoomStatusAsync(reservation.RoomId, RoomStatus.Occupied);
            }

            // Yeni rezervasyon durumunu atıyoruz
            reservation.ReservationStatus = newStatus;

            // Güncellenmiş rezervasyon ve ödeme nesnelerini oluşturuyoruz
            var updatedReservation = _mapper.Map<Reservation>(reservation);
            var updatedPayment = _mapper.Map<PaymentDto>(payment);

            // Orijinal ve güncellenmiş nesneler ile UpdateAsync metodlarını çağırıyoruz
            await _repository.UpdateAsync(originalReservation, updatedReservation);
            await _paymentManager.UpdateAsync(updatedPayment);

            return true;
        }










    }
}