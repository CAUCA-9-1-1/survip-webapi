using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyQuestionChoiceMapping : EntityMappingConfiguration<SurveyQuestionChoice>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestionChoice> b)
		{
			b.ToTable("tbl_survey_choice")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_survey_choice");
			b.Property(m => m.IdSurveyQuestion).HasColumnName("id_survey_question").IsRequired();
			b.Property(m => m.IdSurveyQuestionNext).HasColumnName("id_survey_question_next");
			b.Property(m => m.IsActive).HasColumnName("is_active");

			b.HasOne(m => m.NextQuestion)
				.WithMany()
				.HasForeignKey(m => m.IdSurveyQuestionNext);
		}
	}
}