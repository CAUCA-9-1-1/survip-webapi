using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingHazardousMaterialMapping : BaseImportedModelMapping<BuildingHazardousMaterial>
	{
		public override void Map(EntityTypeBuilder<BuildingHazardousMaterial> b)
		{
			b.HasQueryFilter(m => m.IsActive);

			b.Property(m => m.Container).HasMaxLength(100).IsRequired();
			b.Property(m => m.CapacityContainer).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(4).IsRequired();
			b.Property(m => m.Place).HasMaxLength(150).IsRequired();
			b.Property(m => m.GasInlet).HasMaxLength(100).IsRequired();
			b.Property(m => m.Wall).HasMaxLength(3).IsRequired();
			b.Property(m => m.SupplyLine).HasMaxLength(50).IsRequired();
			b.Property(m => m.Sector).HasMaxLength(3).IsRequired();
			b.Property(m => m.SecurityPerimeter).IsRequired();
			b.Property(m => m.OtherInformation).IsRequired();
			b.Property(m => m.TankType).IsRequired();

			b.HasOne(m => m.Material).WithMany().HasForeignKey(m => m.IdHazardousMaterial);
			b.HasOne(m => m.Unit).WithMany().HasForeignKey(m => m.IdUnitOfMeasure);
		}
	}
}