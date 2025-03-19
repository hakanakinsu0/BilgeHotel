using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class EmployeeManager : BaseManager<EmployeeDto, Employee>, IEmployeeManager
    {
        readonly IEmployeeRepository _repository;
        public EmployeeManager(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<int> GetRandomReceptionistEmployeeIdAsync()
        {
            var employees = await GetAllAsync(); // BaseManager üzerinden tüm çalışanlar alınıyor
            var receptionists = employees
                .Where(e => e.Position.Equals("Resepsiyonist"))
                .ToList();

            if (receptionists.Any())
            {
                var random = new Random();
                var randomEmployee = receptionists[random.Next(receptionists.Count)];
                return randomEmployee.Id;
            }
            return -1;
        }
    }
}
