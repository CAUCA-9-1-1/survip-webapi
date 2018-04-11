using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}		

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			RegisterServicesAndContext(services);
			services.AddTokenAuthentification(Configuration);
			services.AddSwaggerDocumentation();
			services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

		private void RegisterServicesAndContext(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("SurviPreventionDatabase");
			services.AddDbContext<ManagementContext>(options => options.UseNpgsql(connectionString));
			services.AddTransient<AuthentificationService>();
            services.AddTransient<CountryService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseAuthentication();
			app.UseSwaggerDocumentation();
			app.UseMvc();
		}
	}
}