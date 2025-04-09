using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Oteldeki odalar ile ilgili iş mantığı işlemlerini tanımlayan arayüzdür.
    /// Bu arayüz, oda sayıları, durum güncellemeleri, müsait oda sorgulamaları ve kullanım raporları gibi işlemleri kapsar.
    /// </summary>
    public interface IRoomManager : IManager<RoomDto, Room>
    {
        /// <summary>
        /// Toplam oda sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Toplam oda sayısı.</returns>
        Task<int> GetTotalRoomCountAsync();

        /// <summary>
        /// Boş (müsait) oda sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Boş oda sayısı.</returns>
        Task<int> GetEmptyRoomCountAsync();

        /// <summary>
        /// Dolu (rezerve edilmiş) oda sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Dolu oda sayısı.</returns>
        Task<int> GetOccupiedRoomCountAsync();

        /// <summary>
        /// Bakımda olan oda sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Bakımda olan oda sayısı.</returns>
        Task<int> GetMaintenanceRoomCountAsync();

        /// <summary>
        /// Belirtilen oda numarasına sahip oda bilgisini asenkron olarak getirir.
        /// </summary>
        /// <param name="roomNumber">Aranacak oda numarası.</param>
        /// <returns>Oda numarasına sahip oda DTO'su.</returns>
        Task<RoomDto> GetByRoomNumberAsync(string roomNumber);

        /// <summary>
        /// Belirtilen oda ID'sine göre oda silme işleminin gerçekleştirilebilirliğini kontrol eder.
        /// </summary>
        /// <param name="roomId">Kontrol edilecek oda ID'si.</param>
        /// <returns>Eğer oda silinebilir ise true, aksi halde false.</returns>
        Task<bool> CanDeleteRoomAsync(int roomId);

        /// <summary>
        /// Belirtilen oda ID'si için yeni oda durumunu asenkron olarak günceller.
        /// </summary>
        /// <param name="roomId">Güncellenecek oda ID'si.</param>
        /// <param name="newStatus">Yeni oda durumu (örneğin, Boş, Dolu, Bakımda).</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> UpdateRoomStatusAsync(int roomId, RoomStatus newStatus);

        /// <summary>
        /// Belirtilen tarih aralığında müsait odaların listesini asenkron olarak getirir.
        /// </summary>
        /// <param name="startDate">Rezervasyon başlangıç tarihi.</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi.</param>
        /// <returns>Müsait oda DTO'larının listesini döndürür.</returns>
        Task<List<RoomDto>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Rezervasyon değişikliği sırasında, eski oda ile yeni oda durumlarını günceller.
        /// </summary>
        /// <param name="oldRoomId">Eski oda ID'si.</param>
        /// <param name="newRoomId">Yeni oda ID'si.</param>
        /// <returns>Asenkron işlem tamamlandığında görev döner.</returns>
        Task UpdateRoomStatusOnReservationChangeAsync(int oldRoomId, int newRoomId);

        /// <summary>
        /// Oda kullanım raporlarını hesaplar ve asenkron olarak döndürür.
        /// Rapor; toplam oda sayısı, dolu, boş, bakımda olan oda sayıları ile bu sayıların yüzdesini içerir.
        /// Ayrıca aylık bazda dolu oda sayıları ve yüzdelerini de döndürür.
        /// </summary>
        /// <returns>
        /// Bir tuple döndürür:
        /// - TotalRooms: Toplam oda sayısı,
        /// - OccupiedRooms: Dolu oda sayısı,
        /// - EmptyRooms: Boş oda sayısı,
        /// - MaintenanceRooms: Bakımda olan oda sayısı,
        /// - OccupiedPercentage: Toplam odalar içindeki dolu oda yüzdesi,
        /// - MonthlyOccupiedPercentage: Aylık dolu oda yüzdesi,
        /// - MonthlyOccupiedRooms: Aylık dolu oda sayısı,
        /// - MonthlyOccupiedRoomsPercentage: Aylık dolu oda yüzdesi.
        /// </returns>
        Task<(int TotalRooms, int OccupiedRooms, int EmptyRooms, int MaintenanceRooms, double OccupiedPercentage, double MonthlyOccupiedPercentage, int MonthlyOccupiedRooms, double MonthlyOccupiedRoomsPercentage)> GetRoomUsageReportAsync();

        Task<List<RoomDto>> GetFilteredRoomsAsync(RoomDto filter);


    }
}
