using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Survi.Prevention.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        var connectionString = Configuration.GetConnectionString("SurviPreventionDatabase");
	        services.AddDbContext<ManagementContext>(options => options.UseNpgsql(connectionString));			
	        //services.AddTransient<ManagementContext>();
	        services.AddTransient<AuthentificationService>();

            services.AddMvc();
	        services.AddSwaggerGen(c =>
	        {
		        c.OrderActionsBy(action => action.RelativePath);
		        c.SwaggerDoc("v1", new Info {Title = "SURVI Prevention", Version = "v1"});
	        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	    {
		    if (env.IsDevelopment())
		    {
			    app.UseDeveloperExceptionPage();
		    }

		    app.UseMvc();
		    app.UseSwagger();
		    app.UseSwaggerUI(c =>
		    {
			    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SURVI Prevention v1");
			    c.RoutePrefix = "docs";
		    });
	    }
    }
}
