using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyQuestionMapping : EntityMappingConfiguration<SurveyQuestion>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestion> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.NextQuestion)
				.WithMany()
				.HasForeignKey(m => m.IdSurveyQuestionNext);

			b.HasMany(m => m.Choices)
				.WithOne(m => m.Question)
				.HasForeignKey(m => m.IdSurveyQuestion);
			b.HasMany(m => m.Localizations)
				.WithOne(m => m.Parent)
				.HasForeignKey(m => m.IdParent);
			b.Property(m => m.IsRecursive);
			b.Property(m => m.idSurveyQuestionParent);
		}
	}
}