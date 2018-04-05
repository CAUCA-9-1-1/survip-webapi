using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survip.DataLayer.Mapping.Base;
using Survip.Models.SecurityManagement;

namespace Survip.DataLayer.Mapping
{
  public class WebuserMapping : EntityMappingConfiguration<Webuser>
  {
    public override void Map(EntityTypeBuilder<Webuser> b)
    {
      b.ToTable("tbl_webuser")
        .HasKey(p => p.Id);

      b.Property(p => p.Id).HasColumnName("id_webuser").IsRequired();
      b.Property(p => p.Username).HasColumnName("username").HasMaxLength(100).IsRequired();
      b.Property(p => p.Password).HasColumnName("password").HasMaxLength(100).IsRequired();
      b.Property(p => p.IsActive).HasColumnName("is_active").IsRequired();
      b.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
    }
  }
}
