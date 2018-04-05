using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survip.DataLayer.Mapping.Base;
using Survip.Models.SecurityManagement;

namespace Survip.DataLayer.Mapping
{
  public class AccessSecretKeyMapping : EntityMappingConfiguration<AccessSecretKey>
  {
    public override void Map(EntityTypeBuilder<AccessSecretKey> b)
    {
      b.ToTable("tbl_access_secretkey")
        .HasKey(m => m.Id);

      b.Property(m => m.Id).HasColumnName("id_access_secretkey").IsRequired();
      b.Property(m => m.ApplicationName).HasColumnName("application_name").HasMaxLength(50).IsRequired();
      b.Property(m => m.RandomKey).HasColumnName("randomkey").HasMaxLength(100).IsRequired();
      b.Property(m => m.SecretKey).HasColumnName("secretkey").HasMaxLength(100).IsRequired();
      b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
      b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
    }
  }
}
