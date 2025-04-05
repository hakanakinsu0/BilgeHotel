namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// UI'da oda kullanım raporlarını temsil eden model.
    /// Oteldeki toplam oda sayısı, dolu, boş ve bakımda olan oda sayıları ile
    /// anlık ve aylık doluluk oranlarını içerir.
    /// </summary>
    public class RoomUsageReportResponseModel
    {
        public int TotalRooms { get; set; } // Toplam oda sayısı
        public int OccupiedRooms { get; set; } // Anlık dolu oda sayısı
        public int EmptyRooms { get; set; } // Boş oda sayısı
        public int MaintenanceRooms { get; set; } // Bakımda olan oda sayısı
        public double OccupiedPercentage { get; set; } // Anlık doluluk oranı (%)
        public int MonthlyOccupiedRooms { get; set; } // Bu ay rezervasyonu olan toplam oda sayısı
        public double MonthlyOccupiedRoomsPercentage { get; set; } // Bu ay rezervasyonu olan odaların yüzdesi (%)
    }
}
