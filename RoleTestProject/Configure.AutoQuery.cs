using ServiceStack;

[assembly: HostingStartup(typeof(RoleTestProject.ConfigureAutoQuery))]

namespace RoleTestProject;

public class ConfigureAutoQuery : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            services.AddPlugin(new AutoQueryFeature {
                MaxLimit = 1000,
                //IncludeTotal = true,
            });
        });
}
