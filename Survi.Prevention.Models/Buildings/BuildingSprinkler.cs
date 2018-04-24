using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingSprinkler : BaseModel
	{
		public string Floor { get; set; }
		public string Wall { get; set; }
		public string Sector { get; set; }
		public string PipeLocation { get; set; }
		public string CollectorLocation { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdSprinklerType { get; set; }

		public Building Building { get; set; }
		public SprinklerType SprinklerType { get; set; }
	}
}