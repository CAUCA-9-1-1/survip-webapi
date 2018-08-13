using System;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Survi.Prevention.WebApi
{
	public class PointCoordinateJsonConverter : JsonConverter
	{
		public override bool CanRead => true;
		public override bool CanWrite => true;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var converted = (value as Point)?.ToText();
			JToken t = JToken.FromObject(converted);

			if (t.Type != JTokenType.Object)
			{
				t.WriteTo(writer);
			}
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var value = reader.Value as string;
			var r = new NetTopologySuite.IO.WKTReader {DefaultSRID = 4326, HandleOrdinates = GeoAPI.Geometries.Ordinates.XY};
			var vr = r.Read(value) as Point;
			return vr;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(NetTopologySuite.Geometries.Point);
		}		
	}
}