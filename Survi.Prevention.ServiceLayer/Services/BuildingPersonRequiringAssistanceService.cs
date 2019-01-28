using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

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
			var entity = Context.BuildingPersonsRequiringAssistance.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public List<BuildingPersonRequiringAssistance> GetBuildingPnapsList(Guid idBuilding)
		{
            var result = Context.BuildingPersonsRequiringAssistance
                .Where(p => p.IdBuilding == idBuilding)
                .ToList();

			return result;
		}

		public List<PersonRequiringAssistanceForReport> GetPersonsForReport(Guid idBuilding, string languageCode)
		{
			var query =
				from person in Context.BuildingPersonsRequiringAssistance.AsNoTracking()
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

        public List<ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance> Export(List<string> idBuildings)
        {
            var query = from buildingPnap in Context.BuildingPersonsRequiringAssistance.AsNoTracking()
                    .IgnoreQueryFilters()
                        where buildingPnap.HasBeenModified &&
                      idBuildings.Contains(buildingPnap.IdBuilding.ToString())
                select new ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance
                {
                    Id = buildingPnap.IdExtern,
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
    }
}