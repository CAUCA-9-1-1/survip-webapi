using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public class BaseBuildingParticularRiskPicture<T> : BaseImportedModel
		where T : BasePicture
	{
		public Guid IdBuildingParticularRisk { get; set; }
		public Guid? IdPicture { get; set; }

		public T Picture { get; set; }
	}
}