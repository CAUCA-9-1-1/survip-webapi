using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentMapping : EntityMappingConfiguration<FireSafetyDepartment>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartment> b)
		{
			b.ToTable("tbl_fire_safety_department").HasKey(m => m.Id);

			b.Property(m => m.Language).HasColumnName("language").HasMaxLength(2).IsRequired();
			b.Property(m => m.IdCounty).HasColumnName("id_county").IsRequired();
			b.Property(m => m.Id).HasColumnName("id_fire_safety_department");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Firestations).WithOne(m => m.FireSafetyDepartment).HasForeignKey(m => m.IdFireSafetyDepartment);
			b.HasMany(m => m.FireSafetyDeparmentServing).WithOne(m => m.FireSafetyDepartment).HasForeignKey(m => m.IdFireSafetyDepartment);
		}
	}
}