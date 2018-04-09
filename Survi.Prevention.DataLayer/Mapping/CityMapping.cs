using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CityMapping : EntityMappingConfiguration<City>
	{
		public override void Map(EntityTypeBuilder<City> b)
		{
			b.ToTable("tbl_region").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_country");
			b.Property(m => m.IdCityType).HasColumnName("id_city_type").IsRequired();
			b.Property(m => m.IdCounty).HasColumnName("id_county").IsRequired();			
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
			b.Property(m => m.Code).HasColumnName("code").IsRequired();
			b.Property(m => m.Code3Letters).HasColumnName("code3_letters").IsRequired();
			b.Property(m => m.EmailAddress).HasColumnName("email_address").IsRequired();

			b.HasMany(m => m.ServedByFireSafetyDepartments).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasMany(m => m.Lanes).WithOne(m => m.City).HasForeignKey(m => m.IdCity);
			b.HasOne(m => m.CityType).WithMany().HasForeignKey(m => m.IdCityType);
		}
	}
}