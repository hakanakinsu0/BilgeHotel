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
    /// BaseConfiguration<T>, veritabanı tablolarını yapılandırmak için kullanılan bir soyut (abstract) sınıftır.  
    /// Generic yapısı sayesinde yalnızca **IEntity** arayüzünü uygulayan sınıfların yapılandırılmasını sağlar.  
    /// Diğer yapılandırma sınıfları bu sınıftan türeyerek, ortak ayarları miras alabilir ve kendi özel konfigürasyonlarını ekleyebilir.  
    /// </summary>
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        /// <summary>
        /// Entity Framework Core tarafından çağrılan yapılandırma metodudur.
        /// Tüm entity sınıflarında ortak ayarlamaların yapılmasını sağlar.
        /// Türeyen sınıflar; burada tanimlanan virtual keywordu (pollymorphism prensibi) sayesinde, bu metodu override ederek ek konfigürasyonlar ekleyebilir.
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<T> builder) {}
    }
}
