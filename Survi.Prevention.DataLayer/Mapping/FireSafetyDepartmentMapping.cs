using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentMapping : BaseImportedModelMapping<FireSafetyDepartment>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartment> b)
		{
			b.Property(m => m.Language).HasMaxLength(2).IsRequired();
			b.HasMany(m => m.Firestations).WithOne(m => m.FireSafetyDepartment).HasForeignKey(m => m.IdFireSafetyDepartment);
			b.HasMany(m => m.FireSafetyDepartmentServing).WithOne(m => m.FireSafetyDepartment).HasForeignKey(m => m.IdFireSafetyDepartment);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}