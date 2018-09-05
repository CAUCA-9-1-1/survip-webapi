using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Survi.Prevention.ServiceLayer.Services
{
	public static class ObjectExtensions
	{
		public static List<(string name, object value)> GetPublicProperties(this object obj)
		{
			var properties = (
				from prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
				where prop.CanRead
				select (prop.Name, prop.GetValue(obj))
			).ToList();

			return properties;
		}
	}
}