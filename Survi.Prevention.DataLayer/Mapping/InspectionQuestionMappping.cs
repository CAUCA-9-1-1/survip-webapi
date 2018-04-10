using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionQuestionMappping : EntityMappingConfiguration<InspectionQuestion>
	{
		public override void Map(EntityTypeBuilder<InspectionQuestion> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Answer).HasMaxLength(200).IsRequired();
			b.HasOne(m => m.Question).WithMany().HasForeignKey(m => m.IdSurveyQuestion);
			b.HasOne(m => m.Choice).WithMany().HasForeignKey(m => m.IdSurveyQuestionChoice);
		}
	}
}