using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDto, AppUser>, IAppUserManager
    {
        private readonly IAppUserRepository _repository;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppUserManager(
            IAppUserRepository repository,
            IAppUserProfileManager appUserProfileManager,
            IMapper mapper,
            UserManager<AppUser> userManager)
            : base(repository, mapper)
        {
            _repository = repository;
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                user.ModifiedDate = DateTime.Now;
                user.Status = DataStatus.Updated;

                await _repository.UpdateAsync(user, user);
                return true;
            }

            return false;
        }

        public async Task<AppUserDto> GetUserProfileAsync(int userId)
        {
            var user = await _repository.GetByIdAsync(userId);

            // Kullanıcının profil bilgilerini ayrıca çekelim
            var userProfile = await _appUserProfileManager.GetByIdAsync(userId);

            if (user == null) return null;

            var userDto = _mapper.Map<AppUserDto>(user);

            // **Profil Bilgilerini Manuel Olarak Ekleyelim**
            if (user.AppUserProfile != null)
            {
                userDto.FirstName = user.AppUserProfile.FirstName;
                userDto.LastName = user.AppUserProfile.LastName;
                userDto.Address = user.AppUserProfile.Address;
                userDto.Gender = user.AppUserProfile.Gender;
                userDto.Nationality = user.AppUserProfile.Nationality;
                userDto.IdentityNumber = user.AppUserProfile.IdentityNumber; // **TC Kimlik No**

            }

            return userDto;
        }

        public async Task<bool> UpdateUserProfileAsync(AppUserDto userDto)
        {
            var user = await _repository.GetByIdAsync(userDto.Id);

            if (user == null) return false;

            // **AppUser Güncelleme**
            _mapper.Map(userDto, user);
            user.NormalizedEmail = userDto.Email.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.ModifiedDate = DateTime.Now;
            user.Status = DataStatus.Updated; // **AppUser Güncellendi**

            // **AppUserProfile Güncelleme veya Yeni Ekleme**
            if (user.AppUserProfile != null)
            {
                user.AppUserProfile.FirstName = userDto.FirstName;
                user.AppUserProfile.LastName = userDto.LastName;
                user.AppUserProfile.Address = userDto.Address;
                user.AppUserProfile.Gender = userDto.Gender;
                user.AppUserProfile.Nationality = userDto.Nationality;
                user.AppUserProfile.IdentityNumber = userDto.IdentityNumber; // **TC Kimlik No**
                user.AppUserProfile.ModifiedDate = DateTime.Now;
                user.AppUserProfile.Status = DataStatus.Updated; // **Mevcut Profil Güncellendi**

                // **Profil Güncelleme**
                await _appUserProfileManager.UpdateAsync(_mapper.Map<AppUserProfileDto>(user.AppUserProfile));
            }
            else
            {
                var newProfile = new AppUserProfileDto
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Address = userDto.Address,
                    Gender = userDto.Gender,
                    Nationality = userDto.Nationality,
                    IdentityNumber = userDto.IdentityNumber, // **TC Kimlik No**
                    AppUserId = userDto.Id,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted // **Yeni Profil Eklendi**
                };

                await _appUserProfileManager.CreateAsync(newProfile);
            }

            // **Kullanıcıyı Güncelle**
            await _repository.UpdateAsync(user, user);
            return true;
        }

    



    }
}
