[assembly: HostingStartup(typeof(RoleTestProject.AppHost))]

namespace RoleTestProject;

public class AppHost() : AppHostBase("RoleTestProject"), IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public override void Configure()
    {
        // Configure ServiceStack, Run custom logic after ASP.NET Core Startup
        SetConfig(new HostConfig {
        });

        Plugins.Add(new AdminUsersFeature());
        
    }
}