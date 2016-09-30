using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using FATEA.PetNet.Web.Indentity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(FATEA.PetNet.Web.Startup))]

namespace FATEA.PetNet.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.Use<PetNetIdentityDbContext>(new PetNetIdentityDbContext());
            app.CreatePerOwinContext<PetNetIdentityDbContext>(() => new PetNetIdentityDbContext());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout"),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
