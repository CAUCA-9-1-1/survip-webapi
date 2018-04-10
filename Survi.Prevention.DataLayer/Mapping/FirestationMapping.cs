using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FirestationMapping : EntityMappingConfiguration<Firestation>
	{
		public override void Map(EntityTypeBuilder<Firestation> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Name).HasMaxLength(50).IsRequired();
			b.Property(m => m.PhoneNumber).HasMaxLength(10);
			b.Property(m => m.FaxNumber).HasMaxLength(10);
			b.Property(m => m.Email).HasMaxLength(100);
			b.HasOne(m => m.Building).WithMany().HasForeignKey(m => m.IdBuilding);
		}
	}
}