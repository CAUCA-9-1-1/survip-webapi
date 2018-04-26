using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingCourseForWeb
	{
		public Guid Id { get; set; }
		public Guid IdInspectionBuilding { get; set; }
		public Guid IdFirestation { get; set; }
	}
}