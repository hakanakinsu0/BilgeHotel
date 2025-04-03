using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Çalışan işlemlerine yönelik genel CRUD ve özel operasyonları tanımlayan arayüzdür.
    /// Bu arayüz, çalışanlar için IManager arayüzünü genişleterek, "Resepsiyonist" pozisyonundaki çalışanlar arasından
    /// rastgele bir çalışan ID'si döndürme gibi ek işlevleri içerir.
    /// </summary>
    public interface IEmployeeManager : IManager<EmployeeDto, Employee>
    {
        /// <summary>
        /// "Resepsiyonist" pozisyonundaki çalışanlar arasından rastgele bir çalışan ID'si döndürür.
        /// Eğer böyle bir çalışan bulunamazsa null döner.
        /// </summary>
        /// <returns>"Resepsiyonist" pozisyonundaki çalışan ID'si veya bulunamazsa null.</returns>
        Task<int> GetRandomReceptionistEmployeeIdAsync();
        Task<List<string>> GetDistinctPositionsAsync();

    }
}
