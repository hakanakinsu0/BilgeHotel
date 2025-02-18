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
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerDetail, CustomerDetailDto>().ReverseMap();

            // Çalışanlar ve Detayları
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeDetail, EmployeeDetailDto>().ReverseMap();
            CreateMap<EmployeeShift, EmployeeShiftDto>().ReverseMap();

            // Oda ve Özellikleri
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<RoomFeature, RoomFeatureDto>().ReverseMap();

            // Rezervasyon, Ödeme ve Paketler
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();

            // Vardiya
            CreateMap<Shift, ShiftDto>().ReverseMap();
        }
    }
}
