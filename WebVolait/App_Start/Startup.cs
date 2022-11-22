using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(WebVolait.App_Start.Startup))]

namespace WebVolait.App_Start
{
    public class Startup
    {
        public void ConfigurationCliente(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "AppAplicationCookie",
                LoginPath = new PathString("/AutenticacaoCliente/LoginCliente")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "LoginCliente";
        }

        public void ConfigurationFuncionario(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "AppAplicationCookie",
                LoginPath = new PathString("/AutenticacaoFuncionario/LoginFuncionario")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "LoginFuncionario";
        }
    }
}
