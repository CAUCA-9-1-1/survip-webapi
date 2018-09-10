using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Survi.Prevention.Models.Base
{
	public abstract class BaseModel : IBaseModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
	}
}
