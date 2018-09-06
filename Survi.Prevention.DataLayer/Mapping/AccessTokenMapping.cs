using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class AccessTokenMapping : EntityMappingConfiguration<AccessToken>
	{
		public override void Map(EntityTypeBuilder<AccessToken> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Id).IsRequired();
			b.Property(m => m.IdWebuser).IsRequired();
			b.Property(m => m.TokenForAccess).HasMaxLength(500).IsRequired();
			b.Property(m => m.RefreshToken).HasMaxLength(100).IsRequired();
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.ExpiresIn).IsRequired();
			b.HasOne(m => m.User).WithMany().HasForeignKey(m => m.IdWebuser);
		}
	}
}
