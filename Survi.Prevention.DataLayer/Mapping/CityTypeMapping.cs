using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CityTypeMapping : EntityMappingConfiguration<CityType>
	{
		public override void Map(EntityTypeBuilder<CityType> b)
		{
			b.ToTable("tbl_city_type").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_country");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}