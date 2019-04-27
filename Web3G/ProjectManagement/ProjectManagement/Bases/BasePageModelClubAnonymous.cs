using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ProjectManagement.CommonLibrary;

namespace ProjectManagement.Bases
{
    public class BasePageModelClubAnonymous : PageModel
    {
        public Config m_ObjConfigRoot { get; }

        public BasePageModelClubAnonymous(IOptionsSnapshot<Config> objRootConfig)
        {

            m_ObjConfigRoot = objRootConfig.Value;

        }
    }
}
