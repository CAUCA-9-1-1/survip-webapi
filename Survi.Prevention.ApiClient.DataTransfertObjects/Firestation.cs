using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class Firestation : BaseLocalizableTransferObject
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }

        public string IdBuilding { get; set; }
        public string IdFireSafetyDepartment { get; set; }
    }
}