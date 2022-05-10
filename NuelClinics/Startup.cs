using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NuelClinics.Startup))]
namespace NuelClinics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
