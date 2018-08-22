using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingAlarmPanelMapping : EntityMappingConfiguration<BuildingAlarmPanel>
	{
		public override void Map(EntityTypeBuilder<BuildingAlarmPanel> b)
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