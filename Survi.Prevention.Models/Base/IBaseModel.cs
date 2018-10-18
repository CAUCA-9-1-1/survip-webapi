using System;

namespace Survi.Prevention.Models.Base
{
	public interface IBaseModel
	{
		DateTime CreatedOn { get; set; }
		Guid Id { get; set; }
		bool IsActive { get; set; }
	}
}