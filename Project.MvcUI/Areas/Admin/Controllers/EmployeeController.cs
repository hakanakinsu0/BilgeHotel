using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Employees;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin paneli için çalışan (employee) işlemlerini yöneten controller'dır.
    /// Listeleme, oluşturma, güncelleme ve silme işlemlerini içerir.
    /// </summary>

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        #region EmployeeIndexAction

        /// <summary>
        /// Tüm çalışanları getirir ve filtreleme, arama, sayfalama işlemlerini yaparak View'e gönderir.
        /// </summary>
        /// <param name="position">Filtrelenecek pozisyon adı</param>
        /// <param name="status">Filtrelenecek çalışan durumu (Inserted, Updated, Deleted)</param>
        /// <param name="search">Ad veya soyad arama terimi</param>
        /// <param name="page">Mevcut sayfa numarası</param>
        /// <param name="pageSize">Sayfa başına gösterilecek çalışan sayısı</param>
        public async Task<IActionResult> Index(string position, string status, string search, int page = 1, int pageSize = 10)
        {
            // Tüm çalışanlar veritabanından çekilir
            List<EmployeeDto> employees = await _employeeManager.GetAllAsync();

            // Pozisyona göre filtreleme
            if (!string.IsNullOrEmpty(position))
                employees = employees.Where(e => e.Position == position).ToList();

            // Durum (DataStatus) enum'una göre filtreleme (Aktif, Güncellenmiş, Silinmiş)
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<DataStatus>(status, out var parsedStatus))
                employees = employees.Where(e => e.Status == parsedStatus).ToList();

            // İsim veya soyisim aramasına göre filtreleme (case-insensitive)
            if (!string.IsNullOrEmpty(search))
            {
                string lower = search.ToLower();
                employees = employees.Where(e =>
                    (!string.IsNullOrEmpty(e.FirstName) && e.FirstName.ToLower().Contains(lower)) ||
                    (!string.IsNullOrEmpty(e.LastName) && e.LastName.ToLower().Contains(lower))
                ).ToList();
            }

            // Sayfalama işlemi
            int totalEmployees = employees.Count;
            int totalPages = (int)Math.Ceiling((double)totalEmployees / pageSize);
            employees = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // ViewBag: Pozisyon ve Durum dropdown'ları için veriler hazırlanır
            List<string> allPositions = await _employeeManager.GetDistinctPositionsAsync();
            ViewBag.Positions = new SelectList(allPositions, position);
            ViewBag.Statuses = new List<SelectListItem>
            {
                new SelectListItem { Text = "Aktif", Value = DataStatus.Inserted.ToString(), Selected = status == DataStatus.Inserted.ToString() },
                new SelectListItem { Text = "Güncellendi", Value = DataStatus.Updated.ToString(), Selected = status == DataStatus.Updated.ToString() },
                new SelectListItem { Text = "Silinmiş", Value = DataStatus.Deleted.ToString(), Selected = status == DataStatus.Deleted.ToString() }
            };

            // View'e gönderilecek model oluşturuluyor
            EmployeeListResponseModel model = new()
            {
                Employees = employees.Select(e => new EmployeeListItemResponseModel
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Position = e.Position,
                    PhoneNumber = e.PhoneNumber,
                    Status = e.Status.ToString()
                }).ToList(),
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };

            return View(model);
        }


        #endregion

        #region EmployeeCreateAction

        /// <summary>
        /// Yeni çalışan oluşturma formunu gösterir.
        /// Pozisyon seçenekleri ViewBag üzerinden View'e taşınır.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            // View'da dropdown için pozisyon listesi veritabanından alınır
            List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
            ViewBag.Positions = new SelectList(positions);

            // Boş form view'e gönderilir
            return View();
        }

        /// <summary>
        /// Yeni bir çalışan oluşturur. Formdan gelen verileri kontrol eder, DTO’ya dönüştürerek veritabanına kaydeder.
        /// </summary>
        /// <param name="model">Kullanıcıdan alınan çalışan oluşturma verileri (RequestModel).</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateRequestModel model)
        {
            // Model doğrulama başarısızsa form yeniden gösterilir
            if (!ModelState.IsValid)
            {
                List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
                ViewBag.Positions = new SelectList(positions);
                return View(model);
            }

            // Telefon numarası +90 formatına çevrilir
            string formattedPhone = _employeeManager.FormatPhoneNumber(model.PhoneNumber);

            // Vardiya tipi rastgele atanır
            ShiftType randomShift = _employeeManager.GetRandomShift();

            // RequestModel → DTO dönüşümü yapılır
            EmployeeDto dto = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                PhoneNumber = formattedPhone,
                Address = model.Address,
                BirthDate = model.BirthDate,
                Salary = model.Salary,
                Shift = randomShift,
                HireDate = DateTime.Now,        // Şu an işe alınmış gibi set edilir
                CreatedDate = DateTime.Now,     // Oluşturulma zamanı
                Status = DataStatus.Inserted    // Varsayılan durum
            };

            // Veritabanına kayıt işlemi yapılır
            await _employeeManager.CreateAsync(dto);

            // Başarı mesajı TempData ile taşınır
            TempData["SuccessMessage"] = "Çalışan başarıyla eklendi.";

            // Listeleme ekranına yönlendirilir
            return RedirectToAction("Index");
        }

        #endregion

        #region EmployeeEditAction

        /// <summary>
        /// Belirli bir çalışanı düzenlemek için formu getirir. Mevcut veriler view'e aktarılır.
        /// </summary>
        /// <param name="id">Düzenlenecek çalışanın ID değeri.</param>
        public async Task<IActionResult> Edit(int id)
        {
            // Çalışan bilgisi veritabanından alınır
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Çalışan yoksa 404 döndür

            // Pozisyon dropdown verisi ViewBag üzerinden gönderilir
            List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
            ViewBag.Positions = new SelectList(positions);

            // DTO → RequestModel dönüşümü (formu doldurmak için)
            EmployeeUpdateRequestModel model = new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                PhoneNumber = employee.PhoneNumber.Replace("+90", "0"), // Kullanıcıya 0'lı gösterim
                Salary = employee.Salary,
                Address = employee.Address
            };

            return View(model); // Form gönderilir
        }

        /// <summary>
        /// Çalışan bilgilerini günceller. Formdan gelen veriler doğrulanır ve DTO’ya dönüştürülerek kaydedilir.
        /// </summary>
        /// <param name="model">Güncellenmiş çalışan form verisi</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeUpdateRequestModel model)
        {
            // Model geçersizse, tekrar form gösterilir
            if (!ModelState.IsValid)
            {
                List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
                ViewBag.Positions = new SelectList(positions);
                return View(model);
            }

            // Mevcut çalışanı veritabanından al
            EmployeeDto existingEmployee = await _employeeManager.GetByIdAsync(model.Id);
            if (existingEmployee == null)
            {
                TempData["ErrorMessage"] = "Çalışan bulunamadı.";
                return RedirectToAction("Index");
            }

            // Telefon formatı normalize edilir
            string formattedPhone = _employeeManager.FormatPhoneNumber(model.PhoneNumber);

            // Güncellenecek DTO hazırlanır, sadece değişen alanlar güncellenir
            EmployeeDto dto = new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                PhoneNumber = formattedPhone,
                Salary = model.Salary,
                Address = model.Address,
                HireDate = existingEmployee.HireDate,
                BirthDate = existingEmployee.BirthDate,
                Shift = existingEmployee.Shift,
                CreatedDate = existingEmployee.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            // Güncelleme işlemi yapılır
            await _employeeManager.UpdateAsync(dto);

            TempData["SuccessMessage"] = "Çalışan bilgileri güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region EmployeeDeleteAction

        /// <summary>
        /// Silme onayı ekranını getirir. Seçilen çalışanın bilgileri view'e gönderilir.
        /// </summary>
        /// <param name="id">Silinecek çalışanın ID'si.</param>
        public async Task<IActionResult> Delete(int id)
        {
            // Silinmek istenen çalışan veritabanından alınır
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Çalışan yoksa 404 döndürülür

            // View'e gönderilecek model hazırlanır
            EmployeeDeleteResponseModel model = new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                PhoneNumber = employee.PhoneNumber
            };

            // Silme onay ekranı açılır
            return View(model);
        }

        /// <summary>
        /// Silme işlemini gerçekleştirir. Veritabanında çalışanın durumunu pasif yapar (soft delete).
        /// </summary>
        /// <param name="id">Silinecek çalışanın ID'si.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Silinecek çalışan tekrar alınır (veri tutarlılığı sağlamak için)
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Kayıt bulunamazsa hata döner

            // Soft delete için DTO hazırlanır
            EmployeeDto dto = new()
            {
                Id = employee.Id,
                Status = DataStatus.Deleted,
                DeletedDate = DateTime.Now
            };

            // Veritabanında soft delete işlemi yapılır
            await _employeeManager.MakePassiveAsync(dto);

            // Bilgilendirme mesajı
            TempData["SuccessMessage"] = "Çalışan silindi.";

            // Listeleme sayfasına yönlendirilir
            return RedirectToAction("Index");
        }

        #endregion
    }
}