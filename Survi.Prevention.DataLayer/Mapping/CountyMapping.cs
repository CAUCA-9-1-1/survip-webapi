using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountyMapping : BaseImportedModelMapping<County>
	{
		public override void Map(EntityTypeBuilder<County> b)
		{
			b.HasMany(m => m.Cities).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
			b.HasMany(m => m.FireSafetyDepartments).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}