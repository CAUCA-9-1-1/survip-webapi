using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingPersonRequiringAssistanceMapping : EntityMappingConfiguration<BuildingPersonRequiringAssistance>
	{
		public override void Map(EntityTypeBuilder<BuildingPersonRequiringAssistance> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Description).IsRequired();
			b.Property(m => m.PersonName).HasMaxLength(60).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(3).IsRequired();
			b.Property(m => m.Local).HasMaxLength(10).IsRequired();
			b.Property(m => m.ContactName).HasMaxLength(60).IsRequired();
			b.Property(m => m.ContactPhoneNumber).HasMaxLength(10).IsRequired();

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.PersonType).WithMany().HasForeignKey(m => m.IdPersonRequiringAssistanceType);
		}
	}

	public class InspectionBuildingPersonRequiringAssistanceMapping : EntityMappingConfiguration<InspectionBuildingPersonRequiringAssistance>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingPersonRequiringAssistance> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Description).IsRequired();
			b.Property(m => m.PersonName).HasMaxLength(60).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(3).IsRequired();
			b.Property(m => m.Local).HasMaxLength(10).IsRequired();
			b.Property(m => m.ContactName).HasMaxLength(60).IsRequired();
			b.Property(m => m.ContactPhoneNumber).HasMaxLength(10).IsRequired();

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.PersonType).WithMany().HasForeignKey(m => m.IdPersonRequiringAssistanceType);
		}
	}
}