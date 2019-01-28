using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class EntityPictures
    {
        public Guid Id { get; set; }
        public List<InspectionPictureForWeb> Pictures { get; set; }
    }

	public class InspectionPictureForWeb
	{
		public Guid Id { get; set; }
		public Guid IdParent { get; set; }
		public Guid? IdPicture { get; set; }
		public string DataUri { get; set; }
        public string SketchJson { get; set; }
    }
}