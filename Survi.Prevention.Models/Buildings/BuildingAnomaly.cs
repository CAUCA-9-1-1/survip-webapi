using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingAnomaly : BaseModel
	{
		public string Theme { get; set; }
		public string Notes { get; set; }	
		
		public ICollection<BuildingAnomalyPicture> Pictures { get; set; }
	}
}