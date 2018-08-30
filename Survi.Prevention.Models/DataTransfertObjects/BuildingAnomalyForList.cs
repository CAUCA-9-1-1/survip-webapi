using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class BuildingAnomalyForList : IDataTransferObjectWithId
    {
		public Guid Id { get; set; }
		public string Theme { get; set; }
		public string Notes { get; set; }
    }
}