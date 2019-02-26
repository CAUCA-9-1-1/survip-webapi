using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
	public class City: BaseLocalizableTransferObject
    {
        public string Code { get; set; }
        public string Code3Letters { get; set; }
        public string EmailAddress { get; set; } = "";

        public string IdCityType { get; set; }
        public string IdCounty { get; set; }
		public int UtilizationCodeYear { get; set; }
    }
}