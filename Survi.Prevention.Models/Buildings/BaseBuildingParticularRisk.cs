using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
    public abstract class BuildingParticularRisk : BaseModel
    {
		public Guid IdBuilding { get; set; }
	    public bool IsWeakened { get; set; }
		public bool HasOpening { get; set; }
	    public string Comments { get; set; } = "";
		public string Wall { get; set; }
		public string Sector { get; set; }
	    public string Dimension { get; set; } = "";

		public Building Building { get; set; }
		public ICollection<BuildingParticularRiskPicture> Pictures { get; set; }
    }

	public class FoundationParticularRisk : BuildingParticularRisk
	{		
	}

	public class FloorParticularRisk : BuildingParticularRisk
	{
	}

	public class WallParticularRisk : BuildingParticularRisk
	{
	}

	public class RoofParticularRisk : BuildingParticularRisk
	{
	}
}
