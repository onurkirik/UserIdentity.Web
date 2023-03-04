using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserIdentity.Web.Models;

namespace UserIdentity.Web.Data
{
    //Burada IdentityDbContext içine oluşturulan AppUser ve AppRole ve string aldırdık. String parametresi burada id'nin tipini ifade etmektedir. Yani otomatik guid'ler üretecek.
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



    }
}
