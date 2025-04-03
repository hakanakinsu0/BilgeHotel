using Project.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Otelde yapılan rezervasyonların temel bilgilerini taşıyan DTO sınıfıdır.
    /// Bu sınıf; rezervasyon tarihleri, toplam fiyat, oda, paket, çalışan ve müşteri bilgilerini,
    /// ayrıca rezervasyona eklenen ekstra hizmetleri içerir.
    /// </summary>
    public class ReservationDto : BaseDto
    {
        public DateTime StartDate { get; set; }                             // Rezervasyon başlangıç tarihi
        public DateTime EndDate { get; set; }                               // Rezervasyon bitiş tarihi
        public decimal TotalPrice { get; set; }                             // Rezervasyon toplam fiyatı
        public int RoomId { get; set; }                                     // Rezerve edilen oda ID'si
        public int? PackageId { get; set; }                                 // Seçilen paket ID'si (varsa)
        public int? EmployeeId { get; set; }                                // Rezervasyonu yöneten çalışan ID'si (varsa)
        public string CustomerName { get; set; }                            // Müşteri adı (AppUser'dan çekilecek)
        public string CustomerEmail { get; set; }                           // Müşteri e-posta adresi (AppUser'dan çekilecek)
        public string RoomNumber { get; set; }                              // Rezerve edilen odanın numarası
        public ReservationStatus ReservationStatus { get; set; }            // Rezervasyonun durumu (örn. Pending, Confirmed, Canceled)
        public DataStatus Status { get; set; }                              // Rezervasyonun veri durumu (Inserted, Updated, Deleted)
        public List<ReservationExtraServiceDto> ExtraServices { get; set; } // Rezervasyona eklenen ekstra hizmetlerin listesi
        public int? AppUserId { get; set; }                                 // Rezervasyonu yapan kullanıcının ID'si (varsa)
    }
}
