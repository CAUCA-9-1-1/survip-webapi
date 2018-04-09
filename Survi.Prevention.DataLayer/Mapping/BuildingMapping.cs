using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingMapping : EntityMappingConfiguration<Building>
	{
		public override void Map(EntityTypeBuilder<Building> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CivicNumber).HasMaxLength(15).IsRequired();
			b.Property(m => m.CivicLetter).HasMaxLength(10).IsRequired();
			b.Property(m => m.CivicSupp).HasMaxLength(10).IsRequired();
			b.Property(m => m.CivicLetterSupp).HasMaxLength(10).IsRequired();
			b.Property(m => m.AppartmentNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(10).IsRequired();
			b.Property(m => m.PostalCode).HasMaxLength(6).IsRequired();
			b.Property(m => m.Source).HasMaxLength(25).IsRequired();
			b.Property(m => m.UtilisationDescription).HasMaxLength(255).IsRequired();
			b.Property(m => m.Matricule).HasMaxLength(18).IsRequired();
			b.Property(m => m.CoordinatesSource).HasMaxLength(50).IsRequired();
			b.Property(m => m.Details).IsRequired();

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.RiskLevel).WithMany().HasForeignKey(m => m.IdRiskLevel);
			b.HasOne(m => m.UtilisationCode).WithMany().HasForeignKey(m => m.IdUtilisationCode);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
			b.HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.IdParentBuilding);

			b.HasMany(m => m.Contacts).WithOne(m => m.Building).HasForeignKey(m => m.IdBuilding);
			b.HasMany(m => m.HazardousMaterials).WithOne(m => m.Building).HasForeignKey(m => m.IdBuilding);
			b.HasMany(m => m.PersonsRequiringAssistance).WithOne(m => m.Building).HasForeignKey(m => m.IdBuilding);
		}
	}
}