using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionAnswerMapping : EntityMappingConfiguration<InspectionAnswer>
	{
		public override void Map(EntityTypeBuilder<InspectionAnswer> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.AnsweredBy).WithMany().HasForeignKey(m => m.IdWebuserAnsweredBy);
			b.HasMany(m => m.SurveyAnswers).WithOne(m => m.InspectionAnswer).HasForeignKey(m => m.IdInspectionAnswer);
		}
	}
}