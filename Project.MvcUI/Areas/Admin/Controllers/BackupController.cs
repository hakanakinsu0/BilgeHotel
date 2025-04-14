using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Common.Tools;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.PageVms.Backups;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Backups;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Backups;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BackupController : Controller
    {
        private readonly IDatabaseBackupLogManager _backupManager;
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public BackupController(IDatabaseBackupLogManager backupManager, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _backupManager = backupManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        #region BackupIndexAction

        /// <summary>
        /// Tüm yedek geçmişini listeler. ViewModel dönüşümü yapılır.
        /// </summary>
        public async Task<IActionResult> Index()

        {
            List<DatabaseBackupLogDto> dtoList = await _backupManager.GetAllBackupsOrderedAsync();

            BackupPageVm pageVm = new BackupPageVm
            {
                BackupList = dtoList.Select(x => new BackupListItemResponseModel
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    FilePath = x.FilePath,
                    UserName = x.UserName,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status

                }).ToList(),
                HelpText = "Aşağıda yedek geçmişinizi görebilirsiniz."
            };

            return View(pageVm);
        }

        #endregion

        #region BackupCreateAction

        /// <summary>
        /// Yedek oluşturma sayfasını görüntüler 
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Veritabanı yedeğini oluşturur, fiziksel olarak diske yazar ve veritabanına log kaydeder.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BackupCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen klasör yolu giriniz.";
                return View(model);
            }

            try
            {
                // Bağlantı cümlesi ve veritabanı adı
                string connectionString = _configuration.GetConnectionString("MyConnection")!;
                string databaseName = "BilgeHotelDb";

                // BackupHelper ile yedek oluştur
                string backupFilePath = DatabaseBackupHelper.CreateDatabaseBackup(connectionString, model.TargetFolderPath, databaseName);

                // Oturumdaki kullanıcı bilgisi
                AppUser currentUser = await _userManager.GetUserAsync(User);

                // Dosya adı ayrıştır
                string fileName = Path.GetFileName(backupFilePath);

                //  Veritabanına log ekle
                DatabaseBackupLogDto dto = new()
                {
                    FilePath = backupFilePath,
                    FileName = fileName,
                    AppUserId = currentUser.Id,
                    CreatedDate = DateTime.Now,
                    Status = Project.Entities.Enums.DataStatus.Inserted,
                    UserName = currentUser.UserName
                };

                await _backupManager.CreateAsync(dto);

                TempData["SuccessMessage"] = "Yedekleme başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Yedekleme sırasında hata oluştu: {ex.Message}";
                return View(model);
            }
        }

        #endregion

        #region BackupDeleteAction

        /// <summary>
        /// Silme onayı sayfasını gösterir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            DatabaseBackupLogDto dto = await _backupManager.GetByIdAsync(id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Yedek kaydı bulunamadı.";
                return RedirectToAction("Index");
            }

            BackupListItemResponseModel model = new()
            {
                Id = dto.Id,
                FileName = dto.FileName,
                CreatedDate = dto.CreatedDate,
                UserName = dto.UserName,
                Status = dto.Status
            };

            return View(model);
        }

        /// <summary>
        /// Onaylandıktan sonra yedek dosyasını siler ve log kaydını pasife çeker.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DatabaseBackupLogDto dto = await _backupManager.GetByIdAsync(id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Yedek kaydı bulunamadı.";
                return RedirectToAction("Index");
            }

            try
            {
                if (System.IO.File.Exists(dto.FilePath))
                {
                    System.IO.File.Delete(dto.FilePath);
                }

                await _backupManager.MakePassiveAsync(dto);
                TempData["SuccessMessage"] = "Yedekleme başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Silme sırasında hata oluştu: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
