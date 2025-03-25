using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.MvcUI.Areas.Admin.Models;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // 🔐 Sadece Admin yetkisi olanlar erişebilir
    public class DashboardController : Controller
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IReservationManager _reservationManager;
        private readonly IRoomManager _roomManager;
        private readonly IPaymentManager _paymentManager;

        public DashboardController(
            IAppUserManager appUserManager,
            IReservationManager reservationManager,
            IRoomManager roomManager,
            IPaymentManager paymentManager)
        {
            _appUserManager = appUserManager;
            _reservationManager = reservationManager;
            _roomManager = roomManager;
            _paymentManager = paymentManager;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dashboardData = new DashboardViewModel
            {
                TotalUsers = await _appUserManager.GetTotalUserCountAsync(),
                ActiveUsers = await _appUserManager.GetActiveUserCountAsync(),
                TotalReservations = await _reservationManager.GetTotalReservationCountAsync(),
                ReservationsLast7Days = await _reservationManager.GetLast7DaysReservationCountAsync(),
                PendingReservations = await _reservationManager.GetPendingReservationCountAsync(),
                TotalRooms = await _roomManager.GetTotalRoomCountAsync(),
                EmptyRooms = await _roomManager.GetEmptyRoomCountAsync(),
                OccupiedRooms = await _roomManager.GetOccupiedRoomCountAsync(),
                MaintenanceRooms = await _roomManager.GetMaintenanceRoomCountAsync(),
                TotalRevenue = await _paymentManager.GetTotalRevenueAsync(),
                RevenueLast30Days = await _paymentManager.GetRevenueLast30DaysAsync(),
                PendingPayments = await _paymentManager.GetPendingPaymentsAsync()
            };

            return View(dashboardData);
        }
    }
}
