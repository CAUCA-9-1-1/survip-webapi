using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NetTopologySuite.Geometries;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.FireHydrants
{
	public enum FireHydrantLocationType
	{
        NotSpecified,
        Address,
        LaneAndTransversal,
        Text
    }

	public enum FireHydrantAddressLocationType
	{
		NextTo,
		AtTheAddress,
		BackWard,
		AtEnd,
		AtCorner,
		Above,
		Under,
		InFront,
		Near,
		VisibleFrom
	}

	public enum OperatorType
	{
		Equal,
		Greater,
		GreaterOrEqual,
		Less,
		LessOrEqual
	}

	public class FireHydrant : BaseImportedModel
	{
		private NetTopologySuitePointWrapper wrapper;
		
		public FireHydrantLocationType LocationType { get; set; }
		
		[JsonIgnore]
		public Point PointCoordinates { get => wrapper; set => wrapper = value; }
		public string Coordinates { get => wrapper; set => wrapper = value; }

		public decimal Altitude { get; set; }
		public string Number { get; set; }
		public Decimal? RateFrom { get; set; }
		public Decimal? RateTo { get; set; }

		public Decimal? PressureFrom { get; set; }
		public Decimal? PressureTo { get; set; }
		public string Color { get; set; }
		public string Comments { get; set; }
		public string PhysicalPosition { get; set; }
		public string CivicNumber { get; set; }
		public FireHydrantAddressLocationType AddressLocationType { get; set; }

	    public OperatorType RateOperatorType { get; set; } = OperatorType.Equal;
	    public OperatorType PressureOperatorType { get; set; } = OperatorType.Equal;

        public Guid IdCity { get; set; }
		public Guid? IdLane { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid IdFireHydrantType { get; set; }
		public Guid? IdUnitOfMeasureRate { get; set; }
		public Guid? IdUnitOfMeasurePressure { get; set; }

		public City City { get; set; }
		public Lane Lane { get; set; }
		public Lane LaneTransversal { get; set; }
		public FireHydrantType HydrantType { get; set; }		
		public UnitOfMeasure RateUnitOfMeasure { get; set; }
		public UnitOfMeasure PressureUnitOfMeasure { get; set; }		

		public ICollection<FireHydrantConnection> Connections { get; set; }
	}
}
