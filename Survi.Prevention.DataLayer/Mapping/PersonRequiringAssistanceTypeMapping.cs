using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PersonRequiringAssistanceTypeMapping : BaseImportedModelMapping<PersonRequiringAssistanceType>
	{
		public override void Map(EntityTypeBuilder<PersonRequiringAssistanceType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}