using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingPersonRequiringAssistanceMapping : BaseImportedModelMapping<BuildingPersonRequiringAssistance>
	{
		public override void Map(EntityTypeBuilder<BuildingPersonRequiringAssistance> b)
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