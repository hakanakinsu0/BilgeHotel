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
    public class EmployeeShiftManager : BaseManager<EmployeeShiftDto, EmployeeShift>, IEmployeeShiftManager
    {
        readonly IEmployeeShiftRepository _repository;
        public EmployeeShiftManager(IEmployeeShiftRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
