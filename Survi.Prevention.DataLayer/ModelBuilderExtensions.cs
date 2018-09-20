using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Survi.Prevention.DataLayer
{
    public static class ModelBuilderExtensions
    {
		public static void UseAutoSnakeCaseMapping(this ModelBuilder builder)
		{
			foreach (var entity in builder.Model.GetEntityTypes())
			{
				entity.Relational().TableName = entity.DisplayName().ToSnakeCase();

				foreach (var property in entity.GetProperties())
					property.Relational().ColumnName = property.Name.ToSnakeCase();

				foreach (var key in entity.GetKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var key in entity.GetForeignKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var index in entity.GetIndexes())
					index.Relational().Name = index.Relational().Name.ToSnakeCase();
			}
		}

	    public static PropertyBuilder<decimal?> HasPrecision(this PropertyBuilder<decimal?> builder, int precision, int scale)
	    {
		    return builder.HasColumnType($"decimal({precision},{scale})");
	    }

	    public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> builder, int precision, int scale)
	    {
		    return builder.HasColumnType($"decimal({precision},{scale})");
	    }
    }
}
