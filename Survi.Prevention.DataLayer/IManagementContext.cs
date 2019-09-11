using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.Models.Security;
using Survi.Prevention.Models.SurveyManagement;
using System;

namespace Survi.Prevention.DataLayer
{
	public interface IManagementContext
	{
	    Guid? CurrentUserId { get; set; }
	    bool IsInImportationMode { get; set; }

        DbSet<Batch> Batches { get; set; }
        DbSet<BatchUser> BatchUsers { get; set; }
        DbSet<Inspection> Inspections { get; set; }
        DbSet<InspectionVisit> InspectionVisits { get; set; }
        DbSet<InspectionPicture> InspectionPictures { get; set; }
        DbSet<InspectionBuildingParticularRisk> InspectionBuildingParticularRisks { get; set; }
        DbSet<InspectionBuildingContact> InspectionBuildingContacts { get; set; }
        DbSet<InspectionBuilding> InspectionBuildings { get; set; }
        DbSet<InspectionBuildingCourse> InspectionBuildingCourses { get; set; }
        DbSet<InspectionBuildingCourseLane> InspectionBuildingCourseLanes { get; set; }
        DbSet<InspectionBuildingDetail> InspectionBuildingDetails { get; set; }
        DbSet<InspectionBuildingHazardousMaterial> InspectionBuildingHazardousMaterials { get; set; }
        DbSet<InspectionBuildingPersonRequiringAssistance> InspectionBuildingPersonsRequiringAssistance { get; set; }
        DbSet<InspectionBuildingSprinkler> InspectionBuildingSprinklers { get; set; }
        DbSet<InspectionBuildingAlarmPanel> InspectionBuildingAlarmPanels { get; set; }
        DbSet<InspectionBuildingAnomaly> InspectionBuildingAnomalies { get; set; }
        DbSet<InspectionBuildingAnomalyPicture> InspectionBuildingAnomalyPictures { get; set; }
        DbSet<InspectionBuildingParticularRiskPicture> InspectionBuildingParticularRiskPictures { get; set; }
        DbSet<InspectionBuildingFireHydrant> InspectionBuildingFireHydrants { get; set; }

        DbSet<Building> Buildings { get; set; }
        DbSet<BuildingCourse> BuildingCourses { get; set; }
        DbSet<BuildingCourseLane> BuildingCourseLanes { get; set; }
        DbSet<BuildingContact> BuildingContacts { get; set; }
        DbSet<BuildingDetail> BuildingDetails { get; set; }
        DbSet<BuildingHazardousMaterial> BuildingHazardousMaterials { get; set; }
        DbSet<BuildingPersonRequiringAssistance> BuildingPersonsRequiringAssistances { get; set; }
        DbSet<BuildingSprinkler> BuildingSprinklers { get; set; }
        DbSet<BuildingAlarmPanel> BuildingAlarmPanels { get; set; }
        DbSet<BuildingAnomaly> BuildingAnomalies { get; set; }
        DbSet<BuildingAnomalyPicture> BuildingAnomalyPictures { get; set; }
        DbSet<BuildingParticularRisk> BuildingParticularRisks { get; set; }
        DbSet<BuildingParticularRiskPicture> BuildingParticularRiskPictures { get; set; }
        DbSet<BuildingFireHydrant> BuildingFireHydrants { get; set; }

        DbSet<Country> Countries { get; set; }
        DbSet<RiskLevel> RiskLevels { get; set; }
        DbSet<UtilisationCode> UtilisationCodes { get; set; }
	    DbSet<UtilisationCodeLocalization> UtilisationCodeLocalizations { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<County> Counties { get; set; }
        DbSet<CityType> CityTypes { get; set; }
        DbSet<City> Cities { get; set; }

        DbSet<Lane> Lanes { get; set; }
        DbSet<LaneGenericCode> LaneGenericCodes { get; set; }
        DbSet<LanePublicCode> LanePublicCodes { get; set; }

        DbSet<Picture> Pictures { get; set; }
        DbSet<ReportConfigurationTemplate> ReportConfigurationTemplate { get; set; }
        DbSet<FireSafetyDepartment> FireSafetyDepartments { get; set; }
        DbSet<Firestation> Firestations { get; set; }
        DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        DbSet<ConstructionType> ConstructionTypes { get; set; }
        DbSet<RoofType> RoofTypes { get; set; }
        DbSet<RoofMaterialType> RoofMaterialTypes { get; set; }
        DbSet<SidingType> SidingTypes { get; set; }
        DbSet<SprinklerType> SprinklerTypes { get; set; }
        DbSet<PersonRequiringAssistanceType> PersonRequiringAssistanceTypes { get; set; }
        DbSet<BuildingType> BuildingTypes { get; set; }
        DbSet<AlarmPanelType> AlarmPanelTypes { get; set; }
        DbSet<FireHydrantType> FireHydrantTypes { get; set; }
        DbSet<FireHydrantConnectionType> FireHydrantConnectionTypes { get; set; }
        DbSet<ConstructionFireResistanceType> ConstructionFireResistanceTypes { get; set; }

        DbSet<HazardousMaterial> HazardousMaterials { get; set; }

        DbSet<FireHydrant> FireHydrants { get; set; }
        DbSet<Survey> Surveys { get; set; }
        DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        DbSet<SurveyQuestionChoice> SurveyQuestionChoices { get; set; }
        DbSet<InspectionSurveyAnswer> InspectionSurveyAnswers { get; set; }

        DbSet<FireSafetyDepartmentInspectionConfiguration> FireSafetyDepartmentInspectionConfigurations { get; set; }
        DbSet<FireSafetyDepartmentInspectionConfigurationRiskLevel> FireSafetyDepartmentInspectionConfigurationRiskLevels { get; set; }

        DbSet<FireSafetyDepartmentCityServing> FireSafetyDepartmentCityServings { get; set; }
        DbSet<Objectives> Objectives { get; set; }
		DbSet<UserFireSafetyDepartment> UserFireSafetyDepartments { get; set; }

        DbQuery<BuildingWithoutInspection> BuildingsWithoutInspection { get; set; }
        DbQuery<InspectionToDo> InspectionsToDo { get; set; }
        DbQuery<InspectionForApproval> InspectionsForApproval { get; set; }
        DbQuery<InspectionCompleted> InspectionsCompleted { get; set; }
        DbQuery<BuildingForReport> BuildingsForReport { get; set; }
        DbQuery<BuildingDetailForReport> BuildingDetailsForReport { get; set; }

        DbQuery<BatchInspectionBuilding> BatchInspectionBuildings { get; set; }
        DbQuery<AvailableBuildingForManagement> AvailableBuildingsForManagement { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
	    EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
	    EntityEntry Update(object entity);
	    EntityEntry Remove(object entity);
	    void RemoveRange(params object[] entities);
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        int SaveChanges();

	    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}