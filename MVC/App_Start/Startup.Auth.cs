using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MVC.Models;
using Owin;

namespace MVC
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);

            app.CreatePerOwinContext<ApplicationUserManager>(
                ApplicationUserManager.Create);

            app.CreatePerOwinContext<ApplicationSignInManager>(
                ApplicationSignInManager.Create);

            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType =
                        DefaultAuthenticationTypes.ApplicationCookie,

                    LoginPath = new PathString("/Account/Login"),

                    ExpireTimeSpan = TimeSpan.FromMinutes(30),

                    SlidingExpiration = true,

                    CookieHttpOnly = true,

                    Provider = new CookieAuthenticationProvider
                    {
                        OnValidateIdentity =
                            SecurityStampValidator
                                .OnValidateIdentity<
                                    ApplicationUserManager,
                                    ApplicationUser>(
                                    validateInterval:
                                        TimeSpan.FromMinutes(30),
                                    regenerateIdentity: (manager, user) =>
                                        user.GenerateUserIdentityAsync(
                                            manager))
                    }
                });
        }
    }
}