using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAlarmPanelMapping : BaseImportedModelMapping<InspectionBuildingAlarmPanel>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAlarmPanel> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.Property(m => m.Floor).HasMaxLength(3);
			b.Property(m => m.Wall).HasMaxLength(3);
			b.Property(m => m.Sector).HasMaxLength(3);
			b.HasOne(m => m.AlarmPanelType).WithMany().HasForeignKey(m => m.IdAlarmPanelType);
		}
	}
}