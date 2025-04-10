/// <summary>
/// Admin paneli ana sayfasında gösterilecek istatistiksel verileri içeren response modelidir.
/// Toplam kullanıcı sayısı, rezervasyonlar, oda durumu ve gelir gibi temel metrikleri barındırır.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Dashboard
{
    public class DashboardResponseModel
    {
        public int TotalUsers { get; set; } // Sistemdeki toplam kullanıcı sayısı
        public int ActiveUsers { get; set; } // Aktif kullanıcı sayısı
        public int TotalReservations { get; set; } // Toplam rezervasyon sayısı
        public int ReservationsLast7Days { get; set; } // Son 7 gündeki rezervasyon sayısı
        public int PendingReservations { get; set; } // Onay bekleyen rezervasyon sayısı
        public int TotalRooms { get; set; } // Sistemdeki toplam oda sayısı
        public int EmptyRooms { get; set; } // Boş (müsait) oda sayısı
        public int OccupiedRooms { get; set; } // Dolu (rezerve edilmiş) oda sayısı
        public int MaintenanceRooms { get; set; } // Bakımda olan oda sayısı
        public decimal TotalRevenue { get; set; } // Tüm zamanlardaki toplam gelir
        public decimal RevenueLast30Days { get; set; } // Son 30 gündeki toplam gelir
        public decimal PendingPayments { get; set; } // Bekleyen (ödenmemiş) tutar
    }
}
