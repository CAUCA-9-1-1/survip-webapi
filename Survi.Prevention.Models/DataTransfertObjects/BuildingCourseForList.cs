using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingCourseForList : IDataTransferObjectWithId
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
	}
}