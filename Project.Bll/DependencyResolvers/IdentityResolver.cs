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
            services.AddIdentity<AppUser, IdentityRole<int>>(x =>
            {
                // **Şifre Politikaları**
                x.Password.RequireDigit = true;  // En az bir rakam içermeli.
                x.Password.RequiredLength = 6;   // Minimum şifre uzunluğu 6 karakter.
                x.Password.RequireLowercase = true;  // Küçük harf zorunlu.
                x.Password.RequireUppercase = true;  // Büyük harf zorunlu.
                x.Password.RequireNonAlphanumeric = false;  // Özel karakter gerekmiyor.

                // **Hesap Kilitleme Politikaları**
                x.Lockout.MaxFailedAccessAttempts = 3;  // 3 başarısız giriş denemesi sonrası kilitlenme.
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);  // Kilitlenme süresi 10 dakika.

                // **Giriş ve Kullanıcı Politikaları**
                x.SignIn.RequireConfirmedEmail = true;  // Kullanıcı e-posta onayı olmadan giriş yapamaz.
                x.User.RequireUniqueEmail = true;  // E-posta adresi benzersiz olmalı.
            })
            .AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders(); // Şifre sıfırlama ve e-posta doğrulama için token üretimi sağlar.
        }
    }
}
