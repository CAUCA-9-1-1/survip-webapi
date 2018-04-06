using System;
using NpgsqlTypes;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.FireHydrants
{
	public enum FireHydrantLocationType
	{
		None,
		LaneAndIntersection,
		Coordinates,
		Text
	}

	public class FireHydrant : BaseModel
	{
		public FireHydrantLocationType LocationType { get; set; }
		public PostgisGeometry Coordinates { get; set; }
		public decimal Altitude { get; set; }
		public string Number { get; set; }
		public string RateFrom { get; set; }
		public string RateTo { get; set; }
		public string PressureFrom { get; set; }
		public string PressureTo { get; set; }
		public string Color { get; set; }
		public string Comments { get; set; }
		public string PhysicalPosition { get; set; }

		public Guid? IdLane { get; set; }
		public Guid? IdIntersection { get; set; }
		public Guid IdFireHydrantType { get; set; }
		public Guid IdOperatorTypeRate { get; set; }
		public Guid IdUnitOfMeasureRate { get; set; }
		public Guid IdOperatorTypePressure { get; set; }
		public Guid IdUnitOfMeasurePressure { get; set; }

		public Lane Lane { get; set; }
		public Lane Intersection { get; set; }
		public FireHydrantType HydrantType { get; set; }
		public OperatorType RateOperatorType { get; set; }
		public OperatorType PressureOperatorType { get; set; }
		public UnitOfMeasure RateUnitOfMeasure { get; set; }
		public UnitOfMeasure PressureUnitOfMeasure { get; set; }		
	}
}
