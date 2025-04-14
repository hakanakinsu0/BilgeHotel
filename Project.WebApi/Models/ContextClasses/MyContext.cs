using Microsoft.EntityFrameworkCore;
using NetCoreBank.Models.SeedHandling;
using Project.WebApi.Models.Entities;

namespace Project.WebApi.Models.ContextClasses
{
    /// <summary>
    /// WebApi projesinde kullanılan EF Core DbContext sınıfıdır.
    /// Veritabanı bağlantısı, tablolar ve seed işlemleri bu sınıf üzerinden yönetilir.
    /// </summary>
    public class MyContext : DbContext
    {
        /// <summary>
        /// DI üzerinden gelen DbContextOptions ile context yapılandırması yapılır.
        /// </summary>
        /// <param name="opt">Bağlantı ayarlarını içeren seçenekler</param>
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }

        /// <summary>
        /// Veritabanı tablolarının yapılandırılması ve seed işlemleri burada yapılır.
        /// </summary>
        /// <param name="modelBuilder">Model oluşturan yapılandırma sınıfı</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sahte kart verileri ekleniyor (seed işlemi)
            UserCardInfoSeed.SeedUserCard(modelBuilder);
        }

        /// <summary>
        /// Kart bilgilerini temsil eden veritabanı tablosudur.
        /// </summary>
        public DbSet<UserCardInfo> CardInfoes { get; set; }
    }
}
