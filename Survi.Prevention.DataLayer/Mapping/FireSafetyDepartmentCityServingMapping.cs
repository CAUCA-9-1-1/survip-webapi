using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentCityServingMapping : EntityMappingConfiguration<FireSafetyDeparmentCityServing>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDeparmentCityServing> b)
		{
			b.ToTable("tbl_fire_safety_department_city_serving").HasKey(m => m.Id);

			b.Property(m => m.IdFireSafetyDepartment).HasColumnName("id_fire_safety_department_city_serving").IsRequired();
			b.Property(m => m.IdCity).HasColumnName("id_city").IsRequired();
			b.Property(m => m.Id).HasColumnName("id_fire_safety_department");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}