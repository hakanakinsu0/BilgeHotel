using System.Threading.Tasks;
using Project.Bll.DtoClasses;
using Project.Entities.Models;

namespace Project.Bll.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUserDto, AppUser>
    {
        Task<AppUserDto> GetUserProfileAsync(int userId); // Kullanıcı Profilini Getir
        Task<bool> UpdateUserProfileAsync(AppUserDto userDto); // Kullanıcı Profilini Güncelle
        Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword);

        //

        Task<int> GetTotalUserCountAsync();
        Task<int> GetActiveUserCountAsync();



    }
}
