using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingContactMapping : EntityMappingConfiguration<BuildingContact>
	{
		public override void Map(EntityTypeBuilder<BuildingContact> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);

			b.Property(m => m.FirstName).HasMaxLength(30).IsRequired();
			b.Property(m => m.LastName).HasMaxLength(30).IsRequired();
			b.Property(m => m.PhoneNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.PhoneNumberExtension).HasMaxLength(10).IsRequired();
			b.Property(m => m.PagerNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.PagerCode).HasMaxLength(10).IsRequired();
			b.Property(m => m.CellphoneNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.OtherNumber).HasMaxLength(10).IsRequired();
			b.Property(m => m.OtherNumberExtension).HasMaxLength(10).IsRequired();

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}