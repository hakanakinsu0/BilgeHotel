using AutoMapper;
using Project.Bll.DtoClasses;
using Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.ReservationModels;
using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.ReservationModels;

namespace Project.MvcUI.VmMapping
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile() 
        {
            // **Rezervasyon Mapping**
            CreateMap<ReservationRequestModel, ReservationDto>().ReverseMap();
            CreateMap<ReservationUpdateRequestModel, ReservationDto>().ReverseMap();
            CreateMap<ReservationCancelRequestModel, ReservationDto>().ReverseMap();
            CreateMap<ReservationDto, ReservationResponseModel>().ReverseMap();
        }
    }
}
