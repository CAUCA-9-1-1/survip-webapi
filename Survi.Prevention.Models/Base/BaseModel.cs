using System;

namespace Survi.Prevention.Models.Base
{
	public abstract class BaseModel : IBaseModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public DateTime? LastModifiedOn {get; set;}
		public Guid? IdWebUserLastModifiedBy { get; set;}

        public void SetAsModified(Guid? currentUserId)
        {
            IdWebUserLastModifiedBy = currentUserId;
            LastModifiedOn = DateTime.Now;
        }
	}
}
