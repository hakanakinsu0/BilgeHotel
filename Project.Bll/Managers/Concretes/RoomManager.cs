using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class RoomManager : BaseManager<RoomDto, Room>, IRoomManager
    {
        readonly IRoomRepository _repository;
        readonly IReservationRepository _reservationRepository;
        public RoomManager(IRoomRepository repository, IMapper mapper, IReservationRepository reservationRepository) : base(repository, mapper)
        {
            _repository = repository;
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Sistem genelindeki toplam oda sayısını getirir.
        /// </summary>
        /// <returns>Toplam oda sayısı</returns>
        public async Task<int> GetTotalRoomCountAsync()
        {
            return await CountAsync(); // Tüm kayıtlar sayılır
        }

        /// <summary>
        /// Durumu "Empty" olan (boş) oda sayısını getirir.
        /// </summary>
        /// <returns>Boş odaların sayısı</returns>
        public async Task<int> GetEmptyRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Empty);
        }

        /// <summary>
        /// Durumu "Occupied" olan (dolu) oda sayısını getirir.
        /// </summary>
        /// <returns>Dolu odaların sayısı</returns>
        public async Task<int> GetOccupiedRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Occupied);
        }

        /// <summary>
        /// Durumu "Maintenance" olan (bakımda) oda sayısını getirir.
        /// </summary>
        /// <returns>Bakımda olan odaların sayısı</returns>
        public async Task<int> GetMaintenanceRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Maintenance);
        }

        /// <summary>
        /// Oda numarasına göre ilgili odayı getirir.
        /// </summary>
        /// <param name="roomNumber">Oda numarası</param>
        /// <returns>RoomDto nesnesi veya null</returns>
        public async Task<RoomDto> GetByRoomNumberAsync(string roomNumber)
        {
            Room roomEntity = await _repository.GetByRoomNumberAsync(roomNumber);
            return roomEntity != null ? _mapper.Map<RoomDto>(roomEntity) : null;
        }

        /// <summary>
        /// Yeni bir oda oluşturur ve veritabanına kaydeder.
        /// </summary>
        /// <param name="roomDto">Oluşturulacak oda bilgilerini içeren DTO</param>
        public async Task CreateAsync(RoomDto roomDto)
        {
            Room roomEntity = new() 
            {
                RoomNumber = roomDto.RoomNumber,
                Floor = roomDto.Floor,
                PricePerNight = roomDto.PricePerNight,
                RoomStatus = roomDto.RoomStatus,
                RoomTypeId = roomDto.RoomTypeId,         
                HasBalcony = roomDto.HasBalcony,
                HasMinibar = roomDto.HasMinibar,
                HasAirConditioner = roomDto.HasAirConditioner,
                HasTV = roomDto.HasTV,
                HasHairDryer = roomDto.HasHairDryer,
                HasWifi = roomDto.HasWifi,
                Status = DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(roomEntity); // Oda kaydediliyor
        }

        /// <summary>
        /// Mevcut bir odanın bilgilerini günceller.
        /// Oda doluysa RoomNumber ve RoomTypeId değiştirilemez.
        /// </summary>
        /// <param name="roomDto">Güncellenecek oda bilgilerini içeren DTO</param>
        public async Task UpdateAsync(RoomDto roomDto)
        {
            Room roomEntity = await _repository.GetByIdAsync(roomDto.Id);
            if (roomEntity == null)
                throw new Exception("Oda bulunamadı.");

            // Oda tipinin gerçekten mevcut olup olmadığı kontrol edilir
            Room roomTypeExists = await _repository.GetByIdAsync(roomDto.RoomTypeId);
            if (roomTypeExists == null)
                throw new Exception("Geçersiz oda tipi seçildi.");

            // Güncellenebilecek alanlar set edilir
            roomEntity.Floor = roomDto.Floor;
            roomEntity.PricePerNight = roomDto.PricePerNight;
            roomEntity.HasBalcony = roomDto.HasBalcony;
            roomEntity.HasMinibar = roomDto.HasMinibar;
            roomEntity.HasAirConditioner = roomDto.HasAirConditioner;
            roomEntity.HasTV = roomDto.HasTV;
            roomEntity.HasHairDryer = roomDto.HasHairDryer;
            roomEntity.HasWifi = roomDto.HasWifi;
            roomEntity.Status = DataStatus.Updated;
            roomEntity.ModifiedDate = DateTime.Now;

            // Oda doluysa RoomNumber ve RoomTypeId değiştirilmez
            if (roomEntity.RoomStatus != RoomStatus.Occupied)
            {
                roomEntity.RoomNumber = roomDto.RoomNumber;
                roomEntity.RoomTypeId = roomDto.RoomTypeId;
            }

            await _repository.UpdateAsync(roomEntity, roomEntity); // Güncelleme işlemi yapılır
        }

        /// <summary>
        /// Belirtilen odanın silinip silinemeyeceğini kontrol eder.
        /// Eğer odaya ait aktif (Confirmed) rezervasyon varsa silinemez.
        /// </summary>
        /// <param name="roomId">Silinmek istenen oda ID'si</param>
        /// <returns>Silinmeye uygun ise true, değilse false</returns>
        public async Task<bool> CanDeleteRoomAsync(int roomId)
        {
            Room? room = await _repository.Where(r => r.Id == roomId)
                                        .Include(r => r.Reservations) // Odaya ait rezervasyonlar yüklenir
                                        .FirstOrDefaultAsync();

            if (room == null)
                return false;

            // Confirmed rezervasyon varsa silinemez
            return !room.Reservations.Any(r => r.ReservationStatus == ReservationStatus.Confirmed);
        }

        /// <summary>
        /// Belirtilen odanın durumunu günceller.
        /// Aynı statüye tekrar güncelleme yapılmaz.
        /// </summary>
        /// <param name="roomId">Oda ID'si</param>
        /// <param name="newStatus">Yeni atanacak RoomStatus</param>
        /// <returns>İşlem başarılıysa true</returns>
        public async Task<bool> UpdateRoomStatusAsync(int roomId, RoomStatus newStatus)
        {
            Room roomEntity = await _repository.GetByIdAsync(roomId);
            if (roomEntity == null) throw new Exception("Oda bulunamadı.");

            // Eğer durum zaten aynıysa, işlem yapılmaz
            if (roomEntity.RoomStatus == newStatus)
            {
                Console.WriteLine($"⚠ Oda zaten bu statüde: ID={roomEntity.Id}, Durum={roomEntity.RoomStatus}");
                return true;
            }

            roomEntity.RoomStatus = newStatus;
            roomEntity.Status = DataStatus.Updated;
            roomEntity.ModifiedDate = DateTime.Now;

            Console.WriteLine($"RoomStatus Güncelleniyor: ID={roomEntity.Id}, Yeni Durum={roomEntity.RoomStatus}");

            await _repository.UpdateAsync(roomEntity, roomEntity);
            return true;
        }

        /// <summary>
        /// Verilen tarih aralığında müsait (çakışmayan) odaları getirir.
        /// </summary>
        /// <param name="startDate">Rezervasyon başlangıç tarihi</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi</param>
        /// <returns>Uygun RoomDto listesi</returns>
        public async Task<List<RoomDto>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate)
        {
            List<Room> rooms = await _repository
                .Where(room =>
                    !room.Reservations.Any(res =>
                        res.Status != DataStatus.Deleted &&
                        startDate < res.EndDate && endDate > res.StartDate)) // Çakışan rezervasyon kontrolü
                .Include(r => r.Reservations)
                .ToListAsync();

            return _mapper.Map<List<RoomDto>>(rooms);
        }

        /// <summary>
        /// Rezervasyon değişikliğinde eski oda boşaltılır, yeni oda dolu yapılır.
        /// Oda ID'leri farklıysa işlem yapılır.
        /// </summary>
        /// <param name="oldRoomId">Eski oda ID</param>
        /// <param name="newRoomId">Yeni oda ID</param>
        public async Task UpdateRoomStatusOnReservationChangeAsync(int oldRoomId, int newRoomId)
        {
            if (oldRoomId != newRoomId)
            {
                Room oldRoom = await _repository.GetByIdAsync(oldRoomId);
                if (oldRoom != null)
                {
                    oldRoom.RoomStatus = RoomStatus.Empty;
                    oldRoom.Status = DataStatus.Updated;
                    oldRoom.ModifiedDate = DateTime.Now;
                    await _repository.UpdateAsync(oldRoom, oldRoom);
                }

                Room newRoom = await _repository.GetByIdAsync(newRoomId);
                if (newRoom != null)
                {
                    newRoom.RoomStatus = RoomStatus.Occupied;
                    newRoom.Status = DataStatus.Updated;
                    newRoom.ModifiedDate = DateTime.Now;
                    await _repository.UpdateAsync(newRoom, newRoom);
                }
            }
        }

        /// <summary>
        /// Oda kullanımına dair detaylı istatistik raporu döner.
        /// Hem genel hem de o ay için doluluk oranlarını içerir.
        /// </summary>
        /// <returns>Oda kullanımıyla ilgili çeşitli oran ve sayılar</returns>
        public async Task<(int TotalRooms, int OccupiedRooms, int EmptyRooms, int MaintenanceRooms, double OccupiedPercentage, double MonthlyOccupiedPercentage, int MonthlyOccupiedRooms, double MonthlyOccupiedRoomsPercentage)> GetRoomUsageReportAsync()
        {
            List<RoomDto> rooms = await GetAllAsync();
            List<Reservation> reservations = await _reservationRepository.GetAllAsync();

            int totalRooms = rooms.Count;
            int occupiedRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Occupied);
            int maintenanceRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Maintenance);
            int emptyRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Empty);

            double occupiedPercentage = totalRooms > 0 ? (double)occupiedRooms / totalRooms * 100 : 0;

            DateTime currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

            List<Reservation> reservationsThisMonth = reservations
                .Where(r => r.StartDate <= currentMonthEnd && r.EndDate >= currentMonthStart)
                .ToList();

            Dictionary<int, int> roomOccupiedDays = new();

            foreach (Reservation reservation in reservationsThisMonth)
            {
                DateTime start = reservation.StartDate < currentMonthStart ? currentMonthStart : reservation.StartDate;
                DateTime end = reservation.EndDate > currentMonthEnd ? currentMonthEnd : reservation.EndDate;
                int occupiedDays = (int)(end - start).TotalDays;

                if (roomOccupiedDays.ContainsKey(reservation.RoomId))
                    roomOccupiedDays[reservation.RoomId] += occupiedDays;
                else
                    roomOccupiedDays[reservation.RoomId] = occupiedDays;
            }

            int uniqueOccupiedRoomsThisMonth = roomOccupiedDays.Count;
            int totalRoomDaysInMonth = totalRooms * DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int totalOccupiedDaysThisMonth = roomOccupiedDays.Values.Sum();
            double monthlyOccupiedPercentage = totalRoomDaysInMonth > 0 ? (double)totalOccupiedDaysThisMonth / totalRoomDaysInMonth * 100 : 0;
            double monthlyOccupiedRoomsPercentage = totalRooms > 0 ? (double)uniqueOccupiedRoomsThisMonth / totalRooms * 100 : 0;

            return (totalRooms, occupiedRooms, emptyRooms, maintenanceRooms, occupiedPercentage, monthlyOccupiedPercentage, uniqueOccupiedRoomsThisMonth, monthlyOccupiedRoomsPercentage);
        }

        /// <summary>
        /// Oda listeleme işlemi için filtre ve sayfalama uygular.
        /// Fiyata, kata, oda durumuna, oda tipine ve doluluk durumuna göre filtreleme yapılabilir.
        /// </summary>
        /// <param name="filter">Filtreleme ve sayfalama bilgilerini içeren DTO</param>
        /// <returns>Filtrelenmiş RoomDto listesi</returns>
        public async Task<List<RoomDto>> GetFilteredRoomsAsync(RoomDto filter)
        {
            IQueryable<Room> query = _repository
                .Where(r => r.Status != DataStatus.Deleted)
                .Include(r => r.RoomType)
                .Include(r => r.Reservations)
                .AsQueryable();

            if (filter.RoomTypeId != 0)
                query = query.Where(r => r.RoomTypeId == filter.RoomTypeId);

            if (filter.FilterRoomStatus.HasValue)
                query = query.Where(r => r.RoomStatus == filter.FilterRoomStatus.Value);

            if (filter.Floor != 0)
                query = query.Where(r => r.Floor == filter.Floor);

            if (filter.PricePerNight > 0)
                query = query.Where(r => r.PricePerNight >= filter.PricePerNight);

            if (filter.MaxPrice.HasValue)
                query = query.Where(r => r.PricePerNight <= filter.MaxPrice.Value);

            if (filter.FilterIsReserved.HasValue)
            {
                query = query.Where(r =>
                    r.Reservations.Any(res =>
                        res.Status != DataStatus.Deleted &&
                        res.ReservationStatus != ReservationStatus.Canceled) == filter.FilterIsReserved.Value);
            }

            // Toplam kayıt sayısı DTO'da tutulur
            filter.TotalRooms = await query.CountAsync();

            // Sayfalama işlemi
            List<Room> pagedRooms = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return _mapper.Map<List<RoomDto>>(pagedRooms);
        }
    }
}
