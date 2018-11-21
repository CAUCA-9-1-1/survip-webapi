using System;

namespace Survi.Prevention.Models.Base
{
    public class BaseLocalization : BaseModel
    {
		public string LanguageCode { get; set; }
		public Guid IdParent { get; set; }

        public string Name { get; set; }
    }
}