using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyMapping : EntityMappingConfiguration<Survey>
	{
		public override void Map(EntityTypeBuilder<Survey> b)
		{
			b.ToTable("tbl_survey")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_survey");
			b.Property(m => m.SurveyType).HasColumnName("survey_type").IsRequired();
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Questions)
				.WithOne(m => m.Survey)
				.HasForeignKey(m => m.IdSurvey);
		}
	}
}