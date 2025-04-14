using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.MvcUI.Areas.Admin.Models.PageVms.Inventory;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Inventory;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Inventory;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryItemManager _inventoryManager;
        private readonly IEmployeeManager _employeeManager;

        public InventoryController(IInventoryItemManager inventoryManager, IEmployeeManager employeeManager)
        {
            _inventoryManager = inventoryManager;
            _employeeManager = employeeManager;
        }

        #region InventoryIndexAction              

        /// <summary>
        /// Donanım envanter listesini görüntüler.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            List<InventoryItemDto> dtoList = await _inventoryManager.GetAllAsync();

            InventoryPageVm pageVm = new InventoryPageVm
            {
                InventoryItems = dtoList.Select(x => new InventoryItemListItemResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SerialNumber = x.SerialNumber,
                    Location = x.Location,
                    Category = x.Category,
                    Description = x.Description,
                    EmployeeFullName = x.EmployeeFullName,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate
                }).ToList()
            };

            return View(pageVm);
        }

        #endregion

        #region InventoryCreateAction

        /// <summary>
        /// Yeni donanım ekleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            await LoadEmployeeSelectListAsync();
            return View();
        }

        /// <summary>
        /// Yeni donanım kayıt işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryItemCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadEmployeeSelectListAsync();
                return View(model);
            }

            InventoryItemDto dto = new()
            {
                Name = model.Name,
                SerialNumber = model.SerialNumber,
                Location = model.Location,
                Description = model.Description,
                Category = model.Category,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.Now,
                Status = Project.Entities.Enums.DataStatus.Inserted
            };

            await _inventoryManager.CreateAsync(dto);

            TempData["SuccessMessage"] = "Donanım başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region InventoryEditAction

        /// <summary>
        /// Güncellenecek donanımın bilgilerini getirir ve formu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            InventoryItemDto dto = await _inventoryManager.GetByIdAsync(id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Donanım bulunamadı.";
                return RedirectToAction("Index");
            }

            InventoryItemUpdateRequestModel model = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                SerialNumber = dto.SerialNumber,
                Location = dto.Location,
                Description = dto.Description,
                Category = dto.Category,
                EmployeeId = dto.EmployeeId
            };

            await LoadEmployeeSelectListAsync();
            return View(model);
        }

        /// <summary>
        /// Donanım bilgilerini günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InventoryItemUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadEmployeeSelectListAsync();
                return View(model);
            }

            InventoryItemDto dto = await _inventoryManager.GetByIdAsync(model.Id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Donanım bulunamadı.";
                return RedirectToAction("Index");
            }

            dto.Name = model.Name;
            dto.SerialNumber = model.SerialNumber;
            dto.Location = model.Location;
            dto.Description = model.Description;
            dto.Category = model.Category;
            dto.EmployeeId = model.EmployeeId;
            dto.Status = Project.Entities.Enums.DataStatus.Updated;

            await _inventoryManager.UpdateAsync(dto);

            TempData["SuccessMessage"] = "Donanım başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region InventoryDeleteAction

        /// <summary>
        /// Donanım silme onay ekranını görüntüler.
        /// </summary>
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            InventoryItemDto dto = await _inventoryManager.GetByIdAsync(id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Donanım bulunamadı.";
                return RedirectToAction("Index");
            }

            InventoryItemListItemResponseModel model = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                SerialNumber = dto.SerialNumber,
                Location = dto.Location,
                Category = dto.Category,
                Description = dto.Description,
                EmployeeFullName = dto.EmployeeFullName,
                Status = dto.Status,
                CreatedDate = dto.CreatedDate
            };

            return View(model);
        }

        /// <summary>
        /// Donanımı siler (status bilgisini Deleted yapar).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            InventoryItemDto dto = await _inventoryManager.GetByIdAsync(id);
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Donanım bulunamadı.";
                return RedirectToAction("Index");
            }

            dto.Status = Project.Entities.Enums.DataStatus.Deleted;

            await _inventoryManager.UpdateAsync(dto);

            TempData["SuccessMessage"] = "Donanım başarıyla silindi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region ControllerPrivateMethods

        /// <summary>
        /// Çalışanları dropdown list için ViewBag'e yükler.
        /// </summary>
        private async Task LoadEmployeeSelectListAsync()
        {
            var allEmployees = await _employeeManager.GetAllAsync();
            ViewBag.EmployeeList = allEmployees.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FirstName + " " + x.LastName
            }).ToList();
        }

        #endregion
    }
}