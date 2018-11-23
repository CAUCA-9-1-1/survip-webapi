using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingHazardousMaterial: BaseTransferObject
    {
        public int Quantity { get; set; }
        public string Container { get; set; }
        public decimal CapacityContainer { get; set; }
        public string Place { get; set; }
        public string Wall { get; set; }
        public string Sector { get; set; }
        public string Floor { get; set; }
        public string GasInlet { get; set; }
        public string SecurityPerimeter { get; set; }
        public string OtherInformation { get; set; }
        public StorageTankType TankType { get; set; }
        public string SupplyLine { get; set; }

        public string IdBuilding { get; set; }
        public string IdHazardousMaterial { get; set; }
        public string IdUnitOfMeasure { get; set; }
    }
}