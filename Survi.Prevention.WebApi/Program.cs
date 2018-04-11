using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        var host = BuildWebHost(args);

#if CREATEDB
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<ManagementContext>();
				ManagementContextInitializer.Initialize(context);
			}
#endif

			host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
