using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class AlarmPanelTypeLocalizationMapping : EntityMappingConfiguration<AlarmPanelTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<AlarmPanelTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_alarm_panel_type");
		}
	}
}