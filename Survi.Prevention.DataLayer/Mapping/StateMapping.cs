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
			b.HasKey(m => m.Id);
			b.Property(m => m.AnsiCode).HasMaxLength(2).IsRequired();
			b.HasMany(m => m.Counties).WithOne(m => m.State).HasForeignKey(m => m.IdState);
			b.HasMany(m => m.Regions).WithOne(m => m.State).HasForeignKey(m => m.IdState);
		}
	}
}