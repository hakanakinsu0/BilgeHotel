using Project.Bll.DtoClasses;
using Project.Entities.Enums;
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

        /// <summary>
        /// Telefon numarasını veritabanına uygun şekilde formatlar. (örn: 0555... → +90555...)
        /// </summary>
        /// <param name="rawPhone">Ham telefon numarası</param>
        /// <returns>Formatlanmış telefon numarası</returns>
        string FormatPhoneNumber(string rawPhone);

        /// <summary>
        /// Rastgele bir ShiftType (vardiya türü) döner.
        /// </summary>
        /// <returns>ShiftType enum'undan rastgele değer</returns>
        ShiftType GetRandomShift();
    }
}
