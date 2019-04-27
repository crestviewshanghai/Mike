using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;

namespace ProjectManagement.Bases
{
    public class BasePageModelAdminAuthenticated : PageModel
    {
        public Config m_ObjConfigRoot { get; }

        public BasePageModelAdminAuthenticated(IOptionsSnapshot<Config> objRootConfig)
        {

            m_ObjConfigRoot = objRootConfig.Value;
            
        }
        
        
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);

            getCurrentAuthenticatedUser();
        }


        private void getCurrentAuthenticatedUser()
        {
            string strCookieValueFromRequest = HttpContext.Request.Cookies[Consts.CookieKey_Back_CurrentUser_UserName];
        }

    }
}
