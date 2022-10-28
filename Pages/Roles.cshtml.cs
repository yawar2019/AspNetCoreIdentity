using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreIdentity.Pages
{
    public class RolesModel : PageModel
    {
        [BindProperty]
        public AddRoleModel AddRoleModel { get; set; }
        [BindProperty]

        public List<AddRoleModel> ShowRoleModel { get; set; }
        public RoleManager<IdentityRole> _roleManager;
        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            IdentityRole role = await _roleManager.FindByIdAsync(AddRoleModel.RoleName);
            if (role == null)
            {
                IdentityResult resultRole = await _roleManager.CreateAsync(new IdentityRole(AddRoleModel.RoleName));

                if (resultRole.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    foreach (var error in resultRole.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return Page();
                }
            }
            else
            {
                 
                    ModelState.AddModelError("", "Role Already Exist");
                

                return Page();
            }
        }

    }
}
