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
        /// "Resepsiyonist" pozisyonunda bulunan çalışanlar arasından rastgele bir çalışanın ID'sini getirir.
        /// Eğer uygun çalışan bulunamazsa null döner.
        /// </summary>
        /// <returns>Rastgele bir resepsiyonistin ID'si veya null</returns>
        Task<int> GetRandomReceptionistEmployeeIdAsync();

        /// <summary>
        /// Veritabanındaki tüm aktif çalışanlar içerisinden tekrarsız pozisyonları listeler.
        /// UI tarafında filtreleme ve dropdown için kullanılabilir.
        /// </summary>
        /// <returns>Distinct pozisyon isimlerini içeren liste</returns>
        Task<List<string>> GetDistinctPositionsAsync();

        /// <summary>
        /// Verilen telefon numarasını sistemin beklediği formatta standart hale getirir.
        /// Örn: "05551112233" → "+905551112233"
        /// </summary>
        /// <param name="rawPhone">Formatlanmamış ham telefon numarası</param>
        /// <returns>Formatlanmış (örneğin uluslararası standartta) telefon numarası</returns>
        string FormatPhoneNumber(string rawPhone);

        /// <summary>
        /// Rastgele bir vardiya türü (ShiftType) döndürür.
        /// Genellikle test amaçlı çalışan üretimi veya otomatik atamalarda kullanılır.
        /// </summary>
        /// <returns>ShiftType enum'undan rastgele bir değer</returns>
        ShiftType GetRandomShift();
    }
}
