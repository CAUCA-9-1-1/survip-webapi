using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormMapping : EntityMappingConfiguration<BatchUser>
	{
		public override void Map(EntityTypeBuilder<BatchUser> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.User).WithMany().HasForeignKey(m => m.IdWebuser);
		}
	}
}