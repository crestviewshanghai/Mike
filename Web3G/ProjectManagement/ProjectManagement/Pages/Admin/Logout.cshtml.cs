using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;
using ProjectManagement.Bases;


namespace ProjectManagement.Pages.Admin
{
    public class LogoutModel : BasePageModelAdminAuthenticated //PageModel
    {

        #region "Constructure"

        public LogoutModel(IOptionsSnapshot<Config> objConnectionStringConfig) : base(objConnectionStringConfig)
        {
            //
        }

        #endregion "Constructure"

        public void OnGet()
        {

        }

        public async void OnGetAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            RedirectToPage("/Admin/Login");
        }
    }
}