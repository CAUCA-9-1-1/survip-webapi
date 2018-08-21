using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
    public abstract class BaseBuildingParticularRisk<TBuilding, TPicture> : BaseModel
	    where TBuilding : BaseBuilding
	    where TPicture : BaseBuildingParticularRiskPicture
	{
		public Guid IdBuilding { get; set; }
	    public bool IsWeakened { get; set; }
		public bool HasOpening { get; set; }
	    public string Comments { get; set; } = "";
		public string Wall { get; set; }
		public string Sector { get; set; }
	    public string Dimension { get; set; } = "";

		public TBuilding Building { get; set; }
		public ICollection<TPicture> Pictures { get; set; }
    }
}
