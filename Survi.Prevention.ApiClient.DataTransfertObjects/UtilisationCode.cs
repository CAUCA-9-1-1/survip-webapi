using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
	public class UtilisationCode : BaseLocalizableTransferObject
    {
        public string Cubf { get; set; }
        public string Scian { get; set; }
	    public int Year { get; set; }
	}
}