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

        readonly IAppUserRepository _repository; 
        readonly IAppUserProfileManager _appUserProfileManager; 
        readonly IReservationRepository _reservationRepository;
        readonly IMapper _mapper; 
        readonly UserManager<AppUser> _userManager; 
        readonly RoleManager<IdentityRole<int>> _roleManager; 

        public AppUserManager(IAppUserRepository repository,IAppUserProfileManager appUserProfileManager,IMapper mapper,UserManager<AppUser> userManager,RoleManager<IdentityRole<int>> roleManager,IReservationRepository reservationRepository): base(repository, mapper)
        {
            _repository = repository;
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'sine sahip kullanıcının şifresini, mevcut şifre kontrolü sonrasında yeni şifreyle değiştirir.
        /// Identity üzerinden şifre değişikliği yapıldıktan sonra, güncellenen kullanıcı verilerini repository aracılığıyla kaydeder.
        /// </summary>
        /// <param name="userId">Şifresi değiştirilecek kullanıcının ID'si.</param>
        /// <param name="currentPassword">Kullanıcının mevcut şifresi.</param>
        /// <param name="newPassword">Kullanıcının yeni şifresi.</param>
        /// <returns>
        /// Şifre değişikliği başarılı ise true; başarısız ise false döndürür.
        /// </returns>
        public async Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword)
        {
            // Repository aracılığıyla kullanıcıyı ID'sine göre getiriyoruz.
            AppUser user = await _repository.GetByIdAsync(userId);
            if (user == null) return false; // Kullanıcı bulunamazsa false döndürür (veya ihtiyaç halinde exception fırlatılabilir).

            // Identity üzerinden mevcut şifreyi doğrulayıp, yeni şifreyle değiştirme işlemini gerçekleştiriyoruz.
            IdentityResult result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded) return false; // Şifre değişikliği başarısızsa false döndürür.

            // Şifre değişikliği başarılı ise, güncelleme bilgilerini ayarlıyoruz:
            user.ModifiedDate = DateTime.Now;  // Kullanıcının son güncelleme tarihini ayarlar.
            user.Status = DataStatus.Updated;  // Kullanıcı kaydının güncellendiğini belirtir.

            // Güncellenen kullanıcıyı repository aracılığıyla veritabanına kaydediyoruz.
            await _repository.UpdateAsync(user, user);

            return true; // İşlem başarılı ise true döndürür.
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre, kullanıcı bilgilerini ve bağlı profil detaylarını içeren AppUserDto'yu getirir.
        /// Eğer kullanıcı bulunamazsa null döndürür.
        /// </summary>
        /// <param name="userId">Kullanıcının ID'si.</param>
        /// <returns>
        /// Kullanıcı bulunduğunda, AppUserDto; aksi halde null.
        /// </returns>
        public async Task<AppUserDto> GetUserProfileAsync(int userId)
        {
            // Repository aracılığıyla, verilen kullanıcı ID'sine göre kullanıcıyı getiriyoruz.
            AppUser? user = await _repository.GetByIdAsync(userId);

            // Eğer kullanıcı bulunamazsa, null döndürerek metodun sonlanmasını sağlıyoruz.
            if (user == null) return null;

            // AutoMapper kullanarak, AppUser entity'sini AppUserDto'ya dönüştürüyoruz.
            AppUserDto userDto = _mapper.Map<AppUserDto>(user);

            // Eğer kullanıcının profil bilgileri mevcutsa, bu bilgileri DTO'ya manuel olarak ekliyoruz.
            if (user.AppUserProfile != null)
            {
                userDto.FirstName = user.AppUserProfile.FirstName;         // Profildeki FirstName değerini kopyalıyoruz.
                userDto.LastName = user.AppUserProfile.LastName;           // Profildeki LastName değerini kopyalıyoruz.
                userDto.Address = user.AppUserProfile.Address;             // Profildeki Address değerini kopyalıyoruz.
                userDto.Gender = user.AppUserProfile.Gender;               // Profildeki Gender değerini kopyalıyoruz.
                userDto.Nationality = user.AppUserProfile.Nationality;     // Profildeki Nationality değerini kopyalıyoruz.
                userDto.IdentityNumber = user.AppUserProfile.IdentityNumber; // Profildeki IdentityNumber değerini kopyalıyoruz.
            }
            return userDto; // Güncellenmiş AppUserDto'yu döndürüyoruz.
        }

        /// <summary>
        /// Belirtilen kullanıcı DTO'sundaki bilgileri kullanarak, ilgili AppUser ve AppUserProfile kayıtlarını günceller.
        /// Eğer kullanıcı bulunamazsa false döndürür.
        /// </summary>
        /// <param name="userDto">Güncellenecek kullanıcı ve profil bilgilerini içeren DTO.</param>
        /// <returns>
        /// Güncelleme işlemi başarılı ise true, aksi halde false.
        /// </returns>
        public async Task<bool> UpdateUserProfileAsync(AppUserDto userDto)
        {
            // Repository üzerinden, güncellenecek kullanıcıyı ID'sine göre getiriyoruz.
            AppUser? user = await _repository.GetByIdAsync(userDto.Id);
            if (user == null)
                return false; // Eğer kullanıcı bulunamazsa false döndürür.

            
            _mapper.Map(userDto, user); // DTO'daki temel kullanıcı bilgilerini, AutoMapper kullanarak entity'ye mapliyoruz.
            user.NormalizedEmail = userDto.Email.ToUpper(); // Email bilgisini normalizasyonu.
            user.SecurityStamp = Guid.NewGuid().ToString(); // Yeni bir security stamp oluşturuyoruz (güvenlik açısından).
            user.ModifiedDate = DateTime.Now; // Kullanıcının son güncelleme tarihini ayarlıyoruz.
            user.Status = DataStatus.Updated; // Kullanıcı kaydının güncellendiğini belirtiyoruz.

            // Kullanıcıya ait profil bilgileri mevcutsa güncelleme yapıyoruz.
            if (user.AppUserProfile != null)
            {
                user.AppUserProfile.FirstName = userDto.FirstName;
                user.AppUserProfile.LastName = userDto.LastName;
                user.AppUserProfile.Address = userDto.Address;
                user.AppUserProfile.Gender = userDto.Gender;
                user.AppUserProfile.Nationality = userDto.Nationality;
                user.AppUserProfile.IdentityNumber = userDto.IdentityNumber;
                user.AppUserProfile.ModifiedDate = DateTime.Now;
                user.AppUserProfile.Status = DataStatus.Updated;

                await _appUserProfileManager.UpdateAsync(_mapper.Map<AppUserProfileDto>(user.AppUserProfile)); // İlgili profil manager üzerinden, güncellenmiş profil entity'sini DTO'ya map ederek güncelleme işlemini gerçekleştiriyoruz.
            }
            else
            {
                // Eğer kullanıcının profil bilgisi mevcut değilse, yeni bir profil DTO'su oluşturuyoruz.
                AppUserProfileDto newProfile = new AppUserProfileDto
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
                
                await _appUserProfileManager.CreateAsync(newProfile); // İlgili profil manager üzerinden yeni profil kaydını oluşturuyoruz.
            }
            
            await _repository.UpdateAsync(user, user); // Güncellenen kullanıcıyı repository üzerinden veritabanına kaydediyoruz.
            return true; // İşlem başarılıysa true döndürür.
        }

        /// <summary>
        /// Tüm kullanıcıların sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Toplam kullanıcı sayısını içeren integer değer.</returns>
        public async Task<int> GetTotalUserCountAsync()
        {
            // BaseManager'da tanımlı CountAsync metodunu çağırarak, veritabanındaki tüm kullanıcıların sayısını asenkron olarak elde eder.
            return await CountAsync();
        }

        /// <summary>
        /// Veritabanındaki, status alanı Inserted veya Updated olan aktif kullanıcıların sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Aktif kullanıcı sayısını içeren integer değer.</returns>
        public async Task<int> GetActiveUserCountAsync()
        {
            // CountAsync metodunu, kullanıcıların Status alanı Inserted veya Updated olanları filtrelemek için lambda ifadesiyle çağırır.
            // Bu sayede, sadece aktif olarak kabul edilen kullanıcıların sayısı hesaplanır.
            return await CountAsync(u => u.Status == DataStatus.Inserted || u.Status == DataStatus.Updated);
        }

        /// <summary>
        /// Belirtilen e-posta adresine sahip kullanıcıyı asenkron olarak bulur.
        /// </summary>
        /// <param name="email">Aranacak kullanıcının e-posta adresi.</param>
        /// <returns>
        /// Eğer kullanıcı bulunursa ilgili AppUser entity'sini; bulunamazsa null döndürür.
        /// </returns>
        public async Task<AppUser?> FindUserByEmailAsync(string email)
        {
            // UserManager üzerinden, verilen e-posta adresi ile kullanıcıyı asenkron olarak getirir.
            return await _userManager.FindByEmailAsync(email);
        }

        /// <summary>
        /// Yeni bir kullanıcı oluşturur ve Identity sistemi üzerinden kaydeder.
        /// </summary>
        /// <param name="user">Oluşturulacak AppUser entity'si.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <returns>
        /// Kullanıcı oluşturma işleminin sonucunu belirten IdentityResult döndürür.
        /// </returns>
        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            // UserManager üzerinden, verilen kullanıcı ve şifre bilgileriyle yeni bir kullanıcı oluşturur.
            return await _userManager.CreateAsync(user, password);
        }

        /// <summary>
        /// Belirtilen role, ilgili kullanıcıya atama yapar.
        /// Eğer rol mevcut değilse, önce rolü oluşturur, ardından kullanıcıya atar.
        /// </summary>
        /// <param name="user">Rol ataması yapılacak AppUser entity'si.</param>
        /// <param name="roleName">Atanacak rolün adı (örneğin, "Admin" veya "Member").</param>
        /// <returns>
        /// Kullanıcıya rol atama işleminin sonucunu belirten IdentityResult döndürür.
        /// Rol oluşturma veya rol atama işlemi başarısız olursa, ilgili hata mesajını içeren IdentityResult döner.
        /// </returns>
        public async Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName)
        {
            IdentityRole<int> role = await _roleManager.FindByNameAsync(roleName); // İlgili rolü, RoleManager üzerinden asenkron olarak bulmaya çalışıyoruz.

            // Eğer rol bulunamazsa, önce rolü oluşturuyoruz.
            if (role == null)
            {
                IdentityResult createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int> { Name = roleName }); // Yeni rol oluşturma işlemi gerçekleştirilir.
                if (!createRoleResult.Succeeded) return createRoleResult; // Rol oluşturma başarısızsa, hata sonucunu döndürür.
            }
            
            return await _userManager.AddToRoleAsync(user, roleName); // Kullanıcıya, belirtilen rolü atama işlemini UserManager üzerinden gerçekleştirir.
        }

        /// <summary>
        /// Yeni bir aktivasyon kodu üretir.
        /// </summary>
        /// <returns>Yeni üretilen GUID, kullanıcının aktivasyon kodu olarak kullanılır.</returns>
        public Guid GenerateActivationCode()
        {
            return Guid.NewGuid(); // Yeni benzersiz bir GUID üretir.
        }

        /// <summary>
        /// Kullanıcının aktivasyonunu tamamlaması için, aktivasyon bağlantısı içeren e-posta gönderir.
        /// </summary>
        /// <param name="user">Aktivasyon maili gönderilecek kullanıcı entity'si.</param>
        /// <param name="activationCode">Gönderilecek aktivasyon kodu (GUID).</param>
        /// <returns>Asenkron işlem tamamlandığında bir Task döndürür.</returns>
        public async Task SendActivationEmailAsync(AppUser user, Guid activationCode)
        {
            // Kullanıcıya gönderilecek e-posta içeriğini oluşturuyoruz.
            // İçerik, aktivasyon bağlantısını içerir; bağlantı, BaseUrl üzerinden /Auth/ConfirmEmail endpoint'ine yönlendirir.
            string emailBody = $@"
                <p>Hesabınız oluşturulmuştur. Üyeliğinizi tamamlamak için aşağıdaki bağlantıya tıklayınız:</p>
                <p>
                    <a href='{BaseUrl}/Auth/ConfirmEmail?activationCode={activationCode}&userId={user.Id}' 
                       style='color:blue; text-decoration:underline;'>
                       E-posta doğrulama bağlantısı
                    </a>
                </p>";

            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Aktivasyon Maili"); // MailService kullanılarak, kullanıcının e-posta adresine, oluşturulan içerik ve konu ile e-posta gönderimi asenkron olarak gerçekleştirilir.
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'si ve aktivasyon koduna göre e-posta onaylama işlemini gerçekleştirir.
        /// Eğer kullanıcı bulunamazsa veya aktivasyon kodu geçersizse, işlem başarısız olarak IdentityResult.Failed döner.
        /// Onay başarılı ise, kullanıcının EmailConfirmed durumu true yapılır ve güncelleme işlemi gerçekleştirilir.
        /// </summary>
        /// <param name="userId">E-posta onayı yapılacak kullanıcının ID'si.</param>
        /// <param name="activationCode">Gönderilen aktivasyon kodu (GUID).</param>
        /// <returns>
        /// İşlem başarılı ise güncellenmiş kullanıcıyı temsil eden IdentityResult.Success,
        /// aksi halde hata mesajı içeren IdentityResult.Failed döner.
        /// </returns>
        public async Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId.ToString()); // Kullanıcıyı, ID'sini string olarak kullanarak UserManager üzerinden asenkron olarak buluyoruz.

            // Eğer kullanıcı bulunamazsa, "Kullanıcı bulunamadı." mesajıyla hata sonucu döndürür.
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });

            // Kullanıcının aktivasyon kodunu, parametre olarak gelen kod ile karşılaştırıyoruz.
            // Eğer kodlar uyuşmuyorsa, "Geçersiz doğrulama kodu." hatası döndürülür.
            if (user.ActivationCode != activationCode) return IdentityResult.Failed(new IdentityError { Description = "Geçersiz doğrulama kodu." });

            user.EmailConfirmed = true; // Kullanıcının e-posta onay durumunu true yaparız.
            user.ModifiedDate = DateTime.Now; // Güncelleme tarihini ayarlarız.
            user.Status = DataStatus.Updated; // Kullanıcı durumunu güncellenmiş olarak işaretleriz.

            return await _userManager.UpdateAsync(user); // Güncellenen kullanıcıyı, UserManager üzerinden veritabanına kaydeder ve sonucu döndürür.
        }

        /// <summary>
        /// Verilen e-posta adresine sahip kullanıcının, şifre sıfırlama mailini gönderir.
        /// Kullanıcı bulunamazsa veya e-posta onaylı değilse, uygun hata sonucu döndürür.
        /// </summary>
        /// <param name="email">Şifre sıfırlama maili gönderilecek kullanıcının e-posta adresi.</param>
        /// <returns>
        /// İşlem başarılı ise IdentityResult.Success, aksi halde hata mesajını içeren IdentityResult.Failed döndürür.
        /// </returns>
        public async Task<IdentityResult> SendPasswordResetEmailAsync(string email)
        {
            // Kullanıcıyı, e-posta adresi üzerinden asenkron olarak buluyoruz.
            AppUser user = await _userManager.FindByEmailAsync(email);

            // Eğer kullanıcı bulunamazsa, hata sonucu döndürür.
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });

            // Kullanıcının e-posta adresi onaylanmamışsa, hata sonucu döndürür.
            if (!await _userManager.IsEmailConfirmedAsync(user)) return IdentityResult.Failed(new IdentityError { Description = "E-posta onaylı değil." });

            // E-posta içeriğini, aktivasyon linkini içerecek şekilde oluşturuyoruz.
            string emailBody = $@"
            <p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p>
            <p>
                <a href='{BaseUrl}/Auth/ResetPassword?token={Uri.EscapeDataString(await _userManager.GeneratePasswordResetTokenAsync(user))}&email={Uri.EscapeDataString(user.Email)}' style='color:blue; text-decoration:underline;'>
                    Şifreyi Sıfırla
                </a>
            </p>";

            // MailService kullanılarak, kullanıcının e-posta adresine şifre sıfırlama maili gönderilir.
            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Şifre Sıfırlama");

            // İşlem başarılıysa IdentityResult.Success döndürülür.
            return IdentityResult.Success;
        }

        /// <summary>
        /// Belirtilen kullanıcı adını kullanarak, kullanıcının bilgilerini ve ilgili profil verilerini birlikte getirir.
        /// </summary>
        /// <param name="username">Aranacak kullanıcının kullanıcı adı.</param>
        /// <returns>
        /// Eğer kullanıcı bulunursa, ilgili AppUserDto ve AppUserProfileDto içeren bir tuple döndürür;
        /// kullanıcı bulunamazsa, (null, null) döndürür.
        /// </returns>
        public async Task<(AppUserDto user, AppUserProfileDto profile)> GetUserWithProfileAsync(string username)
        {
            List<AppUserDto> allUsers = await GetAllAsync(); // Tüm kullanıcıları getiriyoruz. 
            
            AppUserDto? user = allUsers.FirstOrDefault(u => u.UserName == username); // Kullanıcı adını baz alarak ilgili kullanıcıyı LINQ ile buluyoruz.
            if (user == null) return (null, null); // Eğer kullanıcı bulunamazsa, (null, null) döndürüyoruz.
            
            AppUserProfileDto profile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id); // Bulunan kullanıcının ID'sine göre, ilgili profil bilgilerini getiriyoruz.

            return (user, profile); // Kullanıcı ve profil bilgilerini bir tuple olarak döndürüyoruz.
        }

        /// <summary>
        /// Müşteri rapor verilerini getirir.
        /// Bu metot, admin dışındaki kullanıcıların toplam sayısını, rezervasyon yapan ve yapmayan kullanıcı sayılarını,
        /// tüm kullanıcı DTO'larını (Members), kullanıcı profil DTO'larını (Profiles) ve rezervasyon DTO'larını (Reservations)
        /// döndürür.
        /// </summary>
        /// <returns>
        /// (TotalCustomers, CustomersWithReservations, CustomersWithoutReservations, Members, Profiles, Reservations)
        /// şeklinde bir tuple döndürür.
        /// </returns>
        public async Task<(int TotalCustomers, int CustomersWithReservations, int CustomersWithoutReservations, List<AppUserDto> Members, List<AppUserProfileDto> Profiles, List<ReservationDto> Reservations)> GetCustomerReportDataAsync()
        {
            List<AppUserDto> users = await GetAllAsync(); // AppUserManager'ın mevcut metodu, tüm kullanıcıları getirir.

            List<AppUserProfileDto> userProfiles = await _appUserProfileManager.GetAllAsync(); // Tüm kullanıcı profillerini getirir.

            List<ReservationDto> reservations = _mapper.Map<List<ReservationDto>>(await _reservationRepository.GetAllAsync()); // Tüm rezervasyonları repository'den getirip, ReservationDto'ya map eder.

            List<AppUserDto> members = users.Where(u => u.Id != 1).ToList(); // Admin (UserId = 1) dışındaki kullanıcıları filtreleyip Members listesine ekler.

            int totalCustomers = members.Count; // Toplam müşteri sayısını belirler.

            // Rezervasyon yapan müşteri sayısını belirler:
            // Önce, rezervasyonların AppUserId alanı dolu ve admin'e ait olmayanları seçer,
            // sonra benzersiz AppUserId'leri sayar.
            int customersWithReservations = reservations
                .Where(r => r.AppUserId.HasValue && r.AppUserId != 1)
                .Select(r => r.AppUserId)
                .Distinct()
                .Count();
            
            int customersWithoutReservations = totalCustomers - customersWithReservations; // Rezervasyon yapmayan müşteri sayısını hesaplar.
            
            return (totalCustomers, customersWithReservations, customersWithoutReservations, members, userProfiles, reservations); // Hesaplanan değerleri ve ilgili listeleri tuple olarak döndürür.
        }

        /// <summary>
        /// Belirtilen arama, rol ve durum filtrelerine göre tüm kullanıcıların detaylı bilgilerini getirir.
        /// Kullanıcı bilgileri, ilgili profil ve rol bilgileriyle birleştirilerek AppUserDto olarak döndürülür.
        /// </summary>
        /// <param name="search">Kullanıcı adı, soyadı, e-posta veya kullanıcı adı içeren arama kelimesi.</param>
        /// <param name="role">Rol filtresi (örn. "Admin", "Üye").</param>
        /// <param name="status">Kullanıcı durumu filtresi ("Aktif" veya "Pasif").</param>
        /// <returns>Filtrelenmiş ve detaylandırılmış AppUserDto listesini asenkron olarak döndürür.</returns>
        public async Task<List<AppUserDto>> GetUsersWithDetailsAsync(string search, string role, string status)
        {
            // Identity üzerinden tüm kullanıcıları asenkron olarak çekiyoruz.
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<AppUserDto> userDtos = new();

            // Her kullanıcı için, ilgili profil ve rol bilgilerini alıp DTO'ya mapliyoruz.
            foreach (AppUser user in users)
            {
                
                IList<string> roles = await _userManager.GetRolesAsync(user); // Kullanıcının rollerini alıyoruz.
                AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id); // Kullanıcının profil bilgilerini getiriyoruz.

                // Yeni bir AppUserDto örneği oluşturuyoruz ve kullanıcı ile ilgili temel bilgileri, aynı zamanda profil bilgilerini ilgili alanlara atıyoruz.
                AppUserDto dto = new()
                {
                    Id = user.Id,                                       // Kullanıcının benzersiz ID'si
                    UserName = user.UserName,                           // Kullanıcının kullanıcı adı
                    Email = user.Email,                                 // Kullanıcının e-posta adresi
                    EmailConfirmed = user.EmailConfirmed,               // E-posta adresinin onaylanma durumu (true/false)
                    PhoneNumber = user.PhoneNumber,                     // Kullanıcının telefon numarası
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,   // Telefon numarasının onaylanma durumu (true/false)
                    Role = roles.Any() ? string.Join(", ", roles) : "Member", // Kullanıcının rollerini virgülle ayırarak birleştirir; eğer roller boşsa "Member" olarak belirler
                    FirstName = userProfile.FirstName,                  // Profilde tanımlı ad bilgisi
                    LastName = userProfile.LastName,                    // Profilde tanımlı soyad bilgisi
                    Address = userProfile.Address,                      // Profilde tanımlı adres bilgisi
                    Nationality = userProfile.Nationality,              // Profilde tanımlı uyruğu
                    Gender = userProfile.Gender,                        // Profilde tanımlı cinsiyet bilgisi
                    IdentityNumber = userProfile.IdentityNumber,        // Profilde tanımlı kimlik numarası (TC kimlik veya pasaport)
                    Status = user.Status                                // Kullanıcının genel durumu (örneğin, aktif veya silinmiş)
                };

                userDtos.Add(dto); // Oluşturulan DTO'yu listeye ekliyoruz.
            }

            // Arama filtresi: Kullanıcı adını, soyadını, e-posta veya kullanıcı adını içeren kayıtları seçer.
            if (!string.IsNullOrEmpty(search))
                userDtos = userDtos.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search) || u.Email.Contains(search) || u.UserName.Contains(search)).ToList();

            // Rol filtresi: Belirtilen rol içeren kayıtları seçer.
            if (!string.IsNullOrEmpty(role))
                userDtos = userDtos.Where(u => u.Role.Contains(role)).ToList();

            // Durum filtresi: "Aktif" veya "Pasif" olarak filtreleme yapar.
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Aktif")
                    userDtos = userDtos.Where(u => u.Status != DataStatus.Deleted).ToList();
                else if (status == "Pasif")
                    userDtos = userDtos.Where(u => u.Status == DataStatus.Deleted).ToList();
            }

            return userDtos; // Filtrelenmiş ve detaylandırılmış kullanıcı DTO listesini döndürür.
        }

        /// <summary>
        /// DTO üzerinden gelen kullanıcı bilgileriyle yeni bir kullanıcı oluşturur, Identity sistemi üzerinden kaydeder, 
        /// belirtilen rolü atar ve ilgili profil bilgilerini oluşturur. Oluşturulan kullanıcının DTO'sunu döndürür.
        /// </summary>
        /// <param name="userDto">Kullanıcı ve profil bilgilerini içeren DTO.</param>
        /// <param name="password">Oluşturulacak kullanıcının şifresi.</param>
        /// <param name="role">Atanacak rol; varsayılan olarak "Member".</param>
        /// <returns>Oluşturulan kullanıcının bilgilerini içeren AppUserDto.</returns>
        public async Task<AppUserDto> CreateUserWithProfileAsync(AppUserDto userDto, string password, string role = "Member")
        {
            AppUser newUser = _mapper.Map<AppUser>(userDto); // DTO'daki bilgileri kullanarak yeni bir AppUser entity'sine map ediyoruz.

            // Eğer UserName boşsa, e-posta adresini kullanıcı adı olarak atıyoruz.
            if (string.IsNullOrWhiteSpace(newUser.UserName)) 
                newUser.UserName = newUser.Email;

            // Temel kullanıcı bilgilerini ayarlıyoruz.
            newUser.EmailConfirmed = true;              // E-posta onayını varsayılan olarak true kabul ediyoruz.
            newUser.CreatedDate = DateTime.Now;         // Oluşturulma tarihini ayarlıyoruz.
            newUser.Status = DataStatus.Inserted;       // Kullanıcı durumunu "Inserted" olarak belirliyoruz.

            // Identity sistemi üzerinden yeni kullanıcıyı oluşturuyoruz.
            IdentityResult result = await _userManager.CreateAsync(newUser, password);
            if (!result.Succeeded) 
                throw new Exception("Kullanıcı oluşturulurken bir hata oluştu."); // Kullanıcı oluşturulamazsa, işlem başarısız olarak exception fırlatıyoruz.

            // Eğer rol parametresi boş değilse, kullanıcıya rol ataması yapıyoruz.
            if (!string.IsNullOrEmpty(role))
            {
                bool roleExists = await _roleManager.RoleExistsAsync(role); // Belirtilen rolün varlığını kontrol ediyoruz.
                if (!roleExists)
                {
                    // Eğer rol mevcut değilse, rolü oluşturuyoruz.
                    IdentityResult createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int> { Name = role });
                    if (!createRoleResult.Succeeded)
                        throw new Exception("Rol oluşturulurken bir hata oluştu.");
                }
                
                await _userManager.AddToRoleAsync(newUser, role); // Kullanıcıya rol ataması yapıyoruz.
            }

            // Kullanıcının profil bilgilerini oluşturuyoruz.
            AppUserProfile userProfile = new()
            {
                FirstName = userDto.FirstName,           // Kullanıcının adı
                LastName = userDto.LastName,             // Kullanıcının soyadı
                Address = userDto.Address,               // Kullanıcının adresi
                Nationality = userDto.Nationality,       // Kullanıcının uyruğu
                IdentityNumber = userDto.IdentityNumber, // Kullanıcının kimlik numarası
                Gender = userDto.Gender,                 // Kullanıcının cinsiyeti
                AppUserId = newUser.Id,                  // Yeni oluşturulan kullanıcının ID'sini ilişkilendiriyoruz
                CreatedDate = DateTime.Now,              // Profilin oluşturulma tarihini ayarlıyoruz
                Status = DataStatus.Inserted             // Profilin durumunu "Inserted" olarak belirliyoruz
            };

            // Profil bilgilerini kaydetmek için, ilgili profil manager üzerinden CreateAsync metodunu çağırıyoruz. Önce, AppUserProfile nesnesini AppUserProfileDto'ya map ediyoruz.
            await _appUserProfileManager.CreateAsync(_mapper.Map<AppUserProfileDto>(userProfile));

            AppUserDto createdUserDto = _mapper.Map<AppUserDto>(newUser); // Oluşturulan AppUser entity'sini, AutoMapper kullanarak AppUserDto'ya mapliyoruz ve döndürüyoruz.
            return createdUserDto;
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre, kullanıcıyı ve profil bilgilerini getirir.
        /// </summary>
        /// <param name="userId">Kullanıcının veritabanı ID'si.</param>
        /// <returns>Kullanıcı bilgilerini taşıyan AppUserDto.</returns>
        public async Task<AppUserDto> GetUserEditDataAsync(int userId)
        {
            AppUser user = await _repository.GetByIdAsync(userId); // Kullanıcıyı ID'sine göre çekiyoruz.
            if (user == null)
                return null; 

            AppUserDto userDto = _mapper.Map<AppUserDto>(user); // AppUser entity'sini AppUserDto'ya mapliyoruz.
            
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(userId); // Kullanıcının profil bilgilerini çekiyoruz.
            if (userProfile != null)
            {
                // DTO'daki ilgili alanlara profil bilgilerini aktarıyoruz.
                userDto.FirstName = userProfile.FirstName;
                userDto.LastName = userProfile.LastName;
                userDto.Address = userProfile.Address;
                userDto.Nationality = userProfile.Nationality;
                userDto.IdentityNumber = userProfile.IdentityNumber;
                userDto.Gender = userProfile.Gender;
            }
            return userDto;
        }

        /// <summary>
        /// Belirtilen kullanıcıyı pasif (silinmiş) duruma getirir.
        /// </summary>
        /// <param name="userId">Pasif yapılacak kullanıcı ID'si</param>
        /// <param name="currentUserId">İşlemi yapan kullanıcı ID'si (kendi hesabını pasif yapmasını engellemek için)</param>
        /// <returns>İşlem başarılıysa true döner</returns>
        public async Task<bool> DeactivateUserAsync(int userId, int currentUserId)
        {
            // Kullanıcıyı veritabanından alıyoruz.
            AppUser user = await _repository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            // Kullanıcı kendi hesabını pasif yapamaz.
            if (user.Id == currentUserId)
                throw new Exception("Kendi hesabınızı silemezsiniz.");

            // Zaten pasif olan bir kullanıcı tekrar pasif yapılamaz.
            if (user.Status == DataStatus.Deleted)
                throw new Exception("Bu kullanıcı zaten pasif durumda.");

            // Kullanıcı pasif yapılıyor.
            user.Status = DataStatus.Deleted;
            user.DeletedDate = DateTime.Now;

            // Identity sisteminde kullanıcıyı güncelliyoruz.
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return false;

            // Kullanıcının profili varsa, onu da pasif hale getiriyoruz.
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
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
