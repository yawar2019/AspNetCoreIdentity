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
    public class RegisterModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Register Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.EmaildId,
                    Email = Model.EmaildId
                };
             var result=await userManager.CreateAsync(user,Model.Password);
                if(result.Succeeded)
                {
                    

                    var resultAddtoRole =  await userManager.AddToRoleAsync(user,Model.RoleName);
                    if (resultAddtoRole.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        foreach (var error in resultAddtoRole.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }
    }
}
