using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InterventionFormFireHydrantForList
	{
		public Guid Id { get; set; }
		public Guid IdInterventionForm { get; set; }
		public string Number { get; set; }
		public string Address { get; set; }
	}
}