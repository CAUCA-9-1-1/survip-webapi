using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingChildPictureForWeb
	{
		public Guid Id { get; set; }
		public Guid IdParent { get; set; }
		public Guid IdPicture { get; set; }
		public string PictureData { get; set; }
        public string SketchJson { get; set; }
    }
}