using Microsoft.Extensions.DependencyInjection;
using Project.Dal.ContextClasses;
using Project.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Identity sistemini Dependency Injection (DI) ile çözümler.
    /// Kullanıcı yönetimi, rol tabanlı erişim kontrolü ve kimlik doğrulama işlemlerini yönetir.
    /// </summary>
    public static class IdentityResolver
    {
        /// <summary>
        /// Identity bağımlılıklarını IServiceCollection'a ekler.
        /// Identity sistemi için kullanıcı, rol ve kimlik doğrulama yapılandırmalarını belirler.
        /// </summary>
        public static void AddIdentityService(this IServiceCollection services)
        {
            // **Identity Konfigürasyonu**
            // Kullanıcı (AppUser) ve rol (AppRole) sistemlerini Identity ile DI'ye ekler.
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                // **Şifre Politikaları**
                x.Password.RequireDigit = false; // En az bir rakam içermesi zorunlu değil.
                x.Password.RequiredLength = 4; // Minimum şifre uzunluğu 4 karakter.
                x.Password.RequireLowercase = false; // Küçük harf zorunluluğu yok.
                x.Password.RequireUppercase = false; // Büyük harf zorunluluğu yok.
                x.Password.RequireNonAlphanumeric = false; // Alfanümerik olmayan karakter gereksinimi yok.

                // **Hesap Kilitleme Politikaları**
                x.Lockout.MaxFailedAccessAttempts = 5; // 5 başarısız giriş denemesi sonrası kilitlenme.
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Kilitlenme süresi 5 dakika.

                // **Giriş ve Kullanıcı Politikaları**
                x.SignIn.RequireConfirmedEmail = false; // Kullanıcı e-posta onayı olmadan giriş yapabilir.
                x.User.RequireUniqueEmail = true; // Her kullanıcının e-posta adresi benzersiz olmalıdır.
            })
            // **Entity Framework Store Eklenmesi**
            // Identity sisteminin Entity Framework ile çalışmasını sağlar ve MyContext ile ilişkilendirir.
            .AddEntityFrameworkStores<MyContext>();
        }
    }
}
