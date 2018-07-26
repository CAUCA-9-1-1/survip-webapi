using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingAnomalyPicture : BaseModel
	{
		public Guid IdPicture { get; set; }
		public Picture Picture { get; set; }
        public string SketchJson { get; set; }

		public Guid IdBuildingAnomaly { get; set; }
		public BuildingAnomaly Anomaly { get; set; }
	}
}