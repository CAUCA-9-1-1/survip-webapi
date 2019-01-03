using System.Collections.Generic;

namespace Survi.Prevention.Models.Base
{
    public abstract class BaseLocalizableImportedModel<TLocalization> : BaseImportedModel
        where TLocalization: BaseLocalization
    {
        public List<TLocalization> Localizations { get; set; }
    }
}