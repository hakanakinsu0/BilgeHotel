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
    /// Identity sistemini çözümler.
    /// </summary>
    public static class IdentityResolver
    {
        /// <summary>
        /// Identity bağımlılıklarını IServiceCollection'a ekler.
        /// </summary>
        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 4;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Lockout.MaxFailedAccessAttempts = 5;
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                x.SignIn.RequireConfirmedEmail = false;
                x.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders(); // Şifre sıfırlama ve doğrulama için
        }
    }
}
