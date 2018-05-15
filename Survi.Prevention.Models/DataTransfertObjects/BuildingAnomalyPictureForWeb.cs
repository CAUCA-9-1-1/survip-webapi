using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingAnomalyPictureForWeb
	{
		public Guid Id { get; set; }
		public Guid IdBuildingAnomaly { get; set; }
		public Guid IdPicture { get; set; }
		public string PictureData { get; set; }
	}
}