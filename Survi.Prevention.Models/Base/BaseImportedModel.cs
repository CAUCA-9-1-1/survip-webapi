
using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.Base
{
    public abstract class BaseImportedModel : BaseModel
    {
		public string IdExtern { get; set;}
		public DateTime? ImportedOn { get; set;}
		public bool HasBeenModified { get; set;}
    }

    public abstract class BaseLocalizableImportedModel<TLocalization> : BaseImportedModel
        where TLocalization: BaseLocalization
    {
        public List<TLocalization> Localizations { get; set; }
    }
}
