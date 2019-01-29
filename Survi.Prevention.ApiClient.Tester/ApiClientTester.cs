using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ApiClient.Services.Building;
using Survi.Prevention.ApiClient.Services.Places;

namespace Survi.Prevention.ApiClient.Tester
{
	public partial class ApiClientTester : Form
	{
		private AuthentificationConfiguration authConfig;
		public ApiClientTester()
		{
			InitializeComponent();
			InitAuthentification();
		}

		private void InitAuthentification()
		{
			authConfig = new AuthentificationConfiguration
			{
				ApiBaseUrl = "http://localhost:5555/api",
				UserName = "admin",
				Password = "admincauca"
			};
		}
		private async void TransferPreventionButton_Click(object sender, EventArgs e)
		{
            await SendData();
        }

		private List<Country> GetCountries()
		{
			var countryToSend = new Country
			{
				CodeAlpha2 = "T1",
				CodeAlpha3 = "Tes",
				Id = "PhilCountry1",
				IsActive = true,
				Localizations = new List<Localization>
					{
						new Localization {Name = "Phil country", LanguageCode = "en"},
						new Localization {Name = "Pays de Phil", LanguageCode = "fr"}
					}
			};
			return new List<Country> { countryToSend };
		}

		private async Task SendData()
		{
			var countryService = new CountryService(authConfig);
			var result = await countryService.SendAsync<ImportationResult>(GetCountries());
			if (result.Any(r=> !r.IsValid))
			{
				MessageBox.Show(string.Join(",", result.SelectMany(m=>m.Messages).ToArray()), "Échec du transfert",
					MessageBoxButtons.OK);
			}
		}

        private async Task GetData()
        {
            var service = new BuildingContactService(authConfig);

            var result = await service.GetAsync(new List<string> { "000f577d-b957-4b11-975d-bc08c50f69b2", "0025aaf9-7e23-46e2-b359-80c4bc041a46" });
            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(",", result.Select(m=>m.Id)), "Récupération des données du transfert",
                    MessageBoxButtons.OK);
            }
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            await GetData();
        }
    }
}
