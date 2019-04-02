using System;

namespace Survi.Prevention.Models.Base
{
    public interface IBaseImportedModel : IBaseModel
    {
        string IdExtern { get; set; }
        DateTime? ImportedOn { get; set; }
        bool HasBeenModified { get; set; }
    }
}