namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Oda kullanım durumlarını özetleyen rapor modelidir.
    /// Toplam oda, doluluk bilgileri ve doluluk oranlarını içerir.
    /// </summary>
    public class RoomUsageReportResponseModel
    {
        public int TotalRooms { get; set; } // Tüm oda sayısı
        public int OccupiedRooms { get; set; } // Dolu oda sayısı
        public int EmptyRooms { get; set; } // Boş oda sayısı
        public int MaintenanceRooms { get; set; } // Bakımda olan oda sayısı
        public double OccupiedPercentage { get; set; } // Anlık doluluk oranı
        public int MonthlyOccupiedRooms { get; set; } // Bu ay içinde en az bir rezervasyonu olan oda sayısı
        public double MonthlyOccupiedRoomsPercentage { get; set; } // Aylık doluluk yüzdesi
    }
}
