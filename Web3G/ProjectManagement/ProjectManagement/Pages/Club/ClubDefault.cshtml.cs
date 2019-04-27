using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;
using ProjectManagement.Bases;



namespace ProjectManagement.Pages.Club
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ClubDefaultModel : BasePageModelClubAuthenticated //PageModel
    {

        #region "Constructure"

        public ClubDefaultModel(IOptionsSnapshot<Config> objConnectionStringConfig) : base(objConnectionStringConfig)
        {
            //
        }

        #endregion "Constructure"


        public void OnGet()
        {
            var objCurrentUser = HttpContext.User;

            List<Claim> objClaims = objCurrentUser.Claims.ToList();
            string strName = objCurrentUser.Identity.Name;
            string strAuthenticationType = objCurrentUser.Identity.AuthenticationType;

        }
    }
}