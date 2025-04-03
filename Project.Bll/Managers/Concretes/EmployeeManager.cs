using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// Employee işlemleri için iş mantığını yöneten manager sınıfıdır.
    /// Temel CRUD işlemleri BaseManager üzerinden sağlanır.
    /// </summary>
    public class EmployeeManager : BaseManager<EmployeeDto, Employee>, IEmployeeManager
    {
        readonly IEmployeeRepository _repository;
        public EmployeeManager(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Sistemdeki "Resepsiyonist" pozisyonundaki çalışanlar arasından rastgele birinin ID’sini döner.
        /// Eğer hiç resepsiyonist yoksa -1 döner.
        /// </summary>
        /// <returns>Rastgele seçilen resepsiyonistin ID'si ya da -1.</returns>
        public async Task<int> GetRandomReceptionistEmployeeIdAsync()
        {
            List<EmployeeDto> employees = await GetAllAsync(); // Tüm çalışanları getiriyoruz.
            
            List<EmployeeDto> receptionists = employees.Where(e => e.Position.Equals("Resepsiyonist")).ToList(); // Sadece "Resepsiyonist" pozisyonunda olanları filtreliyoruz.

            // Eğer resepsiyonist varsa rastgele bir ID döndür.
            if (receptionists.Any())
            {
                Random random = new();
                EmployeeDto randomEmployee = receptionists[random.Next(receptionists.Count)];
                return randomEmployee.Id;
            }
            return -1; // Resepsiyonist bulunamadıysa -1 döndür.
        }

        public async Task<List<string>> GetDistinctPositionsAsync()
        {
            return await _repository.GetDistinctPositionsAsync();
        }

        public string FormatPhoneNumber(string rawPhone)
        {
            if (string.IsNullOrWhiteSpace(rawPhone))
                return null;

            return "+9" + rawPhone.Trim(); // 05554443322 → +905554443322
        }

        public ShiftType GetRandomShift()
        {
            return Enum.GetValues<ShiftType>()
                       .Cast<ShiftType>()
                       .OrderBy(x => Guid.NewGuid())
                       .First();
        }

    }
}
