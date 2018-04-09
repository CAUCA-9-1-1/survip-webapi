using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingHazardousMaterialMapping : EntityMappingConfiguration<BuildingHazardousMaterial>
	{
		public override void Map(EntityTypeBuilder<BuildingHazardousMaterial> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Container).HasMaxLength(100).IsRequired();
			b.Property(m => m.CapacityContainer).HasMaxLength(7).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(4).IsRequired();
			b.Property(m => m.Place).HasMaxLength(150).IsRequired();
			b.Property(m => m.GasInlet).HasMaxLength(100).IsRequired();
			b.Property(m => m.SecurityPerimeter).IsRequired();
			b.Property(m => m.OtherInformation).IsRequired();

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.Material).WithMany().HasForeignKey(m => m.IdHazardousMaterial);
			b.HasOne(m => m.Unit).WithMany().HasForeignKey(m => m.IdUnitOfMeasure);
		}
	}
}