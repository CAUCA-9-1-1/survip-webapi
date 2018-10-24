using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingFireHydrant : BaseImportedModel, IBaseBuildingFireHydrant
	{
		public DateTime? DeletedOn { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdFireHydrant { get; set; }

		public FireHydrant Hydrant { get; set; }
	}
}