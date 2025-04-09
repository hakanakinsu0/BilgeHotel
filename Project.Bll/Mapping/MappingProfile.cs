using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using Project.Entities.Models;

namespace Project.Bll.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kullanıcı ve Profil Ayrımı Yapıldı
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUserProfile, AppUserProfileDto>().ReverseMap();

            // Çalışanlar
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            // Oda ve Özellikleri
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
                .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src =>
                    src.Reservations.Any(r =>
                        r.Status != DataStatus.Deleted &&
                        r.ReservationStatus != ReservationStatus.Canceled)));

            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

            // Rezervasyon, Ödeme ve Paketler
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();

            // Yeni Eklenenler
            CreateMap<ExtraService, ExtraServiceDto>().ReverseMap();
            CreateMap<ReservationExtraService, ReservationExtraServiceDto>().ReverseMap();
        }
    }
}
