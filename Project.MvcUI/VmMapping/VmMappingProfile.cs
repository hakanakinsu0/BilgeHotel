using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.AppUsers;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;

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
            CreateMap<ReservationCreateRequestModel, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>();


            // ✅ Admin Paneli Kullanıcı Yönetimi
            CreateMap<UserViewResponseModel, AppUserDto>().ReverseMap();
            CreateMap<CreateUserRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UpdateUserRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UserListResponseModel, AppUserDto>().ReverseMap();

            // ✅ Admin Paneli Rezervasyon Yönetimi
            CreateMap<ReservationDto, ReservationListRequestModel>().ReverseMap();
            CreateMap<ReservationListResponseModel, ReservationDto>().ReverseMap();

            CreateMap<RoomCreateRequestModel, RoomDto>().ReverseMap();
            CreateMap<RoomDto, RoomUpdateRequestModel>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.RoomStatus, opt => opt.Ignore()); 



        }
    }
}
