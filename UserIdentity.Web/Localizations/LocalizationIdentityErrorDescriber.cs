using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            //return base.DuplicateUserName(userName);
            return new() { Code = "DublicateUserName", Description = $"{userName} daha önce başka bir kullanıcı tarafından alınmıştır." };

        }

        public override IdentityError DuplicateEmail(string email)
        {
            //return base.DuplicateEmail(email);
            return new() { Code = "DuplicateEmail", Description = "Bu mail adresi daha önce kullanılmıştır." };
        }
    }
}
