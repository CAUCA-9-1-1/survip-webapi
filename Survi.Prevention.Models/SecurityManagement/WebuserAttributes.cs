using System;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class WebuserAttributes
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string AttributeName { get; set; }
		public string AttributeValue { get; set; }

		public Guid IdWebuser { get; set; }
		public Webuser User { get; set; }
	}
}
