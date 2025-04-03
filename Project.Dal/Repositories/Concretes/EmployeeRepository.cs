using Microsoft.EntityFrameworkCore;
using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    /// <summary>
    /// Çalışanlar (Employee) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<Employee>` aracılığıyla sağlanır.
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// `EmployeeRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public EmployeeRepository(MyContext context) : base(context) { }

        public async Task<List<string>> GetDistinctPositionsAsync()
        {
            return await _context.Employees
                      .Where(e => e.Status != DataStatus.Deleted)
                      .Select(e => e.Position)
                      .Distinct()
                      .ToListAsync();
        }
    }
}
