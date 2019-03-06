using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using BuildingPersonRequiringAssistance = Survi.Prevention.Models.Buildings.BuildingPersonRequiringAssistance;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingPersonRequiringAssistanceService : BaseCrudServiceWithImportation<BuildingPersonRequiringAssistance, ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance>
	{
		public BuildingPersonRequiringAssistanceService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance, BuildingPersonRequiringAssistance> converter) 
			: base(context, converter)
		{
		}

		public override BuildingPersonRequiringAssistance Get(Guid id)
		{
			var entity = Context.BuildingPersonsRequiringAssistances.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public List<BuildingPersonRequiringAssistance> GetBuildingPnapsList(Guid idBuilding)
		{
            var result = Context.BuildingPersonsRequiringAssistances
                .Where(p => p.IdBuilding == idBuilding)
                .ToList();

			return result;
		}

		public List<PersonRequiringAssistanceForReport> GetPersonsForReport(Guid idBuilding, string languageCode)
		{
			var query =
				from person in Context.BuildingPersonsRequiringAssistances.AsNoTracking()
				where person.IsActive && person.IdBuilding == idBuilding
				from localization in person.PersonType.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				select new PersonRequiringAssistanceForReport
				{
					DayResidentCount = person.DayResidentCount,
					ContactName = person.ContactName,
					ContactPhoneNumber = person.ContactPhoneNumber,
					DayIsApproximate = person.DayIsApproximate,
					Description = person.Description,
					EveningIsApproximate = person.EveningIsApproximate,
					EveningResidentCount = person.EveningResidentCount,
					NightIsApproximate = person.NightIsApproximate,
					NightResidentCount = person.NightResidentCount,
					Local = person.Local,
					PersonName = person.PersonName,
					TypeName = localization.Name
				};

			return query.ToList();
		}

        public object SetEntityAsTransferedToCad(List<string> ids)
        {
            try
            {
                Context.IsInImportationMode = true;
                var buildingPnaps = Context.BuildingPersonsRequiringAssistances.Where(b => ids.Contains(b.Id.ToString())).ToList();

                buildingPnaps.ForEach(b =>
                {
                    b.HasBeenModified = false;
                });
                Context.SaveChanges();
                Context.IsInImportationMode = false;
                return true;
            }
            catch (Exception)
            {
                Context.IsInImportationMode = false;
                return false;
            }
        }

        public List<ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance> Export(List<string> idBuildings)
        {
            var query = from buildingPnap in Context.BuildingPersonsRequiringAssistances.AsNoTracking()
                    .IgnoreQueryFilters()
                        where buildingPnap.HasBeenModified &&
                              idBuildings.Contains(buildingPnap.IdBuilding.ToString())
                select new ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance
                {
                    Id = buildingPnap.IdExtern ?? buildingPnap.Id.ToString(),
                    IdBuilding = buildingPnap.Building.IdExtern,
                    ContactName = buildingPnap.ContactName,
                    ContactPhoneNumber = buildingPnap.ContactPhoneNumber,
                    DayIsApproximate = buildingPnap.DayIsApproximate,
                    DayResidentCount = buildingPnap.DayResidentCount,
                    Description = buildingPnap.Description,
                    EveningIsApproximate = buildingPnap.EveningIsApproximate,
                    EveningResidentCount = buildingPnap.EveningResidentCount,
                    Floor = buildingPnap.Floor,
                    IdPersonRequiringAssistanceType = buildingPnap.PersonType.IdExtern,
                    Local = buildingPnap.Local,
                    NightIsApproximate = buildingPnap.NightIsApproximate,
                    NightResidentCount = buildingPnap.NightResidentCount,
                    PersonName = buildingPnap.PersonName,
                    IsActive = buildingPnap.IsActive,
                    LastEditedOn = buildingPnap.LastModifiedOn
                };
            return query.ToList();
        }

        public bool UpdateExternalIds(List<TransferIdCorrespondence> correspondenceIds)
        {
            try
            {
                List<string> ids = correspondenceIds.Select(ci => ci.Id).ToList();
                var query = from buildingPnap in Context.BuildingPersonsRequiringAssistances.AsNoTracking().IgnoreQueryFilters()
                    where ids.Contains(buildingPnap.Id.ToString()) && buildingPnap.IdExtern == ""
                    select new BuildingPersonRequiringAssistance();

                query.ToList().ForEach(bc =>
                {
                    bc.IdExtern = correspondenceIds.SingleOrDefault(ci => ci.Id == bc.Id.ToString())?.IdExtern;
                });
                Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}