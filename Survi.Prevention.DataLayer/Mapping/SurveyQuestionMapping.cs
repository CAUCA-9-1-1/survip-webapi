using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyQuestionMapping : EntityMappingConfiguration<SurveyQuestion>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestion> b)
		{
			b.ToTable("tbl_survey_question")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_survey_question");
			b.Property(m => m.QuestionType).HasColumnName("question_type").IsRequired();
			b.Property(m => m.IdSurvey).HasColumnName("id_survey").IsRequired();
			b.Property(m => m.IdSurveyQuestionNext).HasColumnName("id_survey_question_next");

			b.HasOne(m => m.NextQuestion)
				.WithMany()
				.HasForeignKey(m => m.IdSurveyQuestionNext);

			b.HasMany(m => m.Choices)
				.WithOne(m => m.Question)
				.HasForeignKey(m => m.IdSurveyQuestion);
		}
	}
}