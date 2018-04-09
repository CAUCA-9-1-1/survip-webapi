using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class StateMapping : EntityMappingConfiguration<State>
	{
		public override void Map(EntityTypeBuilder<State> b)
		{
			b.ToTable("tbl_state").HasKey(m => m.Id);

			b.Property(m => m.AnsiCode).HasColumnName("ansi_code").HasMaxLength(2).IsRequired();
			b.Property(m => m.Id).HasColumnName("id_state");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Counties).WithOne(m => m.State).HasForeignKey(m => m.IdState);
			b.HasMany(m => m.Regions).WithOne(m => m.State).HasForeignKey(m => m.IdState);
		}
	}
}