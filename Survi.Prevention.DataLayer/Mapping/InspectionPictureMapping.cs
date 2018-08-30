using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionPictureMapping : EntityMappingConfiguration<InspectionPicture>
	{
		public override void Map(EntityTypeBuilder<InspectionPicture> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Name).IsRequired().HasMaxLength(100);
			b.Property(m => m.Data).IsRequired();
		}
	}
}