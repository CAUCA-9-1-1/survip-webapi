using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingFireHydrant : BaseModel
	{
		public DateTime? DeletedOn { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdFireHydrant { get; set; }

		public Building Building { get; set; }
		public FireHydrant Hydrant { get; set; }
	}
}
