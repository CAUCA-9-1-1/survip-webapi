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

			b.HasMany(m => m.Choices)
				.WithOne(m => m.Question)
				.HasForeignKey(m => m.IdSurveyQuestion);
			b.HasMany(m => m.Localizations)
				.WithOne()
				.HasForeignKey(m => m.IdParent);
		}
	}
}