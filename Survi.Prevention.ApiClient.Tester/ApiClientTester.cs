﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services;
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
                ApiBaseUrl = "https://survipreventiontest.cauca.ca/api",
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
                Localizations = new List<DataTransferObjects.Base.Localization>
                    {
                        new DataTransferObjects.Base.Localization {Name = "Phil country", LanguageCode = "en"},
                        new DataTransferObjects.Base.Localization {Name = "Pays de Phil", LanguageCode = "fr"}
                    }
            };
            return new List<Country> { countryToSend };
        }

        private async Task SendData()
        {
            var countryService = new CountryService(authConfig);
            var result = await countryService.SendAsync<ImportationResult>(GetCountries());
            if (result.Any(r => !r.IsValid))
            {
                MessageBox.Show(string.Join(",", result.SelectMany(m => m.Messages).ToArray()), "Échec du transfert",
                    MessageBoxButtons.OK);
            }
        }

        private async Task GetData()
        {
            var service = new InspectionBuildingService(authConfig);

            var result = await service.GetAsync(null);

            var contactService = new BuildingContactService(authConfig);
            var resultContact = await contactService.SetItemsAsTransfered(new List<string> { "309b5464-dd93-4268-8e64-8407ff794d08" });

            if (result.Count > 0)
                MessageBox.Show(string.Join(",", result.Select(m => m.Id)), "Récupération des données du transfert", MessageBoxButtons.OK);
            else
                MessageBox.Show("Aucune données à exporter", "Résultat du transfert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            await GetData();
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            var service = new BuildingContactService(authConfig);
            var result = await service.SetItemsAsTransfered(new List<string> { "309b5464-dd93-4268-8e64-8407ff794d08" });
            if (result)
                MessageBox.Show("Les données ont été mises à jour comme transférées vers le CAD.", "Résultat du transfert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Un problème est survenue lors de la mise à jour du statut de transfert.", "Résultat du transfert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void SetCorrepondenceIds()
        {
            var service = new BuildingContactService(authConfig);
            List<TransferIdCorrespondence> IdsList = new List<TransferIdCorrespondence>();
            IdsList.Add(new TransferIdCorrespondence {Id = "84d97d3d-02d2-c37b-51cf-c3834c747f37", IdExtern = "9132f7e3-c4a9-4f97-9749-939bb5d7d7b4" });
            var result = await service.SetTransferCorrespondenceIds(IdsList);
            if (result)
                MessageBox.Show("Les données ont été mises à jour comme transférées vers le CAD.", "Résultat du transfert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Un problème est survenue lors de la mise à jour du statut de transfert.", "Résultat du transfert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SetCorrepondenceIds();
        }
    }
}
