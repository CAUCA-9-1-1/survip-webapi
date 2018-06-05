using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Survi.Prevention.Models.DataTransfertObjects;
using System.Linq.Dynamic.Core;

namespace Survi.Prevention.ServiceLayer.Services
{
	public static class QueryHelper
	{
		public static IQueryable<InspectionForDashboard> PageByOptions(this IQueryable<InspectionForDashboard> query, Dictionary<string, object> options)
		{
			if (options.ContainsKey("skip"))
			{
				var skip = Convert.ToInt32(options["skip"]);
				var take = Convert.ToInt32(options["take"]);
				query = query
					.Skip(skip)
					.Take(take);
			}
			return query;
		}

		public static IQueryable<InspectionForDashboard> SortByOptions(this IQueryable<InspectionForDashboard> query, Dictionary<string, object> options)
		{
			if (options.ContainsKey("sortOptions") && options["sortOptions"] != null)
			{
				var sortOptions = JObject.Parse(JArray.FromObject(options["sortOptions"])[0].ToString());
				var columnName = (string)sortOptions.SelectToken("selector");
				var descending = (bool)sortOptions.SelectToken("desc");

				if (descending)
					columnName += " DESC";
				query = query.OrderBy(columnName);
			}
			return query;
		}


		public static IQueryable<InspectionForDashboard> FilterByOptions(this IQueryable<InspectionForDashboard> query, Dictionary<string, object> options)
		{
			if (options.ContainsKey("filterOptions") && options["filterOptions"] != null)
			{
				var filterTree = JArray.FromObject(options["filterOptions"]);
				return ReadExpression(query, filterTree);
			}
			return query;
		}

		public static IQueryable<InspectionForDashboard> ReadExpression(IQueryable<InspectionForDashboard> source, JArray array)
		{
			if (array[0].Type == JTokenType.String)
				return FilterQuery(source,
					array[0].ToString(),
					array[1].ToString(),
					array[2].ToString());

			for (int i = 0; i < array.Count; i++)
			{
				if (array[i].ToString().Equals("and"))
					continue;
				source = ReadExpression(source, (JArray)array[i]);
			}
			return source;
		}

		public static IQueryable<InspectionForDashboard> FilterQuery(IQueryable<InspectionForDashboard> source, string columnName, string clause, string value)
		{
			switch (clause)
			{
				case "=":
					value = System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$") ? value : string.Format("\"{0}\"", value);
					source = source.Where(String.Format("{0} == {1}", columnName, value));
					break;
				case "contains":
					source = source.Where(columnName + ".Contains(@0)", value);
					break;
				case "<>":
					source = source.Where(string.Format("!{0}.StartsWith(\"{1}\")", columnName, value));
					break;
			}
			return source;
		}	
	}
}