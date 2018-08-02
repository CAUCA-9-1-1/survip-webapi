using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Survi.Prevention.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        var host = CreateWebHostBuilding(args)
		        .Build();
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
				.UseDefaultServiceProvider(options => options.ValidateScopes = false)
			    .UseKestrel()
			    .UseConfiguration(config)
			    .UseContentRoot(Directory.GetCurrentDirectory())
			    .UseStartup<Startup>();
	    }
    }
}
