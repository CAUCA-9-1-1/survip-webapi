using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
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
		public DbSet<InterventionForm> InterventionForms { get; set; }
		public DbSet<InterventionFormCourse> InterventionFormCourses { get; set; }
		public DbSet<InterventionFormBuilding> InterventionFormBuildings { get; set; }
		public DbSet<InterventionFormFireHydrant> InterventionFormFireHydrants { get; set; }

		public DbSet<Building> Buildings { get; set; }		
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

		public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseAutoSnakeCaseMapping();
			this.UseAutoDetectedMappings(modelBuilder);
		}
	}
}