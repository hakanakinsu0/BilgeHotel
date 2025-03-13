using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Configuration.Options;
using Project.Dal.BogusHandling;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.ContextClasses
{
    /// <summary>
    /// Veritabanı ile bağlantıyı yöneten DbContext sınıfıdır.
    /// IdentityDbContext'ten miras alarak kullanıcı (AppUser), roller (AppRole) ve kimlik doğrulama işlemlerini yönetir.
    /// </summary>
    public class MyContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        /// <summary>
        /// MyContext constructor'ı, dışarıdan gelen DbContextOptions ile başlatılır.
        /// </summary>
        /// <param name="opt">Veritabanı bağlantı seçenekleri</param>
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

        /// <summary>
        /// Veritabani konfigurasyon ayarlamalari uygulanir.
        /// Tüm entity'lerin yapılandırmaları ApplyConfiguration() ile yüklenir.
        /// </summary>
        /// <param name="builder">Model yapılandırması</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Identity ile ilgili varsayılan konfigürasyonları uygular

            // Tüm entity'lerin konfigürasyonları burada çağrılır
            builder.ApplyConfiguration(new AppUserConfiguration());                 // Kullanıcı ayarları
            builder.ApplyConfiguration(new AppUserProfileConfiguration());          // Kullanıcı profil ayarları
            builder.ApplyConfiguration(new EmployeeConfiguration());                // Çalışan ayarları
            builder.ApplyConfiguration(new PackageConfiguration());                 // Konaklama paket ayarları
            builder.ApplyConfiguration(new PaymentConfiguration());                 // Ödeme ayarları
            builder.ApplyConfiguration(new ReservationConfiguration());             // Rezervasyon ayarları
            builder.ApplyConfiguration(new RoomConfiguration());                    // Oda ayarları
            builder.ApplyConfiguration(new RoomTypeConfiguration());                // Oda türleri ayarları
            builder.ApplyConfiguration(new ExtraServiceConfiguration());            // Ekstra hizmet ayarları
            builder.ApplyConfiguration(new ReservationExtraServiceConfiguration()); // Ekstra hizmet-rezervasyon ilişkisi

            // Seed (Başlangıç) Verileri Burada Çağrılır
            RoomTypeSeed.SeedRoomTypes(builder);
            RoomSeed.SeedRooms(builder);
            EmployeeSeed.SeedEmployees(builder);
            UserAndRoleSeed.SeedUsersAndRoles(builder);
            PackageSeed.SeedPackages(builder);
            ExtraServiceSeed.SeedExtraServices(builder);

        }

        // Veritabanı Tabloları
        public DbSet<AppUser> AppUsers { get; set; }               // Kullanıcılar
        public DbSet<AppUserProfile> AppUserProfiles { get; set; } // Kullanıcı Profilleri
        public DbSet<Employee> Employees { get; set; }             // Çalışanlar
        public DbSet<ExtraService> ExtraServices { get; set; }     // Ekstra Hizmetler
        public DbSet<Package> Packages { get; set; }               // Konaklama Paketleri
        public DbSet<Payment> Payments { get; set; }               // Ödemeler
        public DbSet<Reservation> Reservations { get; set; }       // Rezervasyonlar
        public DbSet<ReservationExtraService> ReservationExtraServices { get; set; } // Ekstra Hizmet - Rezervasyon Junction Tablosu
        public DbSet<Room> Rooms { get; set; }                     // Odalar
        public DbSet<RoomType> RoomTypes { get; set; }             // Oda Türleri


    }
}
