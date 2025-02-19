namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class AdminDashboardPageVm
    {
        public int TotalReservations { get; set; }
        public decimal TodayRevenue { get; set; }
        public int AvailableRooms { get; set; }
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
    }
}
