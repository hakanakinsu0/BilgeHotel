using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class ReservationExtraServiceManager : BaseManager<ReservationExtraServiceDto, ReservationExtraService>, IReservationExtraServiceManager
    {
        readonly IReservationExtraServiceRepository _repository;

        public ReservationExtraServiceManager(IReservationExtraServiceRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
