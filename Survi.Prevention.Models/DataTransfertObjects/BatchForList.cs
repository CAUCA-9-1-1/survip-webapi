using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BatchForList
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public IEnumerable<InspectionForList> Inspections { get; set; }
	}
}