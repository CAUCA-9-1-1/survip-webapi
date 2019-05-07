using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach(var arg in args)
                Console.WriteLine($"args: {arg}");

	        var host = CreateWebHostBuilder(args)	            
		        .Build();

            if (args.Any(arg => arg.ToLower() == "run-migration"))
            {
                host.MigrateDatabase<ManagementContext>();
                Environment.Exit(0);
            }
            else
            {
                host.Run();
            }
        }

	    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
	    {
	        ValidatorOptions.DisplayNameResolver = (type, memberInfo, expression) => memberInfo.Name;

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
