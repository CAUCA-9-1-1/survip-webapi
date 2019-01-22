using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class FireSafetyDepartment : BaseLocalizableTransferObjectWithPicture
    {
        public string Language { get; set; }
        public string IdCounty { get; set; }
    }
}