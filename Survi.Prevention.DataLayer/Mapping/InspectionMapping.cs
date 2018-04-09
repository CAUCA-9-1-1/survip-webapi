using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionMapping : EntityMappingConfiguration<Inspection>
	{
		public override void Map(EntityTypeBuilder<Inspection> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.Survey).WithMany().HasForeignKey(m => m.IdSurvey);
			b.HasOne(m => m.Form).WithMany().HasForeignKey(m => m.IdInterventionForm);
			b.HasOne(m => m.InspectedBy).WithMany().HasForeignKey(m => m.IdWebuserInspectedBy);
			b.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.IdWebuserCreatedBy);
			b.HasOne(m => m.AssignedTo).WithMany().HasForeignKey(m => m.IdWebUserAssignedTo);
			b.HasMany(m => m.Answers).WithOne(m => m.Inspection).HasForeignKey(m => m.IdInspection);
		}
	}
}