using Microsoft.Owin;
using Owin;
using ProjetoDDD.MVC;

[assembly: OwinStartup(typeof(Startup))]

namespace ProjetoDDD.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
