using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingSprinkler : IBaseModel
	{
		string CollectorLocation { get; set; }
		string Floor { get; set; }
		Guid IdBuilding { get; set; }
		Guid IdSprinklerType { get; set; }
		string PipeLocation { get; set; }
		string Sector { get; set; }
		SprinklerType SprinklerType { get; set; }
		string Wall { get; set; }
	}
}