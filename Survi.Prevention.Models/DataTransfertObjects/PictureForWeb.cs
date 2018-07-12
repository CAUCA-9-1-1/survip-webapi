using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class PictureForWeb
    {
		public Guid? Id { get; set; }
        public string Picture { get; set; }
        public string DataUri { get; set; }
        public string SketchJson { get; set; }
    }
}
