
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectManagement.PageModels.Admin;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;
using ProjectManagement.Bases;

using BusinessObject.ModulePrime;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace ProjectManagement.Pages.Admin
{
    public class LoginModel : BasePageModelAdminAnonymous //PageModel
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

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // TODO Validate the username and the password with your own logic
                CustomerDTO objCustomer = CustomerDal.GetItem("test1", "test1");
                var isValid = objCustomer != null;

                if (!isValid)
                {
                    // return null if user not found
                    ModelState.AddModelError("", "username or password is invalid");
                    
                }

                CookieOptions option = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Secure = false,
                    Path = "/",
                    HttpOnly = false,
                    IsEssential = true
                };
                
                Response.Cookies.Append(Consts.CookieKey_Back_CurrentUser_UserName, objCustomer.UserName, option);

                //Response.Redirect("/Admin/AdminDefault");

                RedirectToPage("/Admin/AdminDefault");
            }
                        
        }


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // TODO Validate the username and the password with your own logic
        //        CustomerDTO objCustomer = CustomerDal.GetItem("test1", "test1");
        //        var isValid = objCustomer != null;

        //        if (!isValid)
        //        {
        //            // return null if user not found
        //            ModelState.AddModelError("", "username or password is invalid");
        //            return Page();
        //        }

        //        CookieOptions option = new CookieOptions() {
        //            Expires = DateTime.Now.AddDays(1),
        //            Secure = false,
        //            Path = "/",
        //            HttpOnly = false,
        //            IsEssential = true
        //        };
                
        //        Response.Cookies.Append(Consts.CookieKey_Back_CurrentUser_UserName, objCustomer.UserName, option);
                
        //        return RedirectToPage("/Admin/AdminDefault");
        //    }

        //    return Page();
        //}


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
//Role-based authorization in ASP.NET Core
//https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-2.2
//https://stackoverflow.com/questions/30099613/dynamically-add-roles-to-authorize-attribute-for-controller
//https://stackoverflow.com/questions/55030251/razor-pages-call-method-from-base-class-after-all-onget-handlers
//https://www.learnrazorpages.com/razor-pages/filters
//