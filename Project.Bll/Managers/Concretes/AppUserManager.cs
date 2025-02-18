using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDto, AppUser>, IAppUserManager
    {
        readonly IAppUserRepository _repository;
        public AppUserManager(IAppUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
