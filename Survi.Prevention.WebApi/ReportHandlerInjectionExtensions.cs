using Microsoft.Extensions.DependencyInjection;
using Survi.Prevention.ServiceLayer.Reporting;

namespace Survi.Prevention.WebApi
{
	public static class ReportHandlerInjectionExtensions
	{
		public static IServiceCollection InjectReportHandlers(this IServiceCollection services)
		{
			services.AddTransient<ReportBuildingAlarmPanelGroupHandler>();
			services.AddTransient<ReportBuildingAnomalyGroupHandler>();
			services.AddTransient<ReportBuildingAnomalyPictureGroupHandler>();
			services.AddTransient<ReportBuildingContactGroupHandler>();
			services.AddTransient<ReportBuildingCourseGroupHandler>();
			services.AddTransient<ReportBuildingCourseLaneGroupHandler>();
			services.AddTransient<ReportBuildingFireHydrantGroupHandler>();
			services.AddTransient<ReportBuildingHazardousMaterialGroupHandler>();
			services.AddTransient<ReportBuildingParticularRiskGroupHandler>();
			services.AddTransient<ReportBuildingParticularRiskPictureGroupHandler>();
			services.AddTransient<ReportBuildingPersonRequiringAssistanceGroupHandler>();
			services.AddTransient<ReportBuildingSprinklerGroupHandler>();
			services.AddTransient<ReportBuildingGroupHandler>();
			services.AddTransient<ReportBuildingDetailGroupHandler>();
			services.AddTransient<ReportInspectionGroupHandler>();
			services.AddTransient<BuildingReportTemplateFiller>();
			services.AddTransient<ReportMainBuildingGroupHandler>();
			return services;
		}
	}
}