using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class ExtraServiceManager : BaseManager<ExtraServiceDto, ExtraService>, IExtraServiceManager
    {
        readonly IExtraServiceRepository _repository;

        public ExtraServiceManager(IExtraServiceRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
