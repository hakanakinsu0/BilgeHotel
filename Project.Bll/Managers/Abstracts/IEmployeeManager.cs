using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IEmployeeManager : IManager<EmployeeDto, Employee>
    {
        /// <summary>
        /// "Resepsiyonist" pozisyonundaki çalışanlar arasından rastgele bir çalışan ID'si döner.
        /// Eğer böyle bir çalışan bulunamazsa null döner.
        /// </summary>
        Task<int> GetRandomReceptionistEmployeeIdAsync();
    }
}
