using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAlarmPanelMapping : EntityMappingConfiguration<InspectionBuildingAlarmPanel>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAlarmPanel> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
			b.Property(m => m.Floor).HasMaxLength(100);
			b.Property(m => m.Wall).HasMaxLength(100);
			b.Property(m => m.Sector).HasMaxLength(100);
			b.HasOne(m => m.AlarmPanelType).WithMany().HasForeignKey(m => m.IdAlarmPanelType);
		}
	}
}