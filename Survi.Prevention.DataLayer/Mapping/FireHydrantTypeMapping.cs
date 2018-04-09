using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantTypeMapping : EntityMappingConfiguration<FireHydrantType>
	{
		public override void Map(EntityTypeBuilder<FireHydrantType> b)
		{
			b.ToTable("tbl_fire_hydrant_type").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_fire_hydrant_type");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}