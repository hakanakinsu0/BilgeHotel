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
    }
}
