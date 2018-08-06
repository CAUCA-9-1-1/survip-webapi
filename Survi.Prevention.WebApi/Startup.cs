using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Newtonsoft.Json;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
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
			services.AddOData();
			services.AddMvc(options =>
				{
					foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
					{
						outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
					}
					foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
					{
						inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
					}
				})
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
				.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
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
			services.AddTransient<InspectionBuildingAlarmPanelService>();
			services.AddTransient<InspectionBuildingSprinklerService>();
			services.AddTransient<InspectionBuildingAnomalyService>();
			services.AddTransient<InspectionBuildingAnomalyPictureService>();
			services.AddTransient<AlarmPanelTypeService>();
			services.AddTransient<SprinklerTypeService>();
			services.AddTransient<PictureService>();
			services.AddTransient<LaneService>();
            services.AddTransient<LaneGenericCodeService>();
            services.AddTransient<LanePublicCodeService>();
            services.AddTransient<FireSafetyDepartmentService>();
            services.AddTransient<FirestationService>();
			services.AddTransient<UtilisationCodeService>();
            services.AddTransient<BuildingService>();
            services.AddTransient<BuildingContactService>();
            services.AddTransient<BuildingHazardousMaterialService>();
            services.AddTransient<BuildingPersonRequiringAssistanceService>();
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
			services.AddTransient<InspectionQuestionService>();
			services.AddTransient<InspectionBuildingHazardousMaterialService>();
			services.AddTransient<HazardousMaterialService>();
			services.AddTransient<PersonRequiringAssistanceTypeService>();
			services.AddTransient<InspectionBuildingParticularRiskService>();
			services.AddTransient<InspectionBuildingParticularRiskPictureService>();
            services.AddTransient<FireSafetyDepartmentRiskLevelService>();
			services.AddTransient<ReportConfigurationTemplateService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			/*var builder = new ODataConventionModelBuilder();
			builder.EntitySet<BuildingWithoutInspection>("BuildingForDashboard")
				.EntityType
				.Filter()
				.Count()
				.Expand()
				.OrderBy()
				.Page()			
				.Select();
		*/
			
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigin");
            app.UseAuthentication();
			app.UseSwaggerDocumentation();
			app.UseMvc(routeBuilder =>
			{
				routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
				routeBuilder.MapODataServiceRoute("odataroutes", "api/odata", GetEdmModel());
			});
		}

		private static IEdmModel GetEdmModel()
		{
			var builder = new ODataConventionModelBuilder();
			builder.EnableLowerCamelCase();
			builder.EntitySet<BuildingWithoutInspection>("BuildingsWithoutInspection").AllowAllQueryType();
			builder.EntitySet<InspectionToDo>("InspectionsToDo").AllowAllQueryType();
			builder.EntitySet<InspectionForApproval>("InspectionsForApproval").AllowAllQueryType();
			builder.EntitySet<InspectionCompleted>("InspectionsCompleted").AllowAllQueryType();
			return builder.GetEdmModel();
		}
	}
}