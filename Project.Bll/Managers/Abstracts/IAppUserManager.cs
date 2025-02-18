using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project.Bll.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUserDto, AppUser>
    {
     
    }
}



