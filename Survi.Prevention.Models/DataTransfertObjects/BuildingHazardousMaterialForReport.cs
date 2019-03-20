using System;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class BuildingHazardousMaterialForReport
    {
        public Guid Id { get; set; }
        public string MaterialNumber { get; set; }
        public string MaterialName { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Container { get; set; }
        public string CapacityContainer { get; set; }
        public string Place { get; set; }
        public string Wall { get; set; }
        public string Floor { get; set; }
        public string GasInlet { get; set; }
        public string SecurityPerimeter { get; set; }
        public string OtherInformation { get; set; }
        public string SupplyLine { get; set; }
        public StorageTankType TankType { get; set; }
    }
}