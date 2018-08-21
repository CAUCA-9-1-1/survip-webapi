using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public class BaseBuildingAnomalyPicture : BaseModel
	{
		public Guid IdPicture { get; set; }
		public Picture Picture { get; set; }

		public Guid IdBuildingAnomaly { get; set; }
	}
}