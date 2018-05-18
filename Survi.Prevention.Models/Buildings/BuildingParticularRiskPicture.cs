using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingParticularRiskPicture : BaseModel
	{
		public Guid IdBuildingParticularRisk { get; set; }
		public Guid IdPicture { get; set; }

		public BuildingParticularRisk Risk { get; set; }		
		public Picture Picture { get; set; }
	}
}