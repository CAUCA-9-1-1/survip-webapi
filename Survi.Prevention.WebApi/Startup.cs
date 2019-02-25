using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;

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
                        .AllowAnyHeader());
            });

            services.AddTokenAuthentification(Configuration);
			services.AddSwaggerDocumentation();
			services.AddOData();
			services.AddMvc(options =>
				{
					options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Point)));
					foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
					{
						outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
					}
					foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
					{
						inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
					}
				})
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					options.SerializerSettings.Converters.Add(new PointCoordinateJsonConverter());
				})
				.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
        }

		private void RegisterServicesAndContext(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("SurviPreventionDatabase");
			services.AddDbContext<ManagementContext>(options => options.UseNpgsql(connectionString, npgOptions =>
			{
				npgOptions.UseNetTopologySuite();
			}));
		    services.AddScoped<IManagementContext, ManagementContext>();
			services.InjectDataServices();
		    services.InjectValidators();
		    services.InjectImportationConverters();
		    services.InjectConverterCustomFieldsCopiers();
			services.InjectReportHandlers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{			
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
			builder.EntitySet<Building>("Building").AllowAllQueryType();
		    builder.EntitySet<BuildingChild>("BuildingChild").AllowAllQueryType();
			builder.EntityType<Building>().Ignore(t => t.PointCoordinates);
			builder.EntitySet<FireHydrant>("FireHydrant").AllowAllQueryType();
			builder.EntityType<FireHydrant>().Ignore(t => t.PointCoordinates);
			builder.EntitySet<Lane>("Lane").AllowAllQueryType();
			builder.EntityType<AvailableBuildingForManagement>().HasKey(t => t.IdBuilding);
			builder.EntitySet<AvailableBuildingForManagement>("AvailableBuildingForManagement").AllowAllQueryType();
			builder.EntityType<BatchInspectionBuilding>().HasKey(t => t.IdInspection);
			builder.EntitySet<BatchInspectionBuilding>("BatchInspectionBuilding").AllowAllQueryType();

			return builder.GetEdmModel();
		}
	}
}