using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingPersonRequiringAssistanceMapping : BaseImportedModelMapping<InspectionBuildingPersonRequiringAssistance>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingPersonRequiringAssistance> b)
		{
			b.HasQueryFilter(m => m.IsActive);

			b.Property(m => m.Description).IsRequired();
			b.Property(m => m.PersonName).HasMaxLength(60).IsRequired();
			b.Property(m => m.Floor).HasMaxLength(3).IsRequired();
			b.Property(m => m.Local).HasMaxLength(10).IsRequired();
			b.Property(m => m.ContactName).HasMaxLength(60).IsRequired();
			b.Property(m => m.ContactPhoneNumber).HasMaxLength(10).IsRequired();

			b.HasOne(m => m.PersonType).WithMany().HasForeignKey(m => m.IdPersonRequiringAssistanceType);
		}
	}
}