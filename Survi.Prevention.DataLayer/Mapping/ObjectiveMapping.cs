using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;
using System.Linq;

namespace Survi.Prevention.DataLayer.Mapping
{
    public class ObjectiveMapping : EntityMappingConfiguration<Objectives>
    {
        public override void Map(EntityTypeBuilder<Objectives> b)
        {
            b.HasKey(m => m.Id);
            b.HasOne(m => m.FireSafetyDepartment).WithMany().HasForeignKey(m => m.IdFireSafetyDepartment);
            b.Property(m => m.Year).IsRequired();
            b.Property(m => m.Objective).IsRequired();
            b.Property(m => m.IsHighRisk).IsRequired();
        }
    }
}

