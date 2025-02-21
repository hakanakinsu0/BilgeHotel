using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Bll.Mapping
{
    /// <summary>
    /// AutoMapper kullanarak entity'ler ile DTO'lar arasında dönüşümleri yöneten profil sınıfı.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kullanıcı ve Rol
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUserProfile, AppUserProfileDto>().ReverseMap();


            // Müşteri ve Detayları

            // Çalışanlar ve Detayları
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            // Oda ve Özellikleri
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

            // Rezervasyon, Ödeme ve Paketler
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();

            // Vardiya
        }
    }
}
