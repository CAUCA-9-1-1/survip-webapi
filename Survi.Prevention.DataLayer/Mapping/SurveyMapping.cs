using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SurveyMapping : EntityMappingConfiguration<Survey>
	{
		public override void Map(EntityTypeBuilder<Survey> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Questions).WithOne(m => m.Survey).HasForeignKey(m => m.IdSurvey);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}