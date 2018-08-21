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

			b.Property(m => m.IsSurveyCompleted);
			b.HasOne(m => m.Survey).WithMany().HasForeignKey(m => m.IdSurvey);
			b.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.IdWebuserCreatedBy);
			b.HasOne(m => m.AssignedTo).WithMany().HasForeignKey(m => m.IdWebuserAssignedTo);			
			b.HasOne(m => m.MainBuilding).WithMany().HasForeignKey(m => m.IdBuilding);

			b.HasMany(m => m.Visits).WithOne(m => m.Inspection).HasForeignKey(m => m.IdInspection);
			b.HasMany(m => m.SurveyAnswers).WithOne(m => m.Inspection).HasForeignKey(m => m.IdInspection);

			b.HasMany(m => m.Buildings).WithOne(m => m.Inspection).HasForeignKey(m => m.IdInspection);
		}
	}
}