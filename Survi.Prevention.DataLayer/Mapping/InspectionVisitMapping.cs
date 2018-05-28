using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionVisitMapping : EntityMappingConfiguration<InspectionVisit>
	{
		public override void Map(EntityTypeBuilder<InspectionVisit> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.VisitedBy).WithMany().HasForeignKey(m => m.IdWebuserVisitedBy);
		}
	}
}