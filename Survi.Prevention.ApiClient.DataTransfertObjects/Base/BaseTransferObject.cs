using System;

namespace Survi.Prevention.ApiClient.DataTransferObjects.Base
{
    public abstract class BaseTransferObject
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastEditedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
