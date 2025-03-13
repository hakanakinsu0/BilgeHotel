using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models;
using Project.MvcUI.Areas.Admin.Models.RequestModels;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;

namespace Project.MvcUI.VmMapping
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            // ✅ Kullanıcı Profili Mapping
            CreateMap<AppUser, UserProfileUpdateRequestModel>().ReverseMap();
            CreateMap<UserProfileUpdateRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UserProfileResponseModel, AppUserDto>().ReverseMap();
            CreateMap<UserProfileUpdateRequestModel, AppUserProfile>().ReverseMap();
            CreateMap<UserChangePasswordRequestModel, AppUserDto>().ReverseMap();
            CreateMap<ReservationDto, Reservation>().ReverseMap();

            // ✅ Admin Paneli Kullanıcı Yönetimi
            CreateMap<UserViewModel, AppUserDto>().ReverseMap();
            CreateMap<CreateUserRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UpdateUserRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UserListResponseModel, AppUserDto>().ReverseMap();

            // ✅ Admin Paneli Rezervasyon Yönetimi
            CreateMap<ReservationDto, ReservationListRequestModel>().ReverseMap();
            CreateMap<ReservationListResponseModel, ReservationDto>().ReverseMap();
        }
    }
}
