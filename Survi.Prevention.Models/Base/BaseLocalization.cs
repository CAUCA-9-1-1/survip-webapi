using System;

namespace Survi.Prevention.Models.Base
{
    public class BaseLocalization<T> : BaseModel
		where T: class
    {
		public string LanguageCode { get; set; }
		public T Parent { get; set; }
		public Guid IdParent { get; set; }
    }
}
