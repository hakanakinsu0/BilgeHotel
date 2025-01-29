using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    /// <summary>
    /// Tüm entity yapılandırmalarının temelini oluşturan soyut (abstract) sınıf.
    /// Bu sınıf, IEntityTypeConfiguration<T> arayüzünü uygular ve Entity Framework Core'un Fluent API ayarlarını yönetmek için kullanılır.
    ///  
    /// **Türkçe Açıklama:**  
    /// BaseConfiguration<T>, veritabanı tablolarını yapılandırmak için kullanılan bir temel sınıftır.  
    /// Generic yapısı sayesinde yalnızca **IEntity** arayüzünü uygulayan sınıfların yapılandırılmasını sağlar.  
    /// Diğer yapılandırma sınıfları bu sınıftan türeyerek, ortak ayarları miras alabilir ve kendi özel konfigürasyonlarını ekleyebilir.  
    /// </summary>
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        /// <summary>
        /// Entity Framework Core tarafından çağrılan yapılandırma metodudur.
        /// Tüm entity sınıflarında ortak ayarlamaların yapılmasını sağlar.
        /// Türeyen sınıflar, bu metodu override ederek ek konfigürasyonlar ekleyebilir.
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
