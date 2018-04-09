using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PersonRequiringAssistanceTypeMapping : EntityMappingConfiguration<PersonRequiringAssistanceType>
	{
		public override void Map(EntityTypeBuilder<PersonRequiringAssistanceType> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}