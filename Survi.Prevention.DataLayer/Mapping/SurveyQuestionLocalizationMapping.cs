using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyQuestionLocalizationMapping : EntityMappingConfiguration<SurveyQuestionLocalization>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestionLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_survey_question");
			b.Property(m => m.Name).HasMaxLength(100).IsRequired();
			b.Property(m => m.Title).HasMaxLength(100).IsRequired();
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}