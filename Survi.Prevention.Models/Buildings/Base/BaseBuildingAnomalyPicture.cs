using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public class BaseBuildingAnomalyPicture<T> : BaseModel
		where T: BasePicture
	{
		public Guid? IdPicture { get; set; }
		public Guid IdBuildingAnomaly { get; set; }

		public T Picture { get; set; }
	}
}