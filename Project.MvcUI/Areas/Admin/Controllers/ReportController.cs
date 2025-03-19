using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IRoomManager _roomManager;
        private readonly IAppUserProfileManager _appUserProfileManager;

        public ReportController(IReservationManager reservationManager, IAppUserManager appUserManager, IRoomManager roomManager, IAppUserProfileManager appUserProfileManager)
        {
            _reservationManager = reservationManager;
            _appUserManager = appUserManager;
            _roomManager = roomManager;
            _appUserProfileManager = appUserProfileManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Rezervasyon Raporları Sayfası
        public async Task<IActionResult> ReservationReports()
        {
            var reservations = await _reservationManager.GetAllAsync(); // ✅ Tüm rezervasyonları çekiyoruz

            var reportList = new List<ReservationReportResponseModel>();

            foreach (var reservation in reservations)
            {
                var user = await _appUserManager.GetByIdAsync(reservation.AppUserId ?? 0);
                var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(reservation.AppUserId ?? 0);
                var room = await _roomManager.GetByIdAsync(reservation.RoomId);

                reportList.Add(new ReservationReportResponseModel
                {
                    Id = reservation.Id,
                    CustomerName = (userProfile != null) ? $"{userProfile.FirstName} {userProfile.LastName}" : "Bilinmeyen Müşteri",
                    RoomNumber = room != null ? room.RoomNumber : "Bilinmeyen Oda",
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate,
                    ReservationStatus = reservation.ReservationStatus.ToString(),
                    TotalPrice = reservation.TotalPrice
                });
            }

            return View(reportList);
        }

        // Gelir Raporları Sayfası
        public async Task<IActionResult> RevenueReports()
        {
            var reservations = await _reservationManager.GetAllAsync();

            // ✅ Yalnızca onaylanmış (Confirmed) rezervasyonların gelirini hesaplıyoruz
            var confirmedReservations = reservations
                .Where(r => r.ReservationStatus == ReservationStatus.Confirmed)
                .ToList();

            decimal totalRevenue = confirmedReservations.Sum(r => r.TotalPrice);

            // ✅ Aylık bazda gelir hesaplaması
            var monthlyRevenueReports = confirmedReservations
                .GroupBy(r => new { r.StartDate.Year, r.StartDate.Month })
                .Select(g => new MonthlyRevenueReportResponseModel
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(r => r.TotalPrice)
                })
                .OrderBy(r => r.Year).ThenBy(r => r.Month)
                .ToList();

            var model = new RevenueReportResponseModel
            {
                TotalRevenue = totalRevenue,
                MonthlyRevenueReports = monthlyRevenueReports
            };

            return View(model);
        }

        // Oda Raporları Sayfası
        public async Task<IActionResult> RoomUsageReports()
        {
            var rooms = await _roomManager.GetAllAsync();
            var reservations = await _reservationManager.GetAllAsync();

            int totalRooms = rooms.Count;
            int occupiedRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Occupied);
            int emptyRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Empty);
            int maintenanceRooms = rooms.Count(r => r.RoomStatus == RoomStatus.Maintenance);

            double occupiedPercentage = totalRooms > 0 ? (double)occupiedRooms / totalRooms * 100 : 0;

            // 📅 İçinde bulunduğumuz ayın başlangıç ve bitiş tarihini alalım
            var currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

            // 📅 Bu ay içindeki rezervasyonları filtreleyelim
            var reservationsThisMonth = await _reservationManager.GetAllAsync();
            reservationsThisMonth = reservationsThisMonth
                .Where(res => res.StartDate <= currentMonthEnd && res.EndDate >= currentMonthStart)
                .ToList();

            // 📊 Oda bazlı dolu günleri hesaplayalım
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

            // 📊 Bu ay içinde rezervasyon yapılan odaları belirleyelim
            int uniqueOccupiedRoomsThisMonth = roomOccupiedDays.Count;
            int totalRoomDaysInMonth = totalRooms * DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int totalOccupiedDaysThisMonth = roomOccupiedDays.Values.Sum();

            double monthlyOccupiedPercentage = totalRoomDaysInMonth > 0
                ? (double)totalOccupiedDaysThisMonth / totalRoomDaysInMonth * 100
                : 0;

            var model = new RoomUsageReportResponseModel
            {
                TotalRooms = totalRooms,
                OccupiedRooms = occupiedRooms,
                EmptyRooms = totalRooms - occupiedRooms - maintenanceRooms,
                MaintenanceRooms = maintenanceRooms,
                OccupiedPercentage = occupiedPercentage,
                MonthlyOccupiedPercentage = monthlyOccupiedPercentage,
                MonthlyOccupiedRooms = roomOccupiedDays.Count,
            };

            return View(model);
        }

        // Musteri Raporları Sayfası
        public async Task<IActionResult> CustomerReports()
        {
            var users = await _appUserManager.GetAllAsync();
            var userProfiles = await _appUserProfileManager.GetAllAsync();
            var reservations = await _reservationManager.GetAllAsync();

            // 📌 Admin (UserId = 1) olan kullanıcıyı hariç tut, sadece Member kullanıcıları say
            var members = users.Where(u => u.Id != 1).ToList();
            var totalCustomers = members.Count; // 📌 Toplam müşteri sayısı (Admin hariç)

            // 📌 Rezervasyon yapan müşteri sayısını hesapla (Sadece Member olanlar)
            var customersWithReservations = reservations
                .Where(r => r.AppUserId.HasValue && r.AppUserId != 1)
                .Select(r => r.AppUserId)
                .Distinct()
                .Count();

            // 📌 Rezervasyon yapmayan müşteri sayısını hesapla
            var customersWithoutReservations = totalCustomers - customersWithReservations;

            // 📌 Müşteri detaylarını içeren listeyi oluştur
            var customerList = members.Select(user => new CustomerReportResponseModel
            {
                Id = user.Id,
                FullName = userProfiles.FirstOrDefault(p => p.AppUserId == user.Id)?.FirstName + " " +
                           userProfiles.FirstOrDefault(p => p.AppUserId == user.Id)?.LastName,
                Email = user.Email,
                IdentityNumber = userProfiles.FirstOrDefault(p => p.AppUserId == user.Id)?.IdentityNumber,
                ReservationCount = reservations.Count(r => r.AppUserId == user.Id)
            }).ToList();

            var model = new CustomerReportListResponseModel
            {
                TotalCustomers = totalCustomers,
                CustomersWithReservations = customersWithReservations,
                CustomersWithoutReservations = customersWithoutReservations,
                Customers = customerList
            };

            return View(model);
        }


    }
}
