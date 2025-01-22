using ServiceStack;
using ServiceStack.Data;
using ServiceStack.Caching;

[assembly: HostingStartup(typeof(RoleTestProject.ConfigureValidation))]

namespace RoleTestProject;

public class ConfigureValidation : IHostingStartup
{
    // Add support for dynamically generated db rules
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            services.AddSingleton<IValidationSource>(c =>
                new OrmLiteValidationSource(
                    c.GetRequiredService<IDbConnectionFactory>(),
                    c.GetRequiredService<MemoryCacheClient>()));
        })
        .ConfigureAppHost(appHost => 
            appHost.Resolve<IValidationSource>().InitSchema());
}
