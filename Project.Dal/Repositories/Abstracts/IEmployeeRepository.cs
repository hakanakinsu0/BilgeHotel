using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Çalışanlar (Employee) için veri erişim işlemlerini yöneten repository interfacei.
    /// Tüm temel CRUD işlemleri `IRepository<Employee>` aracılığıyla sağlanır.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee> 
    {
        /// <summary>
        /// Veritabanındaki tüm çalışanlar arasında tekrarsız (distinct) pozisyonları getirir.
        /// Bu metot, sistemde tanımlı olan benzersiz pozisyonların listesini elde etmek için kullanılır.
        /// Örneğin: "Resepsiyonist", "Garson", "Aşçı", vb. gibi farklı görev tanımlarını döndürür.
        /// </summary>
        /// <returns>Çalışan pozisyonlarını içeren string türünde bir liste.</returns>
        Task<List<string>> GetDistinctPositionsAsync();
    }
}
