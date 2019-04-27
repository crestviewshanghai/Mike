using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectManagement.PageModels.Club;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;
using ProjectManagement.Bases;

namespace ProjectManagement.Pages.Club
{

    public class LoginModel : BasePageModelClubAnonymous//PageModel
    {

        #region "Constructure"

        public LoginModel(IOptionsSnapshot<Config> objConnectionStringConfig) : base(objConnectionStringConfig)
        {
            //
        }

        #endregion "Constructure"


        #region "ProperTies"

        [BindProperty] // Bind on Post
        public LogInDataModel LogInData { get; set; }

        #endregion "Properties"


        #region "Handler Methods"

        public void OnGet()
        {
            var objCurrentUser = HttpContext.User;
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //
        //}

        //public void OnPost()
        //{
        //
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // TODO Validate the username and the password with your own logic
                var isValid = true; 

                if (!isValid)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return Page();
                }

                // Create the identity from the user info
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, LogInData.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, LogInData.Username));
                
                //You can add roles to use role-based authorization
                identity.AddClaim(new Claim(ClaimTypes.Role, "FrontClubMember"));

                // Authenticate using the identity
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    principal, 
                    new AuthenticationProperties {
                        //IsPersistent = LogInModel.RememberMe,
                        IsPersistent = false,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    }
                );

                //return RedirectToPage("Index");

                return RedirectToPage("/Club/ClubDefault");
            }

            return Page();
        }


        //public void OnPostCreateProduct()
        //{
        //
        //}

        //public async Task<IActionResult> OnPostCreateProductAsync()
        //{
        //
        //}

        #endregion "Handler Methods"

    }

}

//
//How to set asp.net Identity cookies expires time
//https://stackoverflow.com/questions/37086645/how-to-set-asp-net-identity-cookies-expires-time
//https://www.cnblogs.com/tdfblog/p/aspnet-core-security-authentication-cookie.html
//https://stackoverflow.com/questions/52708364/net-core-isauthenticated-false-even-if-i-use-manually-httpcontext-signinasync
//