using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CityMapping : EntityMappingConfiguration<City>
	{
		public override void Map(EntityTypeBuilder<City> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.EmailAddress).HasMaxLength(100).IsRequired();
			b.Property(m => m.Code).HasMaxLength(10).IsRequired();
			b.Property(m => m.Code3Letters).HasMaxLength(3).IsRequired();
			b.HasMany(m => m.ServedByFireSafetyDepartments).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasMany(m => m.Lanes).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasOne(m => m.CityType).WithMany().HasForeignKey(m => m.IdCityType);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}