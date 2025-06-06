﻿using Microsoft.Extensions.DependencyInjection;
using Project.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Project.Dal.ContextClasses;

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
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>(options =>
            {
                // Şifre Politikaları
                options.Password.RequireDigit = true;               // En az bir rakam içermeli.
                options.Password.RequiredLength = 6;                // Minimum şifre uzunluğu 6 karakter.
                options.Password.RequireLowercase = true;           // Küçük harf zorunlu.
                options.Password.RequireUppercase = true;           // Büyük harf zorunlu.
                options.Password.RequireNonAlphanumeric = false;    // Özel karakter gerekmiyor.

                // Hesap Kilitleme Politikaları
                options.Lockout.MaxFailedAccessAttempts = 3;                        // 3 başarısız giriş denemesi sonrası kilitlenme.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);   // Kilitlenme süresi 3 dakika.

                // Giriş ve Kullanıcı Politikaları
                options.SignIn.RequireConfirmedEmail = true;    // Kullanıcı e-posta onayı olmadan giriş yapamaz.
                options.User.RequireUniqueEmail = true;         // E-posta adresi benzersiz olmalı.

                // Kullanıcı Adı Politikası
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            })
            .AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders(); // Şifre sıfırlama ve e-posta doğrulama için token üretimi sağlar.
        }
    }
}
