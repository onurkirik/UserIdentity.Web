using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserIdentity.Web.Areas.Admin.ViewModels;
using UserIdentity.Web.Extensions;
using UserIdentity.Web.Models;

namespace UserIdentity.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Yeni site Yöneticisi")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly RoleManager<AppRole> _roleManger;
        public RolesController(UserManager<AppUser> userManger, RoleManager<AppRole> roleManger)
        {
            _userManger = userManger;
            _roleManger = roleManger;
        }


        [Authorize(Roles = "role-action")]
        public async Task<IActionResult> Index()
        {
            var roles = _roleManger.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(roles);
        }

        [Authorize(Roles = "role-action")]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [Authorize(Roles = "role-action")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel vm)
        {
            var result = await _roleManger.CreateAsync(new AppRole() { Name = vm.Name });

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }

            return RedirectToAction(nameof(RolesController.Index));
        }

        [Authorize(Roles = "role-action")]
        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleToUpdate = await _roleManger.FindByIdAsync(id);

            if (roleToUpdate == null)
                throw new Exception("Böyle bir rol bulunamamıştır.");

            return View(new RoleUpdateViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate.Name});
        }

        [Authorize(Roles = "role-action")]
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel vm)
        {
            var roleToUpdate = await _roleManger.FindByIdAsync(vm.Id);
            
            if (roleToUpdate == null)
                throw new Exception("Böyle bir rol bulunamamıştır.");

            roleToUpdate.Name = vm.Name;

            await _roleManger.UpdateAsync(roleToUpdate);

            TempData["SuccessMessage"] = "Rol bilgisi güncellenmiştir.";

            return View();
        }

        [Authorize(Roles = "role-action")]
        public async Task<IActionResult> RoleDelete(string id)
        {
            var roleToDelete = await _roleManger.FindByIdAsync(id);

            if (roleToDelete == null)
                throw new Exception("Silinecek rol bulunamamıştır");

            var result = await _roleManger.DeleteAsync(roleToDelete);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).First());

            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = await _userManger.FindByIdAsync(id);
            ViewBag.UserId = id;
            var roles = await _roleManger.Roles.ToListAsync();
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            var userRoles = await _userManger.GetRolesAsync(currentUser);

            foreach ( var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel() {Id=role.Id, Name = role.Name };

                if (userRoles.Contains(role.Name))
                    assignRoleToUserViewModel.HasRoleExist = true;

                roleViewModelList.Add(assignRoleToUserViewModel);

            }

            return View(roleViewModelList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userId, List<AssignRoleToUserViewModel> vm)
        {
            var assignRoleToUser = await _userManger.FindByIdAsync(userId);

            foreach (var role in vm)
            {
                if (role.HasRoleExist)
                    await _userManger.AddToRoleAsync(assignRoleToUser, role.Name);
                else
                    await _userManger.RemoveFromRoleAsync(assignRoleToUser, role.Name);
            }


            return RedirectToAction(nameof(HomeController.UserList), "Home");
        }
    }
}
