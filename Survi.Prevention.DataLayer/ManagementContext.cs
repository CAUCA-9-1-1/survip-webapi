using Cause.SecurityManagement;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer.InitialData;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Base;
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
using System.Linq;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContext : BaseSecurityContext<User>, IManagementContext
	{
	    public Guid? CurrentUserId { get; set; }
	    public bool IsInImportationMode { get; set; } = false;
		public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchUser> BatchUsers { get; set; }
		public DbSet<Inspection> Inspections { get; set; }
		public DbSet<InspectionVisit> InspectionVisits { get; set; }
		public DbSet<InspectionPicture> InspectionPictures { get; set; }
		public DbSet<InspectionBuildingParticularRisk> InspectionBuildingParticularRisks { get; set; }
		public DbSet<InspectionBuildingContact> InspectionBuildingContacts { get; set; }
		public DbSet<InspectionBuilding> InspectionBuildings { get; set; }
		public DbSet<InspectionBuildingCourse> InspectionBuildingCourses { get; set; }
		public DbSet<InspectionBuildingCourseLane> InspectionBuildingCourseLanes { get; set; }
		public DbSet<InspectionBuildingDetail> InspectionBuildingDetails { get; set; }
		public DbSet<InspectionBuildingHazardousMaterial> InspectionBuildingHazardousMaterials { get; set; }
		public DbSet<InspectionBuildingPersonRequiringAssistance> InspectionBuildingPersonsRequiringAssistance { get; set; }
		public DbSet<InspectionBuildingSprinkler> InspectionBuildingSprinklers { get; set; }
		public DbSet<InspectionBuildingAlarmPanel> InspectionBuildingAlarmPanels { get; set; }
		public DbSet<InspectionBuildingAnomaly> InspectionBuildingAnomalies { get; set; }
		public DbSet<InspectionBuildingAnomalyPicture> InspectionBuildingAnomalyPictures { get; set; }
		public DbSet<InspectionBuildingParticularRiskPicture> InspectionBuildingParticularRiskPictures { get; set; }
		public DbSet<InspectionBuildingFireHydrant> InspectionBuildingFireHydrants { get; set; }

		public DbSet<Building> Buildings { get; set; }		
		public DbSet<BuildingCourse> BuildingCourses { get; set; }
		public DbSet<BuildingCourseLane> BuildingCourseLanes { get; set; }
		public DbSet<BuildingContact> BuildingContacts { get; set; }
		public DbSet<BuildingDetail> BuildingDetails { get; set; }
		public DbSet<BuildingHazardousMaterial> BuildingHazardousMaterials { get; set; }
		public DbSet<BuildingPersonRequiringAssistance> BuildingPersonsRequiringAssistances { get; set; }
		public DbSet<BuildingSprinkler> BuildingSprinklers { get; set; }
		public DbSet<BuildingAlarmPanel> BuildingAlarmPanels { get; set; } 
        public DbSet<BuildingAnomaly> BuildingAnomalies { get; set; }
		public DbSet<BuildingAnomalyPicture> BuildingAnomalyPictures { get; set; }
		public DbSet<BuildingParticularRisk> BuildingParticularRisks { get; set; }
		public DbSet<BuildingParticularRiskPicture> BuildingParticularRiskPictures { get; set; }
		public DbSet<BuildingFireHydrant> BuildingFireHydrants { get; set; }

		public DbSet<Country> Countries { get; set; }
		public DbSet<RiskLevel> RiskLevels { get; set; }
		public DbSet<UtilisationCode> UtilisationCodes { get; set; }
	    public DbSet<UtilisationCodeLocalization> UtilisationCodeLocalizations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Lane> Lanes { get; set; }
        public DbSet<LaneGenericCode> LaneGenericCodes { get; set; }
		public DbSet<LanePublicCode> LanePublicCodes { get; set; }

		public DbSet<Picture> Pictures { get; set; }
		public DbSet<ReportConfigurationTemplate> ReportConfigurationTemplate { get; set; }
        public DbSet<FireSafetyDepartment> FireSafetyDepartments { get; set; }
        public DbSet<Firestation> Firestations { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

		public DbSet<ConstructionType> ConstructionTypes { get; set; }
		public DbSet<RoofType> RoofTypes { get; set; }
		public DbSet<RoofMaterialType> RoofMaterialTypes { get; set; }
		public DbSet<SidingType> SidingTypes { get; set; }
		public DbSet<SprinklerType> SprinklerTypes { get; set; }
		public DbSet<PersonRequiringAssistanceType> PersonRequiringAssistanceTypes { get; set; }
		public DbSet<BuildingType> BuildingTypes { get; set; }
		public DbSet<AlarmPanelType> AlarmPanelTypes { get; set; }
		public DbSet<FireHydrantType> FireHydrantTypes { get; set; }
		public DbSet<FireHydrantConnectionType> FireHydrantConnectionTypes { get; set; }
		public DbSet<ConstructionFireResistanceType> ConstructionFireResistanceTypes { get; set; }

		public DbSet<HazardousMaterial> HazardousMaterials { get; set; }

        public DbSet<FireHydrant> FireHydrants { get; set; }		
		public DbSet<Survey> Surveys { get; set; }
		public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
		public DbSet<SurveyQuestionChoice> SurveyQuestionChoices { get; set; }
		public DbSet<InspectionSurveyAnswer> InspectionSurveyAnswers { get; set; }

        public DbSet<FireSafetyDepartmentInspectionConfiguration> FireSafetyDepartmentInspectionConfigurations { get; set; }
		public DbSet<FireSafetyDepartmentInspectionConfigurationRiskLevel> FireSafetyDepartmentInspectionConfigurationRiskLevels { get; set; }

        public DbSet<FireSafetyDepartmentCityServing> FireSafetyDepartmentCityServings { get; set; }
        public DbSet<Objectives> Objectives { get; set; }
        public DbSet<UserFireSafetyDepartment> UserFireSafetyDepartments { get; set; }

        public DbQuery<BuildingWithoutInspection> BuildingsWithoutInspection { get; set; }
		public DbQuery<InspectionToDo> InspectionsToDo { get; set; }
		public DbQuery<InspectionForApproval> InspectionsForApproval { get; set; }
		public DbQuery<InspectionCompleted> InspectionsCompleted { get; set; }
		public DbQuery<BuildingForReport> BuildingsForReport { get; set; }
		public DbQuery<BuildingDetailForReport> BuildingDetailsForReport { get; set; }

		public DbQuery<BatchInspectionBuilding> BatchInspectionBuildings { get; set; }
		public DbQuery<AvailableBuildingForManagement> AvailableBuildingsForManagement { get; set; }

		public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.EnableSensitiveDataLogging();			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresExtension("uuid-ossp");
			modelBuilder.HasPostgresExtension("postgis");
			modelBuilder.UseAutoSnakeCaseMapping();
			this.UseAutoDetectedMappings(modelBuilder);
			AddSecurityManagementMappings(modelBuilder);

			modelBuilder.Query<BuildingWithoutInspection>()
				.ToView("building_with_no_active_inspection");
			modelBuilder.Query<InspectionToDo>()
				.ToView("building_with_todo_inspection");
			modelBuilder.Query<InspectionForApproval>()
				.ToView("building_with_ready_for_approbation_inspection");
			modelBuilder.Query<InspectionCompleted>()
				.ToView("building_with_completed_inspection");
			modelBuilder.Query<BuildingForReport>()
				.ToView("building_for_report");
			modelBuilder.Query<BuildingDetailForReport>()
				.ToView("building_detail_for_report");
			modelBuilder.Query<BatchInspectionBuilding>()
				.ToView("batch_inspection_building");
			modelBuilder.Query<AvailableBuildingForManagement>()
				.ToView("available_building_for_management");
			modelBuilder.SeedInitialData();
			//modelBuilder.SeedInitialDataForDevelopment();
		}

        public override int SaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker
                .Entries<BaseModel>()
                .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added))            
                dbEntityEntry.Entity.SetAsModified(CurrentUserId, IsInImportationMode);

            return base.SaveChanges();
        }
    }
}