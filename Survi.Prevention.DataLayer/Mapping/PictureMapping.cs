using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PictureMapping : EntityMappingConfiguration<Picture>
	{
		public override void Map(EntityTypeBuilder<Picture> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Name).IsRequired().HasMaxLength(100);
			b.Property(m => m.Data).IsRequired();
            b.Property(m => m.SketchJson);
        }
	}
}
