using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PictureMapping : EntityMappingConfiguration<Picture>
	{
		public override void Map(EntityTypeBuilder<Picture> b)
		{
			b.ToTable("tbl_picture").HasKey(m => m.Id);

			b.Property(m => m.Name).HasColumnName("name").HasMaxLength(100);
			b.Property(m => m.ActualPicture).HasColumnName("picture").IsRequired();
			b.Property(m => m.Id).HasColumnName("id_operator_type");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}