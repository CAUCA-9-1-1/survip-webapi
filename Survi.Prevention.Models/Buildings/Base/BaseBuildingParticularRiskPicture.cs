using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public class BaseBuildingParticularRiskPicture : BaseModel
	{
		public Guid IdBuildingParticularRisk { get; set; }
		public Guid IdPicture { get; set; }

		public Picture Picture { get; set; }
	}
}