using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using Project.Entities.Models;

namespace Project.Bll.Mapping
{
    /// <summary>
    /// AutoMapper konfigürasyonlarının tanımlandığı sınıftır.
    /// Entity sınıfları ile DTO sınıfları arasındaki dönüşümleri tanımlar.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kullanıcı ve Kullanıcı Profili Maplemeleri
            CreateMap<AppUser, AppUserDto>().ReverseMap();                  // AppUser AppUserDto
            CreateMap<AppUserProfile, AppUserProfileDto>().ReverseMap();    // AppUserProfile AppUserProfileDto

            // Çalışan (Employee) Maplemesi
            CreateMap<Employee, EmployeeDto>().ReverseMap();                // Employee EmployeeDto

            // Oda (Room) Maplemesi
            CreateMap<Room, RoomDto>()
                
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name)) // RoomType nesnesi üzerinden gelen Name property'sini RoomTypeName alanına mapler
                .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.Reservations.Any(r => r.Status != DataStatus.Deleted && r.ReservationStatus != ReservationStatus.Canceled))) // Aktif rezervasyon varsa (Deleted değil ve Canceled değilse) IsReserved true olur
                .ReverseMap(); // RoomDto Room dönüşümünü de aktif eder

            // Oda Türü (RoomType) Maplemesi
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();        // RoomType RoomTypeDto

            // Rezervasyon, Ödeme ve Paket Maplemeleri
            CreateMap<Reservation, ReservationDto>().ReverseMap();  // Reservation ReservationDto
            CreateMap<Payment, PaymentDto>().ReverseMap();          // Payment PaymentDto
            CreateMap<Package, PackageDto>().ReverseMap();          // Package PackageDto

            // Yeni Eklenen Varlıklar
            CreateMap<ExtraService, ExtraServiceDto>().ReverseMap();// ExtraService ExtraServiceDto
            CreateMap<ReservationExtraService, ReservationExtraServiceDto>().ReverseMap(); // ReservationExtraService ReservationExtraServiceDto
        }
    }
}
