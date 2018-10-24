using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingAnomaly<TBuilding, TAnomalyPicture, TPicture> : BaseImportedModel
		where TBuilding : BaseBuilding
		where TPicture: BasePicture
		where TAnomalyPicture : BaseBuildingAnomalyPicture<TPicture>
	{
		public string Theme { get; set; }
		public string Notes { get; set; }

		public Guid IdBuilding { get; set; }

		public TBuilding Building { get; set; }
		public ICollection<TAnomalyPicture> Pictures { get; set; }
	}
}