using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class LaneMapping : EntityMappingConfiguration<Lane>
	{
		public override void Map(EntityTypeBuilder<Lane> b)
		{
			b.ToTable("tbl_lane");

			b.HasKey(m => m.Id);
			b.Property(m => m.IdPublicCode).HasColumnName("id_public_code").IsRequired();
			b.Property(m => m.IdLaneGenericCode).HasColumnName("id_lane_generic_code").IsRequired();
			b.Property(m => m.IdCity).HasColumnName("id_city").IsRequired();
			b.Property(m => m.Id).HasColumnName("id_lane");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasOne(m => m.LaneGenericCode).WithMany().HasForeignKey(m => m.IdLaneGenericCode);
			b.HasOne(m => m.PublicCode).WithMany().HasForeignKey(m => m.IdPublicCode);
		}
	}
}