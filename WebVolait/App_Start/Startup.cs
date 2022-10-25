using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebVolait.App_Start.Startup))]

namespace WebVolait.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "AppAplicationCookie",
            //    LoginPath = new PathString("Autenticacao/login")
            //});
        }
    }
}
