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
        /// Tüm çalışanları (silinmiş olanlar dahil) getirir ve listeleme ekranında gösterilmek üzere view'e gönderir.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            // Veritabanından tüm çalışan verileri çekilir (Status filtrelemesi yapılmaz)
            List<EmployeeDto> employees = await _employeeManager.GetAllAsync();

            // DTO'lar, response model listesine dönüştürülür
            EmployeeListResponseModel model = new()
            {
                Employees = employees.Select(e => new EmployeeListItemResponseModel
                {
                    Id = e.Id,                                      // Çalışan ID
                    FirstName = e.FirstName,                        // Ad
                    LastName = e.LastName,                          // Soyad
                    Position = e.Position,                          // Pozisyon
                    PhoneNumber = e.PhoneNumber,                    // Telefon
                    Status = e.Status.ToString()                    // Durum enum → string
                }).ToList()
            };

            // Listeleme ekranına response model gönderilir
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
            // Pozisyonlar: veritabanındaki tüm pozisyonlar DISTINCT olarak alınır
            List<string> positions = await _employeeManager.GetDistinctPositionsAsync();

            // ViewBag ile view tarafına aktarılır (dropdown için)
            ViewBag.Positions = new SelectList(positions);

            // Boş form gösterilir
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
            // ModelState doğrulaması yapılır
            if (!ModelState.IsValid)
            {
                // Sayfa tekrar yükleneceği için pozisyonlar yeniden set edilir
                List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
                ViewBag.Positions = new SelectList(positions);

                // Hatalı form tekrar kullanıcıya gösterilir
                return View(model);
            }

            // Telefon numarası +90 formatına çevrilir (örnek: 0555... → +90555...)
            string formattedPhone = _employeeManager.FormatPhoneNumber(model.PhoneNumber);

            // Rastgele vardiya seçimi yapılır (ShiftType enum'undan)
            ShiftType randomShift = _employeeManager.GetRandomShift();

            // RequestModel → DTO dönüşümü yapılır
            EmployeeDto dto = new()
            {
                FirstName = model.FirstName,        // Ad
                LastName = model.LastName,          // Soyad
                Position = model.Position,          // Pozisyon
                PhoneNumber = formattedPhone,       // Telefon numarası
                Address = model.Address,            // Adres
                BirthDate = model.BirthDate,        // Doğum tarihi
                Salary = model.Salary,              // Maaş
                Shift = randomShift,                // Rastgele seçilen vardiya
                HireDate = DateTime.Now,            // İşe giriş tarihi (şu an)
                CreatedDate = DateTime.Now,         // Oluşturulma zamanı
                Status = DataStatus.Inserted        // Varsayılan durum: Inserted
            };

            // Veritabanına kayıt işlemi yapılır
            await _employeeManager.CreateAsync(dto);

            // Kullanıcıya başarı mesajı gösterilmek üzere TempData’ya yazılır
            TempData["SuccessMessage"] = "Çalışan başarıyla eklendi.";

            // Listeleme ekranına yönlendirme yapılır
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
            // İlgili çalışan veritabanından alınır
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Çalışan bulunamazsa 404 döndürülür

            // Pozisyonlar dropdown için veritabanından DISTINCT olarak alınır
            List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
            ViewBag.Positions = new SelectList(positions);

            // DTO → RequestModel dönüşümü yapılır (formu doldurmak için)
            EmployeeUpdateRequestModel model = new()
            {
                Id = employee.Id,                                      // ID
                FirstName = employee.FirstName,                        // Ad
                LastName = employee.LastName,                          // Soyad
                Position = employee.Position,                          // Pozisyon
                PhoneNumber = employee.PhoneNumber?.Replace("+90", "0"), // +90 → 0 formatına çevrilir
                Salary = employee.Salary,                              // Maaş
                Address = employee.Address                             // Adres
            };

            // Güncelleme formu kullanıcıya gösterilir
            return View(model);
        }

        /// <summary>
        /// Çalışan bilgilerini günceller. Formdan gelen veriler doğrulanır ve DTO’ya dönüştürülerek kaydedilir.
        /// </summary>
        /// <param name="model">Kullanıcıdan gelen güncellenmiş çalışan verileri.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeUpdateRequestModel model)
        {
            // Model doğrulaması yapılır
            if (!ModelState.IsValid)
            {
                // Sayfa tekrar yükleneceği için pozisyonlar yeniden getirilir
                List<string> positions = await _employeeManager.GetDistinctPositionsAsync();
                ViewBag.Positions = new SelectList(positions);

                // Hatalı form tekrar gösterilir
                return View(model);
            }

            // Telefon numarası +90 formatına çevrilir (örnek: 0555... → +90555...)
            string formattedPhone = _employeeManager.FormatPhoneNumber(model.PhoneNumber);

            // RequestModel → DTO dönüşümü yapılır
            EmployeeDto dto = new()
            {
                Id = model.Id,                          // ID
                FirstName = model.FirstName,            // Ad
                LastName = model.LastName,              // Soyad
                Position = model.Position,              // Pozisyon
                PhoneNumber = formattedPhone,           // Telefon numarası
                Salary = model.Salary,                  // Maaş
                Address = model.Address,                // Adres
                ModifiedDate = DateTime.Now,            // Güncellenme zamanı
                Status = DataStatus.Updated             // Durum: Updated
            };

            // Veritabanında güncelleme işlemi yapılır
            await _employeeManager.UpdateAsync(dto);

            // Başarı mesajı kullanıcıya gösterilmek üzere gönderilir
            TempData["SuccessMessage"] = "Çalışan bilgileri güncellendi.";

            // Listeleme ekranına yönlendirilir
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
            // İlgili çalışan bilgisi veritabanından alınır
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Çalışan bulunamazsa 404 döner

            // Silme ekranına gönderilecek response modeli oluşturulur
            EmployeeDeleteResponseModel model = new()
            {
                Id = employee.Id,                      // ID
                FirstName = employee.FirstName,        // Ad
                LastName = employee.LastName,          // Soyad
                Position = employee.Position,          // Pozisyon
                PhoneNumber = employee.PhoneNumber     // Telefon numarası
                                                       // Email istenirse buraya eklenebilir
            };

            // Silme onay ekranı gösterilir (Delete.cshtml)
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
            // Silinecek çalışan yeniden alınır (veri tutarlılığı için)
            EmployeeDto employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound(); // Kayıt yoksa hata döner

            // Soft delete için gerekli DTO hazırlanır
            EmployeeDto dto = new()
            {
                Id = employee.Id,                      // ID
                Status = DataStatus.Deleted,           // Durum: Deleted
                DeletedDate = DateTime.Now             // Silinme zamanı
            };

            // Silme işlemi yapılır (MakePassiveAsync → Status = Deleted, DeletedDate set edilir)
            await _employeeManager.MakePassiveAsync(dto);

            // Kullanıcıya bilgi mesajı gönderilir
            TempData["SuccessMessage"] = "Çalışan silindi.";

            // Listeleme sayfasına yönlendirme yapılır
            return RedirectToAction("Index");
        }

        #endregion
    }
}