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
            services.AddTransient<WebuserService>();
            services.AddTransient<CountryService>();
            services.AddTransient<StateService>();
            services.AddTransient<RegionService>();
            services.AddTransient<CountyService>();
            services.AddTransient<CityTypeService>();
            services.AddTransient<CityService>();
            services.AddTransient<RiskLevelService>();
			services.AddTransient<InspectionService>();
            services.AddTransient<InspectionBatchService>();
			services.AddTransient<InspectionBuildingService>();
			services.AddTransient<InspectionDetailService>();
			services.AddTransient<InspectionBuildingCourseService>();
			services.AddTransient<InspectionBuildingFireHydrantService>();
			services.AddTransient<InspectionBuildingContactService>();
			services.AddTransient<InspectionBuildingPersonRequiringAssistanceService>();
			services.AddTransient<PictureService>();
			services.AddTransient<LaneService>();
            services.AddTransient<LaneGenericCodeService>();
            services.AddTransient<LanePublicCodeService>();
            services.AddTransient<FireSafetyDepartmentService>();
            services.AddTransient<FirestationService>();
			services.AddTransient<UtilisationCodeService>();
            services.AddTransient<BuildingService>();
            services.AddTransient<FireHydrantService>();
            services.AddTransient<FireHydrantTypeService>();
            services.AddTransient<FireHydrantConnectionTypeService>();
            services.AddTransient<OperatorTypeService>();
            services.AddTransient<UnitOfMeasureService>();
			services.AddTransient<SurveyService>();
			services.AddTransient<SurveyQuestionService>();
			services.AddTransient<SurveyQuestionChoiceService>();
			services.AddTransient<ConstructionService>();
			services.AddTransient<BuildingDetailService>();
			services.AddTransient<InspectionBuildingHazardousMaterialService>();
			services.AddTransient<HazardousMaterialService>();
			services.AddTransient<PersonRequiringAssistanceTypeService>();
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