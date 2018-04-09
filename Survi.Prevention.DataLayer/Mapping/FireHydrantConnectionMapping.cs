using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionMapping : EntityMappingConfiguration<FireHydrantConnection>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnection> b)
		{
			b.ToTable("tbl_fire_hydrant_connection").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_fire_hydrant_connection");
			b.Property(m => m.IdFireHydrant).HasColumnName("id_fire_hydrant").IsRequired();
			b.Property(m => m.IdUnitOfMeasureDiameter).HasColumnName("id_unit_of_measure_diameter").IsRequired();
			b.Property(m => m.IdFireHydrantConnectionType).HasColumnName("id_fire_hydrant_connection_type").IsRequired();
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
			b.Property(m => m.Diameter).HasColumnName("diameter").IsRequired();

			b.HasOne(m => m.DiameterUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureDiameter);
			b.HasOne(m => m.ConnectionType).WithMany().HasForeignKey(m => m.IdFireHydrantConnectionType);
		}
	}
}