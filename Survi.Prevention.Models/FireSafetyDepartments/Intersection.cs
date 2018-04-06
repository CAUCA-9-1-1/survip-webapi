using System;
using NpgsqlTypes;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Intersection : BaseModel
	{
		public PostgisGeometry Coordinates { get; set; }

		public Guid IdLane { get; set; }
		public Guid IdLaneTransversal { get; set; }

		public Lane Lane { get; set; }
		public Lane Transversal { get; set; }
	}
}
