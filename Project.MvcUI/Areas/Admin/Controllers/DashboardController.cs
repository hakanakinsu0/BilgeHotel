using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Dashboard;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class DashboardController : Controller
    {
        readonly IAppUserManager _appUserManager;
        readonly IReservationManager _reservationManager;
        readonly IRoomManager _roomManager;
        readonly IPaymentManager _paymentManager;

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

        #region DashboardIndex

        /// <summary>
        /// Dashboard sayfası için gerekli verileri getirir.
        /// Toplam kullanıcı sayısı, aktif kullanıcı sayısı, rezervasyon istatistikleri, oda durumları ve gelir bilgileri gibi veriler toplanır.
        /// Bu veriler DashboardViewModel'e aktarılır ve view'e gönderilir.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            // DashboardViewModel, admin panelinde görüntülenecek istatistiksel verileri içerir.
            DashboardResponseModel dashboardData = new()
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

            // Toplanan veriler Dashboard view'ine gönderilir.
            return View(dashboardData);
        } 

        #endregion
    }
}
