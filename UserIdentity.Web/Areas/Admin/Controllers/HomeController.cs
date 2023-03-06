using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserIdentity.Web.Areas.Admin.ViewModels;
using UserIdentity.Web.Models;

namespace UserIdentity.Web.Areas.Admin.Controllers
{
                    
    [Authorize(Roles = "Yeni site Yöneticisi")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList(UserListViewModel vm)
        {
            var users = _userManager.Users.Select(u => new UserListViewModel()
            {
                Id = u.Id,
                Name = u.UserName,
                Phone = u.PhoneNumber,
                Email = u.Email
            }).ToList();

            return View(users);
        }
    }
}
