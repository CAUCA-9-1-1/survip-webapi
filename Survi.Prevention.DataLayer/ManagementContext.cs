using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContext : DbContext
	{
		public DbSet<AccessSecretKey> AccessSecretKeys { get; set; }
		public DbSet<AccessToken> AccessTokens { get; set; }
		public DbSet<Webuser> Webusers { get; set; }

		public DbSet<Permission> Permissions { get; set; }
		public DbSet<PermissionSystem> PermissionSystems { get; set; }

		public DbSet<Batch> Batches { get; set; }
		public DbSet<Inspection> Inspections { get; set; }

		public DbSet<Building> Buildings { get; set; }		
		public DbSet<BuildingCourse> BuildingCourses { get; set; }
		public DbSet<BuildingCourseLane> BuildingCourseLanes { get; set; }

		public DbSet<Country> Countries { get; set; }
		public DbSet<RiskLevel> RiskLevels { get; set; }
		public DbSet<UtilisationCode> UtilisationCodes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Lane> Lanes { get; set; }
		public DbSet<LaneGenericCode> LaneGenericCodes { get; set; }
		public DbSet<LanePublicCode> LanePublicCodes { get; set; }

		public DbSet<Picture> Pictures { get; set; }
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
		public DbSet<OperatorType> OperatorTypes { get; set; }
		public DbSet<ConstructionFireResistanceType> ConstructionFireResistanceTypes { get; set; }

        public DbSet<FireHydrant> FireHydrants { get; set; }
		public DbSet<BuildingFireHydrant> BuildingFireHydrants { get; set; }

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
			modelBuilder.UseAutoSnakeCaseMapping();
			this.UseAutoDetectedMappings(modelBuilder);
		}
	}
}