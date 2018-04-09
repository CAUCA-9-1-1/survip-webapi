using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
  public class AccessSecretKeyMapping : EntityMappingConfiguration<AccessSecretKey>
  {
    public override void Map(EntityTypeBuilder<AccessSecretKey> b)
    {
      b.HasKey(m => m.Id);
      b.Property(m => m.ApplicationName).HasMaxLength(50).IsRequired();
      b.Property(m => m.RandomKey).HasMaxLength(100).IsRequired();
      b.Property(m => m.SecretKey).HasMaxLength(100).IsRequired();
      b.Property(m => m.CreatedOn).IsRequired();
      b.Property(m => m.IsActive).IsRequired();
    }
  }
}
