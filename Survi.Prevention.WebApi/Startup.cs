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
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigin",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

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
            services.AddTransient<StateService>();
			services.AddTransient<RiskLevelService>();
			services.AddTransient<InspectionService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("AllowAllOrigin");
            app.UseAuthentication();
			app.UseSwaggerDocumentation();
			app.UseMvc();
        }
	}
}