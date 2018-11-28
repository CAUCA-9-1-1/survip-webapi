using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingAnomalyPictureMapping : BaseImportedModelMapping<BuildingAnomalyPicture>
	{
		public override void Map(EntityTypeBuilder<BuildingAnomalyPicture> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Picture).WithMany()
				.HasForeignKey(m => m.IdPicture)
				.OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull);
		}
	}
}