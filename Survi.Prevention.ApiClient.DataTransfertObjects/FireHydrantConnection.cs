using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class FireHydrantConnection : BaseTransferObject
    {
        public decimal Diameter { get; set; }

        //public string IdFireHydrant { get; set; }
        public string IdUnitOfMeasureDiameter { get; set; }
        public string IdFireHydrantConnectionType { get; set; }
    }
}