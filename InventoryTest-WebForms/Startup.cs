using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryTest_WebForms.Startup))]
namespace InventoryTest_WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
