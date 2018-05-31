using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;

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


	    public static IWebHost BuildWebHost(string[] args)
	    {
		    var config = new ConfigurationBuilder()
			    .SetBasePath(Directory.GetCurrentDirectory())
			    .AddJsonFile("hosting.json", optional: true)
			    .AddJsonFile("appsettings.json", false)
			    .Build();

		    var host = new WebHostBuilder()
			    .UseKestrel()
			    .UseConfiguration(config)
			    .UseContentRoot(Directory.GetCurrentDirectory())
			    .UseStartup<Startup>()
			    .Build();

		    return host;
	    }
    }
}
