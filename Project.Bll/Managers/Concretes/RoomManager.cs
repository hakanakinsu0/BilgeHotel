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


        //

        public async Task<int> GetTotalRoomCountAsync()
        {
            return await CountAsync();
        }

        public async Task<int> GetEmptyRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Empty);
        }

        public async Task<int> GetOccupiedRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Occupied);
        }

        public async Task<int> GetMaintenanceRoomCountAsync()
        {
            return await CountAsync(r => r.RoomStatus == RoomStatus.Maintenance);
        }

        public async Task<RoomDto> GetByRoomNumberAsync(string roomNumber)
        {
            var roomEntity = await _repository.GetByRoomNumberAsync(roomNumber);
            return roomEntity != null ? _mapper.Map<RoomDto>(roomEntity) : null;
        }


        //

        public async Task CreateAsync(RoomDto roomDto)
        {
            var roomEntity = new Room
            {
                RoomNumber = roomDto.RoomNumber,
                Floor = roomDto.Floor,
                PricePerNight = roomDto.PricePerNight,
                RoomStatus = roomDto.RoomStatus,
                RoomTypeId = roomDto.RoomTypeId, // ✅ Sadece RoomTypeId kullanılıyor
                HasBalcony = roomDto.HasBalcony,
                HasMinibar = roomDto.HasMinibar,
                HasAirConditioner = roomDto.HasAirConditioner,
                HasTV = roomDto.HasTV,
                HasHairDryer = roomDto.HasHairDryer,
                HasWifi = roomDto.HasWifi,
                Status = DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(roomEntity); // ✅ RoomType eklenmeden kaydedilecek
        }

        public async Task UpdateAsync(RoomDto roomDto)
        {
            var roomEntity = await _repository.GetByIdAsync(roomDto.Id);
            if (roomEntity == null) throw new Exception("Oda bulunamadı.");

            // ✅ Geçerli bir RoomTypeId olup olmadığını kontrol et
            var roomTypeExists = await _repository.GetByIdAsync(roomDto.RoomTypeId);
            if (roomTypeExists == null) throw new Exception("Geçersiz oda tipi seçildi.");

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

            // ✅ Eğer oda doluysa, RoomNumber ve RoomTypeId değiştirilemez!
            if (roomEntity.RoomStatus != RoomStatus.Occupied)
            {
                roomEntity.RoomNumber = roomDto.RoomNumber;
                roomEntity.RoomTypeId = roomDto.RoomTypeId;
            }


            await _repository.UpdateAsync(roomEntity, roomEntity);
        }


        public async Task<bool> CanDeleteRoomAsync(int roomId)
        {
            var room = await _repository.Where(r => r.Id == roomId)
                                        .Include(r => r.Reservations) // ❗️ Rezervasyon ilişkisini yüklüyoruz
                                        .FirstOrDefaultAsync();

            if (room == null)
                return false; // Oda bulunamadıysa silinemez

            return !room.Reservations.Any(r => r.ReservationStatus == ReservationStatus.Confirmed);
        }

        public async Task<bool> UpdateRoomStatusAsync(int roomId, RoomStatus newStatus)
        {
            var roomEntity = await _repository.GetByIdAsync(roomId);
            if (roomEntity == null) throw new Exception("Oda bulunamadı.");

            // 🔍 Eğer oda zaten istenen statüdeyse, gereksiz güncelleme yapma
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

        public async Task<List<RoomDto>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate)
        {
            // Oda rezervasyon ilişkisini dahil ederek, çakışan rezervasyonu olmayan odaları seçiyoruz.
            var rooms = await _repository
                .Where(room =>
                    !room.Reservations.Any(res =>
                        res.Status != DataStatus.Deleted &&
                        startDate < res.EndDate && endDate > res.StartDate))
                .Include(r => r.Reservations)
                .ToListAsync();

            return _mapper.Map<List<RoomDto>>(rooms);
        }


        /// <summary>
        /// Rezervasyon değişikliği sırasında oda durumlarını günceller.
        /// Eski oda farklıysa, eski odanın durumunu "Empty" ve yeni odanın durumunu "Occupied" olarak ayarlar.
        /// </summary>
        /// <param name="oldRoomId">Eski oda ID'si</param>
        /// <param name="newRoomId">Yeni oda ID'si</param>
        /// <returns>Asenkron işlem için Task</returns>
        public async Task UpdateRoomStatusOnReservationChangeAsync(int oldRoomId, int newRoomId)
        {
            if (oldRoomId != newRoomId)
            {
                // Eski oda durumunu güncelle: boş olarak ayarla.
                var oldRoom = await _repository.GetByIdAsync(oldRoomId);
                if (oldRoom != null)
                {
                    oldRoom.RoomStatus = RoomStatus.Empty;
                    oldRoom.Status = DataStatus.Updated;
                    oldRoom.ModifiedDate = DateTime.Now;
                    await _repository.UpdateAsync(oldRoom, oldRoom);
                }

                // Yeni oda durumunu güncelle: dolu olarak ayarla.
                var newRoom = await _repository.GetByIdAsync(newRoomId);
                if (newRoom != null)
                {
                    newRoom.RoomStatus = RoomStatus.Occupied;
                    newRoom.Status = DataStatus.Updated;
                    newRoom.ModifiedDate = DateTime.Now;
                    await _repository.UpdateAsync(newRoom, newRoom);
                }
            }
        }


        public async Task<(int TotalRooms, int OccupiedRooms, int EmptyRooms, int MaintenanceRooms, double OccupiedPercentage, double MonthlyOccupiedPercentage, int MonthlyOccupiedRooms, double MonthlyOccupiedRoomsPercentage)> GetRoomUsageReportAsync()
        {
            var rooms = await GetAllAsync();
            var reservations = await _reservationRepository.GetAllAsync();

            int totalRooms = rooms.Count;
            int occupiedRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Occupied);
            int maintenanceRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Maintenance);
            int emptyRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Empty);

            double occupiedPercentage = totalRooms > 0 ? (double)occupiedRooms / totalRooms * 100 : 0;

            var currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

            var reservationsThisMonth = await _reservationRepository.GetAllAsync();
            reservationsThisMonth = reservationsThisMonth
                .Where(r => r.StartDate <= currentMonthEnd && r.EndDate >= currentMonthStart)
                .ToList();

            var roomOccupiedDays = new Dictionary<int, int>();

            foreach (var reservation in reservationsThisMonth)
            {
                var start = reservation.StartDate < currentMonthStart ? currentMonthStart : reservation.StartDate;
                var end = reservation.EndDate > currentMonthEnd ? currentMonthEnd : reservation.EndDate;
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

            // Bu formülü, "bu ay rezervasyon yapılan odaların yüzdesi" olarak hesaplamak için ekliyoruz:
            double monthlyOccupiedRoomsPercentage = totalRooms > 0 ? (double)uniqueOccupiedRoomsThisMonth / totalRooms * 100 : 0;

            return (totalRooms, occupiedRooms, emptyRooms, maintenanceRooms, occupiedPercentage, monthlyOccupiedPercentage, uniqueOccupiedRoomsThisMonth, monthlyOccupiedRoomsPercentage);
        }






    }
}
