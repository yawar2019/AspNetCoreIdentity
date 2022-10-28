using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreIdentity.Pages
{
    public class LogOutModel : PageModel
    {

        SignInManager<IdentityUser> signInManager;
        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }       
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }
        public async Task<IActionResult> OnPostDontLogOutAsync()
        {
            return RedirectToPage("Index");
        }
    }
}
