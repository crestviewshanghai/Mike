
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


namespace ProjectManagement.Pages.Admin
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "BackAdmin")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DefaultModel : BasePageModelAdminAuthenticated //PageModel
    {

        #region "Constructure"

        public DefaultModel(IOptionsSnapshot<Config> objConnectionStringConfig) : base(objConnectionStringConfig)
        {
            //
        }

        #endregion "Constructure"

        public void OnGet()
        {

        }
    }
}


//Visual Studio Issue
//One or more errors occurred
//Cannot connect to runtime process, timeout after 10000 ms(reason: Cannot connect to the target: Error enumerating targets: 0x800706ba).


//Format Code Short-Cut Key
//格式化代码快捷键：Ctrl + A + K + F
//取消格式化代码快捷键：Ctrl + K + F

//注释代码快捷键：Ctrl + K + C
//取消注释快捷键：Ctrl + K + U

//https://github.com/vuejs/vue/releases