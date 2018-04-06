using System;

namespace Survi.Prevention.Models
{
	public abstract class LanguageContent
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string LanguageCode { get; set; }
		public string Description { get; set; }
	}
}
