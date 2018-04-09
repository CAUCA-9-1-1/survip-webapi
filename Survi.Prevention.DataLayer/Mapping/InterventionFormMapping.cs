using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormMapping : EntityMappingConfiguration<InterventionForm>
	{
		public override void Map(EntityTypeBuilder<InterventionForm> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Name).HasMaxLength(50);
			b.Property(m => m.Number).HasMaxLength(50);
			b.Property(m => m.OtherInformation).HasMaxLength(255);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPictureSitePlan);
			b.HasOne(m => m.Transversal).WithMany().HasForeignKey(m => m.IdLaneTransversal);
			b.HasMany(m => m.Buildings).WithOne(m => m.Form).HasForeignKey(m => m.IdInterventionForm);
			b.HasMany(m => m.Courses).WithOne(m => m.Form).HasForeignKey(m => m.IdInterventionForm);
			b.HasMany(m => m.FireHydrants).WithOne(m => m.Form).HasForeignKey(m => m.IdInterventionForm);
		}
	}
}