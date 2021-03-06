﻿using System;
using NetTopologySuite.Geometries;

namespace Survi.Prevention.Models
{
    public class NetTopologySuitePointWrapper
    {
	    private readonly string point;

		public static implicit operator NetTopologySuitePointWrapper(string dbg)
		{
			if (dbg == null)
				return null;
			return new NetTopologySuitePointWrapper(dbg);
		}

		public static implicit operator String(NetTopologySuitePointWrapper wrapper)
		{
			return wrapper?.point;
		}

		public static implicit operator NetTopologySuitePointWrapper(Point point)
		{
			if (point == null)
				return null;
			return new NetTopologySuitePointWrapper(point.ToText());
		}

		public static implicit operator Point(NetTopologySuitePointWrapper wrapper)
		{
			try
			{
				if (string.IsNullOrEmpty(wrapper?.point))
					return null;

				var r = new NetTopologySuite.IO.WKTReader {DefaultSRID = 4326, HandleOrdinates = GeoAPI.Geometries.Ordinates.XY};
				var vr = r.Read(wrapper.point) as Point;
				return vr;
			}
			catch
			{
				return null;
			}
		}

		private NetTopologySuitePointWrapper(string dbg)
		{
			point = dbg;
		}		
	}
}
