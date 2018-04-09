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
			b.HasMany(m => m.ServedByFireSafetyDepartments).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasMany(m => m.Lanes).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasOne(m => m.CityType).WithMany().HasForeignKey(m => m.IdCityType);
		}
	}
}