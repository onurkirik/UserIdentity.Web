using Microsoft.AspNetCore.Identity;
using UserIdentity.Web.CustomValidations;
using UserIdentity.Web.Data;
using UserIdentity.Web.Localizations;
using UserIdentity.Web.Models;

namespace UserIdentity.Web.Extensions
{
    public static class StartupExtension
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(1);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz123456789_";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;


            }).AddErrorDescriber<LocalizationIdentityErrorDescriber>()
              .AddUserValidator<UserValidator>()
              .AddPasswordValidator<PasswordValidator>()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
