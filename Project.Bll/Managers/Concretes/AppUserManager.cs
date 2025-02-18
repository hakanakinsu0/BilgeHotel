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
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserManager(IAppUserRepository repository, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
            : base(repository, mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<bool> IsUserNameTakenAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null;
        }
    }
}
