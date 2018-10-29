using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionPictureForWeb
	{
		public Guid Id { get; set; }
		public Guid IdParent { get; set; }
		public Guid? IdPicture { get; set; }
		public string DataUri { get; set; }
        public string SketchJson { get; set; }
    }
}