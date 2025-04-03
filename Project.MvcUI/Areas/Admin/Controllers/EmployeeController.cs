using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Employees;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeManager.GetAllAsync();
            employees = employees.Where(e => e.Status != DataStatus.Deleted).ToList();

            var model = new EmployeeListResponseModel
            {
                Employees = employees.Select(e => new EmployeeListItemResponseModel
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Position = e.Position,
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateRequestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new EmployeeDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _employeeManager.CreateAsync(dto);
            TempData["SuccessMessage"] = "Çalışan başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound();

            var model = new EmployeeUpdateRequestModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeUpdateRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new EmployeeDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            await _employeeManager.UpdateAsync(dto);
            TempData["SuccessMessage"] = "Çalışan bilgileri güncellendi.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeManager.GetByIdAsync(id);
            if (employee == null) return NotFound();

            var dto = new EmployeeDto
            {
                Id = employee.Id,
                Status = DataStatus.Deleted,
                DeletedDate = DateTime.Now
            };

            await _employeeManager.MakePassiveAsync(dto);
            TempData["SuccessMessage"] = "Çalışan silindi.";
            return RedirectToAction("Index");
        }
    }
}