using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators;
using Survi.Prevention.ServiceLayer.Import.Places;
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
            services.AddTransient<FireHydrantConnectionService>();
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
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.State>, StateValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.Region>, RegionValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.County>, CountyValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.CityType>, CityTypeValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.City>, CityValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.RiskLevel>, RiskLevelImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.HazardousMaterial>, HazardousMaterialImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.UtilisationCode>, UtilisationCodeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.PersonRequiringAssistanceType>, PersonRequiringAssistanceTypeImportationValidator>();

            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.ConstructionType>, ConstructionTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.ConstructionFireResistanceType>, ConstructionFireResistanceTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.SidingType>, SidingTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.RoofType>, RoofTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.RoofMaterialType>, RoofMaterialTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.AlarmPanelType>, AlarmPanelTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.SprinklerType>, SprinklerTypeImportationValidator>();

	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireSafetyDepartment>, FireSafetyDepartmentValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing>, FireSafetyDepartmentCityServingValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.LaneGenericCode>, LaneGenericCodeValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.LanePublicCode>, LanePublicCodeValidator>();
	        services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.Lane>, LaneValidator>();

            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireHydrantType>, FireHydrantTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireHydrant>, FireHydrantImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireHydrantConnectionType>, FireHydrantConnectionTypeImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.FireHydrantConnection>, FireHydrantConnectionImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.UnitOfMeasure>, UnitOfMeasureImportationValidator>();

            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingParticularRisk>, BuildingParticularRiskImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingParticularRiskPicture>, BuildingParticularRiskPictureImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingAnomaly>, BuildingAnomalyImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingAnomalyPicture>, BuildingAnomalyPictureImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingDetail>, BuildingDetailImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingAlarmPanel>, BuildingAlarmPanelImportationValidator>();
            services.AddSingleton<AbstractValidator<ApiClient.DataTransferObjects.BuildingSprinkler>, BuildingSprinklerImportationValidator>();

            return services;
        }

        public static IServiceCollection InjectImportationConverters(this IServiceCollection services)
        {
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.Country, Country>, CountryImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.State, State>, StateImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.Region, Region>, RegionImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.County, County>, CountyImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.CityType, CityType>, CityTypeImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.City, City>, CityImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.RiskLevel, RiskLevel>, RiskLevelImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.HazardousMaterial, HazardousMaterial>, HazardousMaterialImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.UtilisationCode, UtilisationCode>, UtilisationCodeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.PersonRequiringAssistanceType, PersonRequiringAssistanceType>, PersonRequiringAssistanceTypeImportationConverter>();

            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.ConstructionType, ConstructionType>, ConstructionTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.ConstructionFireResistanceType, ConstructionFireResistanceType>, ConstructionFireResistanceTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.SidingType, SidingType>, SidingTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.RoofType, RoofType>, RoofTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.RoofMaterialType, RoofMaterialType>, RoofMaterialTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.AlarmPanelType, AlarmPanelType>, AlarmPanelTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.SprinklerType, SprinklerType>, SprinklerTypeImportationConverter>();

	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireSafetyDepartment, FireSafetyDepartment>, FireSafetyDepartmentImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing, FireSafetyDepartmentCityServing>, FireSafetyDepartmentCityServingImportationConverter>();

	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.LaneGenericCode, LaneGenericCode>, LaneGenericCodeImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.LanePublicCode, LanePublicCode>, LanePublicCodeImportationConverter>();
	        services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.Lane, Lane>, LaneImportationConverter>();

            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireHydrantType, FireHydrantType>, FireHydrantTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireHydrantConnectionType, FireHydrantConnectionType>, FireHydrantConnectionTypeImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireHydrantConnection, FireHydrantConnection>, FireHydrantConnectionImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.FireHydrant, FireHydrant>, FireHydrantImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.UnitOfMeasure, UnitOfMeasure>, UnitOfMeasureImportationConverter>();

            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingParticularRisk, Models.Buildings.Base.BuildingParticularRisk>, BuildingParticularRiskImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingParticularRiskPicture, BuildingParticularRiskPicture>, BuildingParticularRiskPictureImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingAnomaly, BuildingAnomaly>, BuildingAnomalyImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingAnomalyPicture, BuildingAnomalyPicture>, BuildingAnomalyPictureImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingDetail, BuildingDetail>, BuildingDetailImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingAlarmPanel, BuildingAlarmPanel>, BuildingAlarmPanelImportationConverter>();
            services.AddScoped<IEntityConverter<ApiClient.DataTransferObjects.BuildingSprinkler, BuildingSprinkler>, BuildingSprinklerImportationConverter>();

            return services;
        }

        public static IServiceCollection InjectConverterCustomFieldsCopiers(this IServiceCollection services)
        {
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingParticularRisk, Models.Buildings.Base.BuildingParticularRisk>, BuildingParticularRiskCustomFieldsCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingParticularRiskPicture, BuildingParticularRiskPicture>, BuildingParticularRiskPictureCustomFieldCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingAnomaly, BuildingAnomaly>, BuildingAnomalyCustomFieldsCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingAnomalyPicture, BuildingAnomalyPicture>, BuildingAnomalyPictureCustomFieldCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingDetail, BuildingDetail>, BuildingDetailCustomFieldsCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingAlarmPanel, BuildingAlarmPanel>, BuildingAlarmPanelCustomFieldsCopier>();
            services.AddScoped<ICustomFieldsCopier<ApiClient.DataTransferObjects.BuildingSprinkler, BuildingSprinkler>, BuildingSprinklerCustomFieldsCopier>();

            return services;
        }
    }
}