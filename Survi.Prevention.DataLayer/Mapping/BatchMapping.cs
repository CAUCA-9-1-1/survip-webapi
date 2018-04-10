using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BatchMapping : EntityMappingConfiguration<Batch>
	{
		public override void Map(EntityTypeBuilder<Batch> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Description).HasMaxLength(50).IsRequired();
			b.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.IdWebuserCreatedBy);
			b.HasMany(m => m.Users).WithOne(m => m.Batch).HasForeignKey(m => m.IdBatch);
			b.HasMany(m => m.Inspections).WithOne(m => m.Batch).HasForeignKey(m => m.IdBatch);
		}
	}
}