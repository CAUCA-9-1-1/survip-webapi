using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingSprinkler : BaseModel
	{
		public string SprinklerFloor { get; set; }
		public string SprinklerWall { get; set; }
		public string SprinklerSector { get; set; }
		public string PipeLocation { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdSprinklerType { get; set; }

		public Building Building { get; set; }
		public SprinklerType SprinklerType { get; set; }
	}
}