
using System;

namespace Survi.Prevention.Models.Base
{
    public abstract class BaseImportedModel : BaseModel
    {
		public string IdExtern { get; set;}
		public DateTime? ImportedOn { get; set;}
		public bool HasBeenModified { get; set;}
    }
}
