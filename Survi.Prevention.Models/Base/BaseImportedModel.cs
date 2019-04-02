using System;

namespace Survi.Prevention.Models.Base
{
    public abstract class BaseImportedModel : BaseModel, IBaseImportedModel
    {
		public string IdExtern { get; set;}
		public DateTime? ImportedOn { get; set;}
		public bool HasBeenModified { get; set;}

        public override void SetAsModified(Guid? currentUserId, bool isInImportationMode)
        {
            IdWebUserLastModifiedBy = currentUserId;
            if (!isInImportationMode)
                HasBeenModified = true;
        }
    }
}
