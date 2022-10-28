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
    public class ShowRolesModel : PageModel
    {
        [BindProperty]
        public List<IdentityRole> ListRoleModel { get; set; }
        public RoleManager<IdentityRole> _roleManager;
        public ShowRolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
              ListRoleModel = _roleManager.Roles.ToList();
            
        }
    }
}
