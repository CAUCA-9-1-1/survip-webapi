using Microsoft.AspNet.OData.Builder;

namespace Survi.Prevention.WebApi
{
    public static class ODataExtensions
    {
		public static StructuralTypeConfiguration<T> AllowAllQueryType<T>(this EntitySetConfiguration<T> entity) where T : class
		{
			return entity.EntityType.Filter()
				.Count()
				.Expand()
				.OrderBy()
				.Page()
				.Select();
		}
    }
}
