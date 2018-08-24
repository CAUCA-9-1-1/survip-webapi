using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingFireHydrant : IBaseModel
	{
		DateTime? DeletedOn { get; set; }
		FireHydrant Hydrant { get; set; }
		Guid IdBuilding { get; set; }
		Guid IdFireHydrant { get; set; }
	}
}