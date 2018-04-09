using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountyMapping : EntityMappingConfiguration<County>
	{
		public override void Map(EntityTypeBuilder<County> b)
		{
			b.HasKey(m => m.Id);

			b.HasMany(m => m.Cities).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
			b.HasMany(m => m.FireSafetyDepartments).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}