using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyMapping : EntityMappingConfiguration<Survey>
	{
		public override void Map(EntityTypeBuilder<Survey> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Questions).WithOne(m => m.Survey).HasForeignKey(m => m.IdSurvey);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}

	public class SurveyLocalizationMapping : EntityMappingConfiguration<SurveyLocalization>
	{
		public override void Map(EntityTypeBuilder<SurveyLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_survey");
		}
	}

	public class SurveyQuestionLocalizationMapping : EntityMappingConfiguration<SurveyQuestionLocalization>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestionLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_survey_question");
		}
	}

	public class SurveyQuestionChoiceLocalizationMapping : EntityMappingConfiguration<SurveyQuestionChoiceLocalization>
	{
		public override void Map(EntityTypeBuilder<SurveyQuestionChoiceLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_survey_question_choice");
		}
	}

}