using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;

namespace Project.Bll.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kullanıcı ve Profil
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUserProfile, AppUserProfileDto>().ReverseMap();

            // Çalışanlar
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            // Oda ve Özellikleri
            CreateMap<Room, RoomDto>().ReverseMap();

            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

            // Rezervasyon, Ödeme ve Paketler
            CreateMap<Reservation, ReservationDto>();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();

            // Yeni Eklenenler
            CreateMap<ExtraService, ExtraServiceDto>().ReverseMap();
            CreateMap<ReservationExtraService, ReservationExtraServiceDto>().ReverseMap();
        }
    }
}
