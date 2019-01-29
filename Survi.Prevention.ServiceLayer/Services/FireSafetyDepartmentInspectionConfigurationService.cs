using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentInspectionConfigurationService //: BaseCrudService<FireSafetyDepartmentInspectionConfiguration>
	{
		protected IManagementContext Context;

		public FireSafetyDepartmentInspectionConfigurationService(IManagementContext context)// : base(context)
		{
			Context = context;
		}

		public FireSafetyDepartmentInspectionConfigurationForEdition Get(Guid id)
		{
			var query =
				from config in Context.FireSafetyDepartmentInspectionConfigurations.AsNoTracking()
				where config.Id == id && config.IsActive
				select new FireSafetyDepartmentInspectionConfigurationForEdition
				{
					Id = config.Id,
					HasBuildingAnomalies = config.HasBuildingAnomalies,
					HasBuildingContacts = config.HasBuildingContacts,
					HasBuildingDetails = config.HasBuildingDetails,
					HasBuildingFireProtection = config.HasBuildingFireProtection,
					HasBuildingHazardousMaterials = config.HasBuildingHazardousMaterials,
					HasBuildingParticularRisks = config.HasBuildingParticularRisks,
					HasBuildingPnaps = config.HasBuildingPnaps,
					HasCourse = config.HasCourse,
					HasGeneralInformation = config.HasGeneralInformation,
					HasImplantationPlan = config.HasImplantationPlan,
					HasWaterSupply = config.HasWaterSupply,
					IdFireSafetyDepartment = config.IdFireSafetyDepartment,
					IdSurvey = config.IdSurvey,
					RiskLevelIds = config.RiskLevels.Where(risk => risk.IsActive).Select(risk => risk.IdRiskLevel.ToString()).ToList()
				};

			var result = query.FirstOrDefault();

			return result;
		}

		public List<FireSafetyDepartmentInspectionConfigurationForEdition> GetList(List<Guid> allowedDepartmentIds)
		{
			var query =
				from config in Context.FireSafetyDepartmentInspectionConfigurations.AsNoTracking()
				where config.IsActive && allowedDepartmentIds.Contains(config.IdFireSafetyDepartment)
				select new FireSafetyDepartmentInspectionConfigurationForEdition
				{
					Id = config.Id,
					HasBuildingAnomalies = config.HasBuildingAnomalies,
					HasBuildingContacts = config.HasBuildingContacts,
					HasBuildingDetails = config.HasBuildingDetails,
					HasBuildingFireProtection = config.HasBuildingFireProtection,
					HasBuildingHazardousMaterials = config.HasBuildingHazardousMaterials,
					HasBuildingParticularRisks = config.HasBuildingParticularRisks,
					HasBuildingPnaps = config.HasBuildingPnaps,
					HasCourse = config.HasCourse,
					HasGeneralInformation = config.HasGeneralInformation,
					HasImplantationPlan = config.HasImplantationPlan,
					HasWaterSupply = config.HasWaterSupply,
					IdFireSafetyDepartment = config.IdFireSafetyDepartment,
					IdSurvey = config.IdSurvey,
					RiskLevelIds = config.RiskLevels.Where(risk => risk.IsActive).Select(risk => risk.IdRiskLevel.ToString()).ToList()
				};

			var result = query.ToList();

			return result;
		}

		public List<Guid> GetUsedRiskLevelForFireSafetyDepartmentConfiguration(Guid fireSafetyDepartmentConfigurationId, Guid fireSafetyDepartmentId)
		{
			var query =
				from config in Context.FireSafetyDepartmentInspectionConfigurations.AsNoTracking()
				where config.IdFireSafetyDepartment == fireSafetyDepartmentId && config.IsActive
					  && config.Id != fireSafetyDepartmentConfigurationId
				from risk in config.RiskLevels
				select risk.IdRiskLevel;

			return query.Distinct().ToList();
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.Set<FireSafetyDepartmentInspectionConfiguration>().Find(id);

			if (entity == null)
				return false;

			entity.IsActive = false;
			Context.SaveChanges();
			return true;
		}

		public Guid AddOrUpdate(FireSafetyDepartmentInspectionConfigurationForEdition entity)
		{
			var currentConfig = Context.FireSafetyDepartmentInspectionConfigurations
                .Include(config => config.RiskLevels)
			    .FirstOrDefault(config => config.Id == entity.Id) 
                    ?? CreateNewConfiguration();

		    PushDtoToEntity(entity, currentConfig);
			Context.SaveChanges();
			return currentConfig.Id;
		}

		private void PushDtoToEntity(FireSafetyDepartmentInspectionConfigurationForEdition entity, FireSafetyDepartmentInspectionConfiguration currentConfig)
		{
			currentConfig.HasBuildingAnomalies = entity.HasBuildingAnomalies;
			currentConfig.HasBuildingContacts = entity.HasBuildingContacts;
			currentConfig.HasBuildingDetails = entity.HasBuildingDetails;
			currentConfig.HasBuildingFireProtection = entity.HasBuildingFireProtection;
			currentConfig.HasBuildingHazardousMaterials = entity.HasBuildingHazardousMaterials;
			currentConfig.HasBuildingParticularRisks = entity.HasBuildingParticularRisks;
			currentConfig.HasBuildingPnaps = entity.HasBuildingPnaps;
			currentConfig.HasCourse = entity.HasCourse;
			currentConfig.HasGeneralInformation = entity.HasGeneralInformation;
			currentConfig.HasImplantationPlan = entity.HasImplantationPlan;
			currentConfig.HasWaterSupply = entity.HasWaterSupply;
			currentConfig.IdFireSafetyDepartment = entity.IdFireSafetyDepartment;
			currentConfig.IdSurvey = entity.IdSurvey;
			currentConfig.IsActive = true;
			UpdateRiskLevels(entity, currentConfig);
		}

		private void UpdateRiskLevels(FireSafetyDepartmentInspectionConfigurationForEdition entity, FireSafetyDepartmentInspectionConfiguration currentConfig)
		{
			var riskLevelIds = entity.RiskLevelIds.Select(Guid.Parse).ToList();
			var activeRisks = currentConfig.RiskLevels.Where(risk => risk.IsActive).ToList();
			var deletedRiskLevels = activeRisks.Where(risk => riskLevelIds.All(id => id != risk.IdRiskLevel)).ToList();
			var newRiskLevelIds = riskLevelIds.Where(id => activeRisks.All(risk => risk.IdRiskLevel != id)).ToList();
		    if (deletedRiskLevels.Count > 0)
		    {
		        Context.RemoveRange(deletedRiskLevels);
		    }

		    foreach (var id in newRiskLevelIds)
			{
				var risk = new FireSafetyDepartmentInspectionConfigurationRiskLevel
				{
					IdFireSafetyDepartmentInspectionConfiguration = currentConfig.Id,
					IdRiskLevel = id,
				};
				Context.Add(risk);
			}
		}

	    private void RemoveDeletedRiskLevels(List<FireSafetyDepartmentInspectionConfigurationRiskLevel> activeRisks, List<Guid> riskLevelIds)
	    {
	        var deletedRiskLevels = activeRisks.Where(risk => riskLevelIds.All(id => id != risk.IdRiskLevel)).ToList();
	        if (deletedRiskLevels.Any())
	            Context.RemoveRange(deletedRiskLevels);
	    }

	    private void AddNewRiskLevels(FireSafetyDepartmentInspectionConfiguration currentConfig, List<Guid> riskLevelIds,
	        List<FireSafetyDepartmentInspectionConfigurationRiskLevel> activeRisks)
	    {
	        var newRiskLevelIds = riskLevelIds.Where(id => activeRisks.All(risk => risk.IdRiskLevel != id)).ToList();
	        foreach (var id in newRiskLevelIds)
	        {
	            var risk = new FireSafetyDepartmentInspectionConfigurationRiskLevel
	            {
	                IdFireSafetyDepartmentInspectionConfiguration = currentConfig.Id,
	                IdRiskLevel = id,
	            };
	            Context.Add(risk);
	        }
	    }

	    private FireSafetyDepartmentInspectionConfiguration CreateNewConfiguration()
		{
			var currentConfig = new FireSafetyDepartmentInspectionConfiguration
			{ RiskLevels = new List<FireSafetyDepartmentInspectionConfigurationRiskLevel>() };
			Context.Add(currentConfig);
			return currentConfig;
		}
	}
}