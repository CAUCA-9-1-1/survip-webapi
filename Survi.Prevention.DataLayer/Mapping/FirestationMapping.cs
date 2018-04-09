using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FirestationMapping : EntityMappingConfiguration<Firestation>
	{
		public override void Map(EntityTypeBuilder<Firestation> b)
		{
			b.ToTable("tbl_firestation").HasKey(m => m.Id);

			b.Property(m => m.Name).HasColumnName("name").IsRequired();
			b.Property(m => m.PhoneNumber).HasColumnName("phone_number");
			b.Property(m => m.FaxNumber).HasColumnName("fax_number");
			b.Property(m => m.Email).HasColumnName("email");

			b.Property(m => m.IdBuilding).HasColumnName("id_building");
			b.Property(m => m.IdFireSafetyDepartment).HasColumnName("id_fire_safety_department").IsRequired();
			b.Property(m => m.Id).HasColumnName("id_firestation");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasOne(m => m.Building).WithMany().HasForeignKey(m => m.IdBuilding);
		}
	}
}