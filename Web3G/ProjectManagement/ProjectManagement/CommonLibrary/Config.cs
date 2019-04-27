using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.CommonLibrary
{
    public class Config
    {
        public ConfigJwt Jwt { get; set; }

        public ConfigLogging Logging { get; set; }

        public ConfigConnectionStrings ConnectionStrings { get; set; }

        public ConfigSmtp Smtp { get; set; }
        public ConfigHostSiteSettings HostSiteSettings { get; set; }

        public string AllowedHosts { get; set; }
    }


    public class ConfigJwt
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
    }


    public class ConfigLogging
    {
        public ConfigLoggingLevel LogLevel { get; set; }
    }
    public class ConfigLoggingLevel
    {
        public string Default { get; set; }
    }


    public class ConfigConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }


    public class ConfigSmtp
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int Port { get; set; }
    }


    public class ConfigHostSiteSettings
    {
        public string UseUrls { get; set; }
    }

}
