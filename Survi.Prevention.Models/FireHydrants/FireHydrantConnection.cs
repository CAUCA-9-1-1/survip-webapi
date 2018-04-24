using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireHydrants
{
	public class FireHydrantConnection : BaseModel
	{
		public decimal Diameter { get; set; }

		public Guid IdFireHydrant { get; set; }
		public Guid IdUnitOfMeasureDiameter { get; set; }
		public Guid IdFireHydrantConnectionType { get; set; }

		public FireHydrant Hydrant { get; set; }
		public DiameterUnitOfMeasure DiameterUnitOfMeasure { get; set; }
		public FireHydrantConnectionType ConnectionType { get; set; }
	}
}
