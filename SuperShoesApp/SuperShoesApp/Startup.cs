using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperShoesApp.Startup))]
namespace SuperShoesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
        }
    }
}
