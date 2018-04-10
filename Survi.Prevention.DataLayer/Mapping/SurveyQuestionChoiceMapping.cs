using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyQuestionChoiceMapping : EntityMappingConfiguration<SurveyQuestionChoice>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestionChoice> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.NextQuestion)
				.WithMany()
				.HasForeignKey(m => m.IdSurveyQuestionNext);
			b.HasMany(m => m.Localizations)
				.WithOne(m => m.Parent)
				.HasForeignKey(m => m.IdParent);
		}
	}
}