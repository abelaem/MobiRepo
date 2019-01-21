using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using MovieHub.Models;
using Owin;

[assembly: OwinStartup(typeof(MovieHub.Startup))]
namespace MovieHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  app.UseCors(CorsOptions.AllowAll);
           
            //  app.CreatePerOwinContext(IdentityModels.Create);
            // app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //  
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                CookieHttpOnly = true, // JavaScript should use the Bearer
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieName = "AuthCookie",
                //CookieSecure = CookieSecureOption.Always
            };

            
            app.UseCookieAuthentication(cookieOptions);

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
              
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplocationOwinProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                AllowInsecureHttp = true,
                

            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //ConfigureAuth(app);
           
        }
    }
}
