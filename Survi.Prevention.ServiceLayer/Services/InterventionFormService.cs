using System;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InterventionFormService : BaseService
	{
		public InterventionFormService(ManagementContext context) : base(context)
		{
		}

		public InterventionDetailForWeb GetFormForWeb(Guid id, string languageCode)
		{
			var query =
				from form in Context.InterventionForms
				where form.IsActive && form.Id == id
				from formBuilding in form.Buildings
				where formBuilding.IsActive && formBuilding.IsParent
				let building = formBuilding.Building
				let lane = building.Lane
				from loc in building.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				from laneLoc in lane.Localizations
				where laneLoc.IsActive && laneLoc.LanguageCode == languageCode
				select new 
				{
					form.Id,
					form.CreatedOn,
					form.IsActive,
					form.IdLaneTransversal,
					form.IdPictureSitePlan,
					PlanName = form.Name,
					PlanNumber = form.Number,
					MainBuildingName = loc.Name,
					MainBuildingIdLane = building.IdLane,
					MainBuildingIdRiskLevel = building.IdRiskLevel,
					MainBuildingIdUtilisationCode = building.IdUtilisationCode,
					building.Matricule,
					lane.IdCity,
					OtherInformation = formBuilding.AdditionalInformation,
					lane.LaneGenericCode.AddWhiteSpaceAfter,
					GenericDescription = lane.LaneGenericCode.Description,
					PublicDescription = lane.PublicCode.Description,
					LaneName = laneLoc.Name,
					building.CivicNumber,
					building.CivicLetter
				};

			var result = query.SingleOrDefault();
			if (result == null)
				return null;

			return new InterventionDetailForWeb
			{
				Id = result.Id,
				CreatedOn = result.CreatedOn,
				IsActive = result.IsActive,
				IdLaneTransversal = result.IdLaneTransversal,
				IdPictureSitePlan = result.IdPictureSitePlan,
				PlanName = result.PlanName,
				PlanNumber = result.PlanNumber,
				IdCity = result.IdCity,
				MainBuildingAddress = new AddressGenerator()
					.GenerateAddress(result.CivicNumber, result.CivicLetter, result.LaneName, result.GenericDescription, result.PublicDescription, result.AddWhiteSpaceAfter),
				MainBuildingIdLane = result.MainBuildingIdLane,
				MainBuildingName = result.MainBuildingName,
				MainBuildingIdRiskLevel = result.MainBuildingIdRiskLevel,
				MainBuildingIdUtilisationCode = result.MainBuildingIdUtilisationCode,
				MainBuildingMatricule = result.Matricule,
				OtherInformation = result.OtherInformation
			};
		}

		// todo: try to get these two functions to be more generic so there can be only one.
		public bool TryToChangeIntersection(Guid id, Guid? idLaneTransversal)
		{
			var form = Context.Find<InterventionForm>(id);
			if (form != null)
			{
				form.IdLaneTransversal = idLaneTransversal;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public bool TryToChangeIdPicture(Guid id, Guid? idPicture)
		{
			var form = Context.Find<InterventionForm>(id);
			if (form != null)
			{
				form.IdPictureSitePlan = idPicture;
				Context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}