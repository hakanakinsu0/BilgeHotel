namespace Project.MvcUI.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalReservations { get; set; }
        public int ReservationsLast7Days { get; set; }
        public int PendingReservations { get; set; }
        public int TotalRooms { get; set; }
        public int EmptyRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int MaintenanceRooms { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal RevenueLast30Days { get; set; }
        public decimal PendingPayments { get; set; }
    }
}
