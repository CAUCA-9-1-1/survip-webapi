using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class AlarmPanelTypeMapping : EntityMappingConfiguration<AlarmPanelType>
	{
		public override void Map(EntityTypeBuilder<AlarmPanelType> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}