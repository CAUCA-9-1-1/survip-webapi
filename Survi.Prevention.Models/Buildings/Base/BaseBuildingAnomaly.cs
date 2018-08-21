using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingAnomaly<TBuilding, TPicture> : BaseModel
		where TBuilding : BaseBuilding
		where TPicture: BaseBuildingAnomalyPicture
	{
		public string Theme { get; set; }
		public string Notes { get; set; }

		public Guid IdBuilding { get; set; }

		public TBuilding Building { get; set; }
		public ICollection<TPicture> Pictures { get; set; }
	}
}