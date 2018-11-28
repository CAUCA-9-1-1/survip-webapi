using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingHazardousMaterialMapping : BaseImportedModelMapping<InspectionBuildingHazardousMaterial>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingHazardousMaterial> b)
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