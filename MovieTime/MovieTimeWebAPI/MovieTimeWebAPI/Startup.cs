using Microsoft.Owin;
using MovieTimeWebAPI.Models;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(MovieTimeWebAPI.Startup))]
namespace MovieTimeWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new DbInitializer());
        }
    }
}
