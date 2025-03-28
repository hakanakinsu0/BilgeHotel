using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.Common.Tools;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// AppUser ile ilgili iş mantığı işlemlerini yöneten manager sınıfı. 
    /// BaseManager üzerinden temel CRUD işlemlerini kullanır.
    /// </summary>
    public class AppUserManager : BaseManager<AppUserDto, AppUser>, IAppUserManager
    {
        const string BaseUrl = "http://localhost:5114"; // Manager için sabit URL

        readonly IAppUserRepository _repository; // Repository bağımlılığı
        readonly IAppUserProfileManager _appUserProfileManager; // Profil manager bağımlılığı
        readonly IReservationRepository _reservationRepository;
        readonly IMapper _mapper; // AutoMapper bağımlılığı
        readonly UserManager<AppUser> _userManager; // UserManager bağımlılığı
        readonly RoleManager<IdentityRole<int>> _roleManager; // Rol yönetimi bağımlılığı


        public AppUserManager(
            IAppUserRepository repository,
            IAppUserProfileManager appUserProfileManager,
            IMapper mapper,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IReservationRepository reservationRepository)
            : base(repository, mapper)
        {
            _repository = repository;
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Kullanıcının şifresini değiştirir.
        /// </summary>
        public async Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword)
        {
            // Kullanıcıyı ID'ye göre bul
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                return false; // veya throw new Exception("Kullanıcı bulunamadı.");

            // Identity üzerinden mevcut şifre -> yeni şifre değişikliği
            IdentityResult result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
                return false;

            // Eğer başarılıysa, ek veritabanı alanlarını güncelleyebilirsiniz:
            user.ModifiedDate = DateTime.Now;
            user.Status = DataStatus.Updated;

            // Burada, Repository veya userManager tekrar güncellemeyi yapabilir:
            await _repository.UpdateAsync(user, user); // or
                                                       // var updateResult = await _userManager.UpdateAsync(user);

            return true;
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre kullanıcı profilini getirir.
        /// </summary>
        public async Task<AppUserDto> GetUserProfileAsync(int userId)
        {
            AppUser? user = await _repository.GetByIdAsync(userId); // Kullanıcıyı getir

            if (user == null) return null; // Kullanıcı yoksa null döndür

            AppUserDto? userDto = _mapper.Map<AppUserDto>(user); // Kullanıcıyı DTO'ya map et

            // Profil bilgileri mevcutsa DTO'ya ekle
            if (user.AppUserProfile != null) // Eğer profil bilgisi varsa atamaları yap.
            {
                userDto.FirstName = user.AppUserProfile.FirstName;
                userDto.LastName = user.AppUserProfile.LastName;
                userDto.Address = user.AppUserProfile.Address;
                userDto.Gender = user.AppUserProfile.Gender;
                userDto.Nationality = user.AppUserProfile.Nationality;
                userDto.IdentityNumber = user.AppUserProfile.IdentityNumber;

            }
            return userDto; // DTO döndür
        }

        /// <summary>
        /// Kullanıcı profilini günceller.
        /// </summary>
        public async Task<bool> UpdateUserProfileAsync(AppUserDto userDto)
        {
            AppUser? user = await _repository.GetByIdAsync(userDto.Id);  // Kullanıcıyı getir

            if (user == null) return false; // Kullanıcı yoksa false döndür

            // AppUser güncelleme
            _mapper.Map(userDto, user); // DTO'yu entity'e map et
            user.NormalizedEmail = userDto.Email.ToUpper(); // Email normalize et
            user.SecurityStamp = Guid.NewGuid().ToString(); // SecurityStamp oluştur
            user.ModifiedDate = DateTime.Now; // ModifiedDate güncelle
            user.Status = DataStatus.Updated; // Status güncelle

            // AppUserProfile güncelleme veya ekleme
            if (user.AppUserProfile != null) // Eğer profil bilgisi mevcutsa atamaları yap
            {
                user.AppUserProfile.FirstName = userDto.FirstName;
                user.AppUserProfile.LastName = userDto.LastName;
                user.AppUserProfile.Address = userDto.Address;
                user.AppUserProfile.Gender = userDto.Gender;
                user.AppUserProfile.Nationality = userDto.Nationality;
                user.AppUserProfile.IdentityNumber = userDto.IdentityNumber;
                user.AppUserProfile.ModifiedDate = DateTime.Now;
                user.AppUserProfile.Status = DataStatus.Updated;

                await _appUserProfileManager.UpdateAsync(_mapper.Map<AppUserProfileDto>(user.AppUserProfile)); // Profil güncelle
            }
            else
            {
                AppUserProfileDto? newProfile = new AppUserProfileDto // Yeni profil oluştur ve atamaları yap
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Address = userDto.Address,
                    Gender = userDto.Gender,
                    Nationality = userDto.Nationality,
                    IdentityNumber = userDto.IdentityNumber,
                    AppUserId = userDto.Id,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _appUserProfileManager.CreateAsync(newProfile); // Yeni profil oluştur
            }

            await _repository.UpdateAsync(user, user); // Kullanıcıyı güncelle
            return true; // True döndür
        }

        /// <summary>
        /// Toplam kullanıcı sayısını getirir.
        /// </summary>
        public async Task<int> GetTotalUserCountAsync()
        {
            return await CountAsync(); // BaseManager'dan CountAsync çağrısı
        }

        /// <summary>
        /// Aktif kullanıcı sayısını getirir.
        /// </summary>
        public async Task<int> GetActiveUserCountAsync()
        {
            return await CountAsync(u => u.Status == DataStatus.Inserted || u.Status == DataStatus.Updated);  // Aktif kullanıcı sayısını filtreleyerek getir
        }

        /// <summary>
        /// Belirtilen email adresine göre kullanıcıyı bulur.
        /// </summary>
        public async Task<AppUser?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email); // UserManager üzerinden email ile kullanıcı getir
        }

        /// <summary>
        /// Yeni kullanıcı oluşturur.
        /// </summary>
        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password); // UserManager üzerinden kullanıcı oluştur
        }

        /// <summary>
        /// Belirtilen role kullanıcı ataması yapar.
        /// </summary>
        public async Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName)
        {
            IdentityRole<int> role = await _roleManager.FindByNameAsync(roleName); // Rolü bul
            if (role == null) // Rol yoksa
            {
                IdentityResult createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int> { Name = roleName }); // Rol oluştur
                if (!createRoleResult.Succeeded) return createRoleResult;  // Oluşturma başarısızsa sonucu döndür
            }
            return await _userManager.AddToRoleAsync(user, roleName); // Kullanıcıya rol ata
        }

        /// <summary>
        /// Yeni bir aktivasyon kodu üretir.
        /// </summary>
        public Guid GenerateActivationCode()
        {
            return Guid.NewGuid(); // Yeni GUID üret
        }

        /// <summary>
        /// Aktivasyon mailini gönderir.
        /// </summary>
        public async Task SendActivationEmailAsync(AppUser user, Guid activationCode)
        {
            string emailBody = $"<p>Hesabınız oluşturulmuştur. Üyeliğinizi tamamlamak için aşağıdaki bağlantıya tıklayınız:</p><p><a href='{BaseUrl}/Auth/ConfirmEmail?activationCode={activationCode}&userId={user.Id}' style='color:blue; text-decoration:underline;'>E-posta doğrulama bağlantısı</a></p>"; // Mail bodysini hazırla

            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Aktivasyon Maili"); // Mail gönderimini asenkron gerçekleştir
        }

        /// <summary>
        /// Email onaylama işlemini gerçekleştirir.
        /// </summary>
        public async Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId.ToString()); // Kullanıcıyı ID ile bul
            if (user == null)  // Eğer kullanıcı bulunamazsa
            {
                //throw new Exception("Kullanıcı bulunamadı."); // Exception fırlat
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            if (user.ActivationCode != activationCode) // Aktivasyon kodu kontrolü
            {
                return IdentityResult.Failed(new IdentityError { Description = "Geçersiz doğrulama kodu." });
            }

            user.EmailConfirmed = true; // Email doğrulama onaylandı
            user.ModifiedDate = DateTime.Now; // ModifiedDate güncelle
            user.Status = DataStatus.Updated; // Status güncelle

            return await _userManager.UpdateAsync(user); // Kullanıcıyı güncelle ve sonucu döndür
        }

        /// <summary>
        /// Şifre sıfırlama mailini gönderir.
        /// </summary>
        public async Task<IdentityResult> SendPasswordResetEmailAsync(string email)
        {
            // Kullanıcıyı email ile bul
            AppUser user = await _userManager.FindByEmailAsync(email); // Email ile kullanıcıyı bul

            if (user == null) // Kullanıcı bulunamazsa
            {
                return IdentityResult.Failed(new IdentityError {Description = "Kullanıcı bulunamadı."}); // Hata mesajını döndür
            }

            if (!await _userManager.IsEmailConfirmedAsync(user)) // Email onayı kontrolü
            {
                return IdentityResult.Failed(new IdentityError{Description = "E-posta onaylı değil."}); // Hata mesajını döndür
            }

            string emailBody = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p><p><a href='{BaseUrl}/Auth/ResetPassword?token={Uri.EscapeDataString(await _userManager.GeneratePasswordResetTokenAsync(user))}&email={Uri.EscapeDataString(user.Email)}' style='color:blue; text-decoration:underline;'>Şifreyi Sıfırla</a></p>";
            // E-posta içeriğini oluştur

            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Şifre Sıfırlama"); // Mail gönderimini asenkron gerçekleştir

            return IdentityResult.Success; // Başarılı sonucu döndür
        }

        /// <summary>
        /// Belirtilen kullanıcı adını kullanarak, kullanıcının bilgilerini ve ilgili profil verilerini birlikte getirir.
        /// </summary>
        /// <param name="username">Kullanıcının kullanıcı adı</param>
        /// <returns>Kullanıcı ve profil bilgilerini içeren bir tuple (AppUserDto, AppUserProfileDto)</returns>
        public async Task<(AppUserDto user, AppUserProfileDto profile)> GetUserWithProfileAsync(string username)
        {
            List<AppUserDto> allUsers = await GetAllAsync();
            AppUserDto user = allUsers.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return (null, null);
            }
            var profile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            return (user, profile);
        }

        public async Task<(int TotalCustomers, int CustomersWithReservations, int CustomersWithoutReservations, List<AppUserDto> Members, List<AppUserProfileDto> Profiles, List<ReservationDto> Reservations)> GetCustomerReportDataAsync()
        {
            var users = await GetAllAsync(); // AppUserManager'ın mevcut metodu, tüm kullanıcıları getirir.
            var userProfiles = await _appUserProfileManager.GetAllAsync(); // Kullanıcı profillerini getirir.
            var reservations = _mapper.Map<List<ReservationDto>>(await _reservationRepository.GetAllAsync());

            var members = users.Where(u => u.Id != 1).ToList(); // Admin (UserId = 1) dışındaki kullanıcılar.
            int totalCustomers = members.Count;
            int customersWithReservations = reservations
                .Where(r => r.AppUserId.HasValue && r.AppUserId != 1)
                .Select(r => r.AppUserId)
                .Distinct()
                .Count();
            int customersWithoutReservations = totalCustomers - customersWithReservations;

            return (totalCustomers, customersWithReservations, customersWithoutReservations, members, userProfiles, reservations);
        }


        public async Task<List<AppUserDto>> GetUsersWithDetailsAsync(string search, string role, string status)
        {
            // Identity üzerinden tüm kullanıcıları çekiyoruz
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<AppUserDto>();

            // Her kullanıcı için ilgili profil ve rol bilgilerini çekip DTO'ya mapliyoruz
            foreach (var user in users)
            {
                // Kullanıcının rollerini alıyoruz
                var roles = await _userManager.GetRolesAsync(user);
                // Kullanıcının profil bilgilerini alıyoruz
                var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);

                var dto = new AppUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    Role = roles.Any() ? string.Join(", ", roles) : "Üye",
                    FirstName = userProfile?.FirstName ?? "-",
                    LastName = userProfile?.LastName ?? "-",
                    Address = userProfile?.Address ?? "-",
                    Nationality = userProfile?.Nationality ?? "-",
                    Gender = userProfile?.Gender ?? Gender.Other,
                    IdentityNumber = userProfile?.IdentityNumber ?? "-",
                    Status = user.Status
                };

                userDtos.Add(dto);
            }

            // Filtreleme işlemleri

            // Arama: Kullanıcı adı, soyadı, email veya kullanıcı adı içeriyorsa
            if (!string.IsNullOrEmpty(search))
            {
                userDtos = userDtos.Where(u =>
                    u.FirstName.Contains(search) ||
                    u.LastName.Contains(search) ||
                    u.Email.Contains(search) ||
                    u.UserName.Contains(search)
                ).ToList();
            }

            // Rol filtresi
            if (!string.IsNullOrEmpty(role))
            {
                userDtos = userDtos.Where(u => u.Role.Contains(role)).ToList();
            }

            // Durum filtresi: "Aktif" veya "Pasif"
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Aktif")
                    userDtos = userDtos.Where(u => u.Status != DataStatus.Deleted).ToList();
                else if (status == "Pasif")
                    userDtos = userDtos.Where(u => u.Status == DataStatus.Deleted).ToList();
            }

            return userDtos;
        }

        public async Task<AppUserDto> CreateUserWithProfileAsync(AppUserDto userDto, string password, string role = "Member")
        {
            // AppUserDto'yu AppUser entity'sine mapliyoruz
            var newUser = _mapper.Map<AppUser>(userDto);

            // Eğer UserName boşsa, e-posta adresini UserName olarak atıyoruz
            if (string.IsNullOrWhiteSpace(newUser.UserName))
                newUser.UserName = newUser.Email;

            newUser.EmailConfirmed = true;
            newUser.CreatedDate = DateTime.Now;
            newUser.Status = DataStatus.Inserted;

            // Kullanıcıyı Identity sistemi üzerinden oluşturuyoruz
            var result = await _userManager.CreateAsync(newUser, password);
            if (!result.Succeeded)
            {
                // Hata durumunda exception fırlatıyoruz, isteğe göre farklı hata yönetimi yapılabilir
                throw new Exception("Kullanıcı oluşturulurken bir hata oluştu.");
            }

            // Kullanıcıya rol ataması yapıyoruz
            if (!string.IsNullOrEmpty(role))
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int> { Name = role });
                    if (!createRoleResult.Succeeded)
                        throw new Exception("Rol oluşturulurken bir hata oluştu.");
                }
                await _userManager.AddToRoleAsync(newUser, role);
            }

            // Kullanıcı profilini oluşturuyoruz
            var userProfile = new AppUserProfile
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                Nationality = userDto.Nationality,
                IdentityNumber = userDto.IdentityNumber,
                Gender = userDto.Gender,
                AppUserId = newUser.Id,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Profil bilgilerini kaydetmek için, ilgili DTO'ya mapleyip CreateAsync metodunu çağırıyoruz
            await _appUserProfileManager.CreateAsync(_mapper.Map<AppUserProfileDto>(userProfile));

            // Oluşturulan kullanıcıyı DTO'ya mapliyoruz ve döndürüyoruz
            var createdUserDto = _mapper.Map<AppUserDto>(newUser);
            return createdUserDto;
        }

        public async Task<AppUserDto> GetUserEditDataAsync(int userId)
        {
            // Kullanıcıyı ID'sine göre çekiyoruz.
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            // Kullanıcıyı DTO'ya mapliyoruz.
            var userDto = _mapper.Map<AppUserDto>(user);

            // Kullanıcının profil bilgilerini çekiyoruz.
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(userId);
            if (userProfile != null)
            {
                userDto.FirstName = userProfile.FirstName;
                userDto.LastName = userProfile.LastName;
                userDto.Address = userProfile.Address;
                userDto.Nationality = userProfile.Nationality;
                userDto.IdentityNumber = userProfile.IdentityNumber;
                userDto.Gender = userProfile.Gender;
            }

            return userDto;
        }

        
        public async Task<bool> DeactivateUserAsync(int userId, int currentUserId)
        {
            // Kullanıcıyı ID'sine göre çekiyoruz.
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            // Admin kendi hesabını silemez!
            if (user.Id == currentUserId)
                throw new Exception("Kendi hesabınızı silemezsiniz.");

            // Kullanıcı zaten pasif ise işlem iptal edilir.
            if (user.Status == DataStatus.Deleted)
                throw new Exception("Bu kullanıcı zaten pasif durumda.");

            // Kullanıcıyı pasif hale getiriyoruz.
            user.Status = DataStatus.Deleted;
            user.DeletedDate = DateTime.Now;

            // UpdateAsync sonucunu kontrol ediyoruz.
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception("Kullanıcı güncellenirken hata oluştu: " + errors);
            }

            // Kullanıcının profil bilgilerini de pasif hale getiriyoruz.
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile != null)
            {
                userProfile.Status = DataStatus.Deleted;
                userProfile.DeletedDate = DateTime.Now;
                await _appUserProfileManager.MakePassiveAsync(userProfile);
            }

            return true;
        }




    }
}
