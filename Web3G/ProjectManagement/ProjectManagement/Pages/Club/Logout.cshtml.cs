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



namespace ProjectManagement.Pages.Club
{
    public class LogoutModel : BasePageModelClubAuthenticated //PageModel
    {

        #region "Constructure"

        public LogoutModel(IOptionsSnapshot<Config> objConnectionStringConfig) : base(objConnectionStringConfig)
        {
            //
        }

        #endregion "Constructure"


        public void OnGet()
        {
            //await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
        }

        public async void OnGetAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            RedirectToPage("/Club/Login");
        }


    }
}