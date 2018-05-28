using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionDetailService : BaseService
	{
		public InspectionDetailService(ManagementContext context) : base(context)
		{
		}

		public InspectionBuildingDetailForWeb GetDetailForWeb(Guid inspectionId, string languageCode)
		{
			CreateDetailForMainBuildingWhenMissing(inspectionId);

			var query =
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId
				let building = inspection.MainBuilding
				let lane = building.Lane
				from loc in building.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				from laneLoc in lane.Localizations
				where laneLoc.IsActive && laneLoc.LanguageCode == languageCode
				let detail = building.Detail
				select new
				{
					building.Id,
					IdDetail = detail != null ? (Guid?)building.Detail.Id : null,
					building.IdLaneTransversal,
					building.Detail.IdPicturePlan,
					MainBuildingName = loc.Name,
					MainBuildingIdLane = building.IdLane,
					MainBuildingIdRiskLevel = building.IdRiskLevel,
					MainBuildingIdUtilisationCode = building.IdUtilisationCode,
					building.Matricule,
					lane.IdCity,
					OtherInformation = detail != null ? detail.AdditionalInformation : "",
					lane.LaneGenericCode.AddWhiteSpaceAfter,
					GenericDescription = lane.LaneGenericCode.Description,
					PublicDescription = lane.PublicCode.Description,
					LaneName = laneLoc.Name,
					building.CivicNumber,
					building.CivicLetter,
					IdBuilding = building.Id,
					inspection.IdSurvey,
					inspection.IsSurveyCompleted,
					inspection.Status,
					ApprobationRefusal = getApprobationRefusalReason(inspection)
				};

			var result = query.SingleOrDefault();
			if (result == null)
				return null;

			return new InspectionBuildingDetailForWeb
			{
				Id = result.Id,
				IdInspection = inspectionId,
				IdDetail = result.IdDetail,
				IdLaneTransversal = result.IdLaneTransversal,
				IdPictureSitePlan = result.IdPicturePlan,
				IdCity = result.IdCity,
				MainBuildingAddress = new AddressGenerator()
					.GenerateAddress(result.CivicNumber, result.CivicLetter, result.LaneName, result.GenericDescription, result.PublicDescription, result.AddWhiteSpaceAfter),
				MainBuildingIdLane = result.MainBuildingIdLane,
				MainBuildingName = result.MainBuildingName,
				MainBuildingIdRiskLevel = result.MainBuildingIdRiskLevel,
				MainBuildingIdUtilisationCode = result.MainBuildingIdUtilisationCode,
				MainBuildingMatricule = result.Matricule,
				OtherInformation = result.OtherInformation,
				IdBuilding = result.IdBuilding,
				IdSurvey = result.IdSurvey,
				IsSurveyCompleted = result.IsSurveyCompleted,
				Status = result.Status,
				ApprobationRefusalReason = result.Status == InspectionStatus.Refused ? result.ApprobationRefusal : ""
			};
		}

		private void CreateDetailForMainBuildingWhenMissing(Guid inspectionId)
		{
			var idBuilding = Context.Inspections.AsNoTracking()
				.Where(i => i.Id == inspectionId)
				.Select(i => i.IdBuilding)
				.FirstOrDefault();

			if (idBuilding != Guid.Empty && !Context.BuildingDetails.Any(d => d.IdBuilding == idBuilding && d.IsActive))
			{
				var detail = new BuildingDetail {IdBuilding = idBuilding};
				Context.Add(detail);
				Context.SaveChanges();
			}
		}

		// todo: try to get these two functions to be more generic so there can be only one.
		public bool TryToChangeIntersection(Guid buildingId, Guid? idLaneTransversal)
		{
			var form = Context.Find<Building>(buildingId);
			if (form != null)
			{
				form.IdLaneTransversal = idLaneTransversal;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public bool TryToChangeIdPicture(Guid detailId, Guid? idPicture)
		{
			var form = Context.Find<BuildingDetail>(detailId);
			if (form != null)
			{
				form.IdPicturePlan = idPicture;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		private string getApprobationRefusalReason(Inspection inspection)
		{
			if(inspection.Visits != null)
				return inspection.Visits.Last(iv => iv.IsActive && iv.Status == InspectionVisitStatus.Completed)
					.ReasonForApprobationRefusal;

			return "";
		}
	}
}