using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RiskLevelLocalizationMapping : EntityMappingConfiguration<RiskLevelLocalization>
	{
		public override void Map(EntityTypeBuilder<RiskLevelLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_risk_level");
		}
	}
}