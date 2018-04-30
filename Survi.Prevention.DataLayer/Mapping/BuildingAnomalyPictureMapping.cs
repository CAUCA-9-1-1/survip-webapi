using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingAnomalyPictureMapping : EntityMappingConfiguration<BuildingAnomalyPicture>
	{
		public override void Map(EntityTypeBuilder<BuildingAnomalyPicture> b)
		{
			b.HasKey(m => m.Id);
		}
	}
}