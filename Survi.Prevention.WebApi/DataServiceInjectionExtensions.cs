using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Country;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi
{
    public static class DataServiceInjectionExtensions
    {
        public static IServiceCollection InjectDataServices(this IServiceCollection services)
        {
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
            services.AddTransient<BuildingParticularRiskService>();
            services.AddTransient<BuildingAlarmPanelService>();
            services.AddTransient<BuildingAnomalyService>();
            services.AddTransient<BuildingCourseService>();
            services.AddTransient<BuildingFireHydrantService>();
            services.AddTransient<BuildingSprinklerService>();
            services.AddTransient<FireHydrantService>();
            services.AddTransient<FireHydrantTypeService>();
            services.AddTransient<FireHydrantConnectionTypeService>();
            services.AddTransient<UnitOfMeasureService>();
            services.AddTransient<SurveyService>();
            services.AddTransient<SurveyQuestionService>();
            services.AddTransient<SurveyQuestionChoiceService>();
            services.AddTransient<ConstructionService>();
            services.AddTransient<BuildingDetailService>();
            services.AddTransient<InspectionSurveyAnswerService>();
            services.AddTransient<InspectionBuildingHazardousMaterialService>();
            services.AddTransient<HazardousMaterialService>();
            services.AddTransient<PersonRequiringAssistanceTypeService>();
            services.AddTransient<InspectionBuildingParticularRiskService>();
            services.AddTransient<InspectionBuildingParticularRiskPictureService>();
            services.AddTransient<FireSafetyDepartmentInspectionConfigurationService>();
            services.AddTransient<ReportConfigurationTemplateService>();
            services.AddTransient<ReportGenerationService>();
            services.AddTransient<InspectionBuildingDetailService>();
            services.AddTransient<InspectionPictureService>();
            services.AddTransient<PermissionService>();
            services.AddTransient<PermissionObjectService>();
            services.AddTransient<PermissionSystemFeatureService>();
            services.AddTransient<GeolocationService>();
            return services;
        }

        public static IServiceCollection InjectValidators(this IServiceCollection services)
        {
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.Country>, CountryValidator>();

            return services;
        }

        public static IServiceCollection InjectImportationConverters(this IServiceCollection services)
        {
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.Country, Country>, CountryImportationConverter>();

            return services;
        }
    }
}