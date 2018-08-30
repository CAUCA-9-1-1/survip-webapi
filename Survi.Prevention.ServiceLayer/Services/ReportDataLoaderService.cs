using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class ReportDataLoaderService : BaseService
	{
		public ReportDataLoaderService(ManagementContext context) : base(context)
		{
		}

		public string FillTemplate(string template, Guid inspectionId, string languageCode)
		{
			var buildingGroup = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Building, template);
			var buildingIds = GetBuildingIds(inspectionId);
			var filledBuildingGroup = "";
			var buildingGroupHandler = new ReportBuildingGroupHandler(Context);
			foreach (var id in buildingIds)
				filledBuildingGroup += buildingGroupHandler.FillBuildingGroup(buildingGroup, id, languageCode);
			return template.Replace(buildingGroup, filledBuildingGroup);
		}

		private List<Guid> GetBuildingIds(Guid inspectionId)
		{
			var mainBuildingId = Context.Inspections.Where(i => i.Id == inspectionId).Select(i => i.IdBuilding).FirstOrDefault();

			if (mainBuildingId != Guid.Empty)
			{
				var query =
					from building in Context.Buildings.AsNoTracking()
					where building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId)
					select building.Id;

				return query.ToList();

			}

			return new List<Guid>();
		}				
	}

	public class ReportBuildingGroupHandler
	{
		private readonly ManagementContext context;

		public ReportBuildingGroupHandler(ManagementContext context)
		{
			this.context = context;
		}

		public string FillBuildingGroup(string template, Guid idBuilding, string languageCode)
		{
			var filledTemplate = template;
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.AlarmPanel, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.AlarmPanel, template);
				var filledGroup = new ReportBuildingAlarmPanelGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Sprinkler, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Sprinkler, template);
				var filledGroup = new ReportBuildingSprinklerGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Contact, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Contact, template);
				var filledGroup = new ReportBuildingContactGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.PersonRequiringAssistance, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.PersonRequiringAssistance, template);
				var filledGroup = new ReportBuildingPersonRequiringAssistanceGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.FireHydrant, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.FireHydrant, template);
				var filledGroup = new ReportBuildingFireHydrantGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Course, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Course, template);
				var filledGroup = new ReportBuildingCourseGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.HazardousMaterial, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.HazardousMaterial, template);
				var filledGroup = new ReportBuildingHazardousMaterialGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Anomaly, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Anomaly, template);
				var filledGroup = new ReportBuildingAnomalyGroupHandler(context).FillGroup(group, idBuilding, languageCode);
				filledTemplate = filledTemplate.Replace(group, filledGroup);
			}

			return filledTemplate;
		}

		private List<Building> GetData(Guid idBuilding)
		{
			var query =
				from building in context.Buildings.AsNoTracking()
				where building.Id == idBuilding
				select building;

			return query
				.Include(b => b.Detail)
				.ToList();
		}
	}
}