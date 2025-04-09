using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin panelinde raporlama işlemlerini yöneten controller'dır.
    /// Rezervasyon, gelir, oda kullanımı ve müşteri istatistikleri gibi çeşitli raporları sunar.
    /// </summary>

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

        #region ReportIndexAction

        /// <summary>
        /// Ana rapor sayfasını döndürür.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region ReservationReportsAction

        /// <summary>
        /// Rezervasyon raporlarını oluşturur ve view'e gönderir.
        /// İş mantığı BLL'de tanımlı metottan alınan veriler UI modeline map edilir.
        /// </summary>
        public async Task<IActionResult> ReservationReports()
        {
            // Manager'dan rezervasyon rapor verileri asenkron olarak alınır
            List<ReservationDto> reservationReports = await _reservationManager.GetReservationReportsAsync();

            // Alınan veriler, UI modeline dönüştürülür
            List<ReservationReportResponseModel> reportList = reservationReports.Select(r => new ReservationReportResponseModel
            {
                Id = r.Id, // Rezervasyon ID'si
                CustomerName = r.CustomerName, // Müşteri adı
                RoomNumber = r.RoomNumber, // Oda numarası
                StartDate = r.StartDate, // Rezervasyon başlangıç tarihi
                EndDate = r.EndDate, // Rezervasyon bitiş tarihi
                ReservationStatus = r.ReservationStatus.ToString(), // Rezervasyon durumu 
                TotalPrice = r.TotalPrice // Toplam fiyat
            }).ToList();

            return View(reportList); // View'e model gönderilir
        }

        #endregion

        #region RevenueReportsAction

        /// <summary>
        /// Gelir raporlarını oluşturur ve view'e gönderir.
        /// Manager'dan dönen tuple verileri UI modeline map edilir.
        /// </summary>
        public async Task<IActionResult> RevenueReports()
        {
            // Manager'daki gelir raporu metodundan toplam gelir ve aylık raporlar tuple olarak alınır
            var report = await _reservationManager.GetRevenueReportsAsync();

            // Alınan veriler UI response modeline dönüştürülür
            RevenueReportResponseModel model = new()
            {
                TotalRevenue = report.TotalRevenue, // Genel toplam gelir
                MonthlyRevenueReports = report.MonthlyReports.Select(x => new MonthlyRevenueReportResponseModel
                {
                    Year = x.Year, // Aylık rapor için yıl
                    Month = x.Month, // Aylık rapor için ay
                    TotalRevenue = x.TotalRevenue // Aylık toplam gelir
                }).ToList()
            };
            return View(model); // Model view'e gönderilir
        }

        #endregion

        #region RoomUsageReportsAction

        /// <summary>
        /// Oda kullanım raporlarını oluşturur ve view'e gönderir.
        /// Manager'dan alınan hesaplanmış veriler UI modeline map edilir.
        /// </summary>
        public async Task<IActionResult> RoomUsageReports()
        {
            // RoomManager'daki hesaplanmış oda kullanım raporu asenkron olarak alınır
            var report = await _roomManager.GetRoomUsageReportAsync();

            // Alınan veriler, UI modeline dönüştürülür
            RoomUsageReportResponseModel model = new()
            {
                TotalRooms = report.TotalRooms, // Toplam oda sayısı
                OccupiedRooms = report.OccupiedRooms, // Dolu oda sayısı
                EmptyRooms = report.EmptyRooms, // Boş oda sayısı
                MaintenanceRooms = report.MaintenanceRooms, // Bakımda olan oda sayısı
                OccupiedPercentage = report.OccupiedPercentage, // Anlık doluluk oranı
                MonthlyOccupiedRoomsPercentage = report.MonthlyOccupiedRoomsPercentage, // Bu ay rezervasyon yapılan odaların yüzdesi
                MonthlyOccupiedRooms = report.MonthlyOccupiedRooms // Bu ay rezervasyon yapılan oda sayısı
            };
            return View(model); // Model view'e gönderilir
        }

        #endregion

        #region CustomerReportsAction

        /// <summary>
        /// Müşteri raporlarını oluşturur ve view'e gönderir.
        /// Manager'dan dönen ham veriler UI modeline map edilir.
        /// </summary>
        public async Task<IActionResult> CustomerReports()
        {
            // Manager'dan müşteri rapor verileri asenkron olarak alınır (tuple şeklinde)
            var reportData = await _appUserManager.GetCustomerReportDataAsync();

            // Tuple'dan dönen veriler yerel değişkenlere atanır
            int totalCustomers = reportData.TotalCustomers;
            int customersWithReservations = reportData.CustomersWithReservations;
            int customersWithoutReservations = reportData.CustomersWithoutReservations;

            // Müşteri bilgileri, profil bilgileri ve rezervasyon bilgileri listeleri
            List<AppUserDto> members = reportData.Members;
            List<AppUserProfileDto> profiles = reportData.Profiles;
            List<ReservationDto> reservations = reportData.Reservations;

            // Her üye için rapor detayları oluşturulur
            List<CustomerReportResponseModel> customerList = members.Select(user =>
            {
                AppUserProfileDto? profile = profiles.FirstOrDefault(p => p.AppUserId == user.Id);
                return new CustomerReportResponseModel
                {
                    Id = user.Id, // Kullanıcı ID'si
                    FullName = (profile?.FirstName ?? "") + " " + (profile?.LastName ?? ""), // İsim ve soyisim birleştirilir
                    Email = user.Email, // Kullanıcı email adresi
                    IdentityNumber = profile?.IdentityNumber ?? "", // Kimlik numarası
                    ReservationCount = reservations.Count(r => r.AppUserId == user.Id) // Rezervasyon sayısı
                };
            }).ToList();

            // UI modeline müşteri raporu bilgileri atanır
            CustomerReportListResponseModel model = new()
            {
                TotalCustomers = totalCustomers, // Toplam müşteri sayısı
                CustomersWithReservations = customersWithReservations, // Rezervasyon yapan müşteri sayısı
                CustomersWithoutReservations = customersWithoutReservations, // Rezervasyon yapmayan müşteri sayısı
                Customers = customerList // Müşteri detayları listesi
            };
            return View(model); // Model view'e gönderilir
        }

        #endregion
    }
}