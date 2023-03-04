using Microsoft.AspNetCore.Identity;
using UserIdentity.Web.Models;

namespace UserIdentity.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainUserName",
                    Description = "Şifre alanı kullanıcı adını içermemelidir."
                });
            }

            if (password.ToLower().Contains("1234"))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainsBasicNumbers",
                    Description = "Şifreniz 123 gibi sıralı rakamlar içermemelidir."
                });
            }

            if (errors.Any())
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
