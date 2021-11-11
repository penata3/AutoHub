using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AutoHub.Web.Areas.Identity.IdentityHostingStartup))]
namespace AutoHub.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
