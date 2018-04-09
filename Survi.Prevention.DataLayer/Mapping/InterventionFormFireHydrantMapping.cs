using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormFireHydrantMapping : EntityMappingConfiguration<InterventionFormFireHydrant>
	{
		public override void Map(EntityTypeBuilder<InterventionFormFireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}