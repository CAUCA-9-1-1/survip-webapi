using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionTypeMapping : EntityMappingConfiguration<ConstructionType>
	{
		public override void Map(EntityTypeBuilder<ConstructionType> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}