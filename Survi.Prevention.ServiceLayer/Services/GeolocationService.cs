using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class GeolocationService : BaseService
	{
		public GeolocationService(IManagementContext context) : base(context)
		{
		}

		public async Task<JObject> SearchWithICherche(string type, string search, int limit = 10)
        {
	        /* Available type
	         * Split with a comma to receive more
	         * 
	         * adresse,route,municipalite,mrc,region_administrative,ancienne_municipalite
	         */

	        var url = "https://geoegl.msp.gouv.qc.ca/icherche/geocode?type=" + type + "&q=" + search + "&limit=" + limit + "&geometries=geom";
			var client = new HttpClient();
	        var response = await client.GetAsync(url);

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}