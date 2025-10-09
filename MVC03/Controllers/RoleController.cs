using DataAccess.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Role;

namespace Presentation.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,
                              UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index(string? searchInput)
        {
            var roles = new List<RoleViewModel>();
            if (string.IsNullOrEmpty(searchInput))
            {
                roles = _roleManager.Roles.Select(r => new RoleViewModel()
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();
            }
            else
            {
                roles = _roleManager.Roles.Where(r => r.NormalizedName.Contains(searchInput.ToUpper()))
                   .Select(r => new RoleViewModel()
                   {
                       Id = r.Id,
                       Name = r.Name
                   }).ToList();
            }
            return View(roles);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {

                    Name = viewModel.Name
                };
                var r = _roleManager.CreateAsync(role).Result;

                if (r.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in r.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(viewModel);
        }

        public IActionResult Details(string? id, string viewName = "Details")
        {
            if (id is null) return BadRequest();
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role is null) return NotFound();
            var roleVM = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(viewName, roleVM);
        }

        public IActionResult Edit(string? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] string? id, RoleViewModel viewModel)
        {
            if (id is null || id != viewModel.Id) return BadRequest();
            if (ModelState.IsValid)
            {

                var role = _roleManager.FindByIdAsync(viewModel.Id).Result;
                if (role is null) return NotFound();
                role.Name = viewModel.Name;
                var r = _roleManager.UpdateAsync(role).Result;
                if (r.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in r.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(string? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(string? id, RoleViewModel viewModel)
        {
            if (id is null || id != viewModel.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var role = _roleManager.FindByIdAsync(id).Result;
                if (role is null) return NotFound();
                var r = _roleManager.DeleteAsync(role).Result;
                if (r.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in r.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(viewModel);
        }

        //public IActionResult AddOrRemoveUsers(string? roleId)
        //{
        //    if (roleId is null) return BadRequest();
        //    var role = _roleManager.FindByIdAsync(roleId).Result;
        //    if (role is null) return NotFound();
        //    var userInRole = new List<UserInRoleViewModel>();
        //    var users = _userManager.Users.ToList();
        //    foreach (var user in users)
        //    {
        //        //var userInRole = new UserInRoleViewModel()
        //        //{
        //        //    UserId = user.Id,
        //        //    UserName = user.UserName
        //        //};
        //        //if ()
        //        //{
        //        //    userInRole.UserId = user.Id;
        //        //}
        //    }
        //    return View();
        //}

    }
}
