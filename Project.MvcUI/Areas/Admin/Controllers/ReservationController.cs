using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.MvcUI.Areas.Admin.Models.PageVms;
using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.ReservationModels;
using System.Threading.Tasks;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly IMapper _mapper;

        public ReservationController(IReservationManager reservationManager, IMapper mapper)
        {
            _reservationManager = reservationManager;
            _mapper = mapper;
        }

        // **📌 Rezervasyonları Listeleme (Index)**
        public async Task<IActionResult> Index()
        {
            List<ReservationDto> reservations = await _reservationManager.GetAllAsync();
            ReservationPageVm model = new ReservationPageVm
            {
                Reservations = _mapper.Map<List<ReservationResponseModel>>(reservations)
            };

            return View(model);
        }
    }
}