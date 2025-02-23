using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;

namespace Project.MvcUI.VmMapping
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            // Kullanıcı Profili Mapping
            CreateMap<AppUser, UserProfileUpdateRequestModel>().ReverseMap();
            CreateMap<UserProfileUpdateRequestModel, AppUserDto>().ReverseMap();
            CreateMap<UserProfileResponseModel, AppUserDto>().ReverseMap();
            CreateMap<UserProfileUpdateRequestModel, AppUserProfile>().ReverseMap();

            CreateMap<UserChangePasswordRequestModel, AppUserDto>().ReverseMap();
        }
    }
}
