using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using ProjectManagement.CommonLibrary;
using Microsoft.Extensions.Logging;

namespace ProjectManagement
{
    public class Startup
    {

        private readonly ILogger m_Logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            var objRootConfig = Configuration.Get<Config>();
            var key = Encoding.ASCII.GetBytes(objRootConfig.Jwt.Secret);


            //Register Cookie Authentication Middleware
            registerCookieAuthenticationMiddleware(services);
            
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //Inject config setting
            Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<Config>(services, Configuration);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            //Config Cookie Authentication Middleware
            configCookieAuthenticationMiddleware(app, env);


            app.UseMvc();
        }



        #region "Custom Methods"

        private void registerCookieAuthenticationMiddleware(IServiceCollection services)
        {                        
            //From Front Customer
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
            .AddCookie(
                cfg =>
                {
                    cfg.SlidingExpiration = true;
                    cfg.LoginPath = "/Club/Login";
                    cfg.LogoutPath = "/Club/Logout";
                }
            );
            
        }

        private void configCookieAuthenticationMiddleware(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
        }


        private void registerJWTAuthenticationMiddleware(IServiceCollection services, byte[] strSecurityKey)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(strSecurityKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }



        private void test(IServiceCollection services)
        {
            //services.AddAuthentication().AddCookie(cfg => cfg.SlidingExpiration = true);


            services.AddMvc(
                config =>
                {
                    // using Microsoft.AspNetCore.Mvc.Authorization;
                    // using Microsoft.AspNetCore.Authorization;
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            services.AddAuthentication()
                .AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                }
            );
        }

        #endregion "Custom Methods"

    }
}


//
//.net core 'Response.Cookies.Append' not working as some station
//https://stackoverflow.com/questions/52407647/net-core-response-cookies-append-not-working-as-some-station
//https://www.c-sharpcorner.com/article/asp-net-core-working-with-cookie/
//
//https://codeexcavator.com/net-core-cookie-jwt-authentication/
//https://wildermuth.com/2017/08/19/Two-AuthorizationSchemes-in-ASP-NET-Core-2
//
//https://docs.microsoft.com/zh-cn/aspnet/core/razor-pages/filter?view=aspnetcore-2.2
//