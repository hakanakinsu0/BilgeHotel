﻿using AutoMapper;
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

            // Ekstra Hizmet (ExtraService) ve Rezervasyon Ekstra Hizmet (ReservationExtraService) Maplemeleri
            CreateMap<ExtraService, ExtraServiceDto>().ReverseMap();// ExtraService ExtraServiceDto
            CreateMap<ReservationExtraService, ReservationExtraServiceDto>().ReverseMap(); // ReservationExtraService ReservationExtraServiceDto

            // Database Yedekleme Log (DatabaseBackupLog) Maplemeleri
            CreateMap<DatabaseBackupLog, DatabaseBackupLogDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName)); // AppUser nesnesi üzerinden gelen UserName property'ini UserName alanına mapler
            CreateMap<DatabaseBackupLogDto, DatabaseBackupLog>().ForMember(dest => dest.AppUser, opt => opt.Ignore()); // AppUser alanını yok sayar, çünkü DatabaseBackupLogDto'da AppUser nesnesi yoktur

            // Yedekleme Log (BackupLog) Maplemeleri
            CreateMap<InventoryItem, InventoryItemDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName))
                .ForMember(dest => dest.EmployeePosition, opt => opt.MapFrom(src => src.Employee.Position)); // Employee nesnesi üzerinden gelen FirstName ve LastName property'lerini EmployeeFullName alanına mapler
            CreateMap<InventoryItemDto, InventoryItem>().ForMember(dest => dest.Employee, opt => opt.Ignore()); // Employee alanını yok sayar, çünkü InventoryItemDto'da Employee nesnesi yoktur
        }
    }
}
