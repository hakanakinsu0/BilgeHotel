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

        public ReservationManager(IReservationRepository repository, IRoomRepository roomRepository, IMapper mapper, IExtraServiceManager extraServiceManager) : base(repository, mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _extraServiceManager = extraServiceManager;
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
            return !_repository.Where(r => r.RoomId == roomId &&
                                           ((startDate >= r.StartDate && startDate < r.EndDate) ||
                                            (endDate > r.StartDate && endDate <= r.EndDate)))
                               .Any();
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
            if (reservation == null || reservation.ReservationStatus != ReservationStatus.Confirmed)
            {
                return null;
            }
            return _mapper.Map<ReservationDto>(reservation);
        }

    }
}
