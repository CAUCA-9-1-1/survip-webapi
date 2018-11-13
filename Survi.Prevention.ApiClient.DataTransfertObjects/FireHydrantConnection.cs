namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class FireHydrantConnection
    {
        public decimal Diameter { get; set; }

        public string IdFireHydrant { get; set; }
        public string IdUnitOfMeasureDiameter { get; set; }
        public string IdFireHydrantConnectionType { get; set; }
    }
}