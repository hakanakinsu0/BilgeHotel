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
        /// Fluent API kullanılarak veritabanı konfigürasyonlarını uygular.
        /// Tüm entity'lerin yapılandırmaları ApplyConfiguration() ile yüklenir.
        /// </summary>
        /// <param name="builder">Model yapılandırması</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Identity ile ilgili varsayılan konfigürasyonları uygular

            // **Tüm entity'lerin konfigürasyonları burada çağrılıyor**
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppUserProfileConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerDetailConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeDetailConfiguration());
            builder.ApplyConfiguration(new EmployeeShiftConfiguration());
            builder.ApplyConfiguration(new FeatureConfiguration());
            builder.ApplyConfiguration(new PackageConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new RoomFeatureConfiguration());
            builder.ApplyConfiguration(new RoomTypeConfiguration());
            builder.ApplyConfiguration(new ShiftConfiguration());

            RoomTypeSeed.SeedRoomTypes(builder);
            RoomSeed.SeedRooms(builder);
            EmployeeSeed.SeedEmployees(builder);
            UserAndRoleSeed.SeedUsersAndRoles(builder);
        }

        // **Veritabanı Tabloları**
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }


    }
}
