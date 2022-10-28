using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentity.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreIdentity.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        public SignInManager<IdentityUser> signInManager { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                var IdentityResult = await signInManager.PasswordSignInAsync(Model.EmailId, Model.Password, Model.RememberMe, false);
                if (IdentityResult.Succeeded)
                {
                    HttpContext.Session.SetString("UserName", Model.EmailId);
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");

                    }
                    else
                    {
                        return RedirectToPage(returnUrl);

                    }


                }


                ModelState.AddModelError("", "UserName and Password is Incorrect");

            }
            return Page();

        }
    }
}