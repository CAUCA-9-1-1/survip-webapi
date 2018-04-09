using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class AccessTokenMapping : EntityMappingConfiguration<AccessToken>
	{
		public override void Map(EntityTypeBuilder<AccessToken> b)
		{
			b.ToTable("tbl_access_token")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_access_token").IsRequired();
			b.Property(m => m.IdWebuser).HasColumnName("id_webuser").IsRequired();
			b.Property(m => m.TokenForAccess).HasColumnName("access_token").HasMaxLength(500).IsRequired();
			b.Property(m => m.RefreshToken).HasColumnName("refresh_token").HasMaxLength(100).IsRequired();
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.ExpiresIn).HasColumnName("expires_in").IsRequired();

			b.HasOne(m => m.User)
				.WithMany()
				.HasForeignKey(m => m.IdWebuser);
		}
	}
}
