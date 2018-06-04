using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace Survi.Prevention.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        var host = CreateWebHostBuilding(args)
		        .Build();

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


	    public static IWebHostBuilder CreateWebHostBuilding(string[] args)
	    {
		    var config = new ConfigurationBuilder()
			    .SetBasePath(Directory.GetCurrentDirectory())
			    .AddJsonFile("hosting.json", optional: true)
			    .AddJsonFile("appsettings.json", false)
			    .Build();

		    return WebHost.CreateDefaultBuilder(args)
			    .UseKestrel()
			    .UseConfiguration(config)
			    .UseContentRoot(Directory.GetCurrentDirectory())
			    .UseStartup<Startup>();
	    }
    }
}
