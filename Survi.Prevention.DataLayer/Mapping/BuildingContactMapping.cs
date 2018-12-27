using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingContactMapping : BaseImportedModelMapping<BuildingContact>
	{
		public override void Map(EntityTypeBuilder<BuildingContact> b)
		{
			b.HasQueryFilter(m => m.IsActive);

			b.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
			b.Property(m => m.LastName).HasMaxLength(100).IsRequired();
			b.Property(m => m.PhoneNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.PhoneNumberExtension).HasMaxLength(10).IsRequired();
			b.Property(m => m.PagerNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.PagerCode).HasMaxLength(10).IsRequired();
			b.Property(m => m.CellphoneNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.OtherNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.OtherNumberExtension).HasMaxLength(10).IsRequired();
		}
	}
}