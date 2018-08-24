using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public abstract class BaseBuildingDuplicator
	{
		protected readonly ManagementContext Context;
		protected readonly Guid InspectionId;

		protected BaseBuildingDuplicator(ManagementContext context, Guid inspectionId)
		{
			this.Context = context;
			this.InspectionId = inspectionId;
		}

		protected TCopy DuplicateBuilding<TOriginal, TCopy>(TOriginal building)
			where TOriginal : BaseBuilding
			where TCopy : BaseBuilding, new()
		{
			return new TCopy
			{
				Id = building.Id,
				AppartmentNumber = building.AppartmentNumber,
				BuildingValue = building.BuildingValue,
				ChildType = building.ChildType,
				CivicLetter = building.CivicLetter,
				CivicLetterSupp = building.CivicLetterSupp,
				CivicNumber = building.CivicNumber,
				CivicSupp = building.CivicSupp,
				Coordinates = building.Coordinates,
				CoordinatesSource = building.CoordinatesSource,
				CreatedOn = building.CreatedOn,
				Details = building.Details,
				Floor = building.Floor,
				IdCity = building.IdCity,				
				IdLane = building.IdLane,
				IdLaneTransversal = building.IdLaneTransversal,
				IdParentBuilding = building.IdParentBuilding,
				IdPicture = building.IdPicture,
				IdRiskLevel = building.IdRiskLevel,
				IdUtilisationCode = building.IdUtilisationCode,
				IsActive = building.IsActive,
				Matricule = building.Matricule,
				NumberOfAppartment = building.NumberOfAppartment,
				NumberOfBuilding = building.NumberOfBuilding,
				NumberOfFloor = building.NumberOfFloor,
				PostalCode = building.PostalCode,
				ShowInResources = building.ShowInResources,
				Source = building.Source,
				Suite = building.Suite,
				UtilisationDescription = building.UtilisationDescription,
				VacantLand = building.VacantLand,
				YearOfConstruction = building.YearOfConstruction
			};
		}	
	}

	public class BuildingDuplicator : BaseBuildingDuplicator
	{
		

		public BuildingDuplicator(ManagementContext context, Guid inspectionId) 
		: base(context, inspectionId)
		{
		}

		public void DuplicateBuildings(IList<Building> buildings)
		{
			foreach (var building in buildings)
			{
				if (building.Detail == null)
					building.Detail = new BuildingDetail { IdBuilding = building.Id };
				Context.Add(GenerateInspectionBuilding(building));
				CopyBuildingChildren(building.Id);
			}
		}

		private void CopyBuildingChildren(Guid buildingId)
		{
			CopyBuildingCourses(buildingId);
			CopyBuildingAnomalies(buildingId);
			CopyBuildingParticularRisks(buildingId);
		}

		private void CopyBuildingParticularRisks(Guid buildingId)
		{
			var risks = Context.BuildingParticularRisks.AsNoTracking()
				.Where(risk => risk.IdBuilding == buildingId)
				.Include(risk => risk.Pictures)
				.ThenInclude(riskPicture => riskPicture.Picture)
				.ToList();

			foreach (var risk in risks)
				Context.Add(CreateRiskCopy(risk));
		}

		private InspectionBuildingParticularRisk CreateRiskCopy(BuildingParticularRisk risk)
		{
			if (risk is BuildingRoofParticularRisk)
				return DuplicateRisk<InspectionBuildingRoofParticularRisk>(risk);
			if (risk is BuildingFloorParticularRisk)
				return DuplicateRisk<InspectionBuildingFloorParticularRisk>(risk);
			if (risk is BuildingFoundationParticularRisk)
				return DuplicateRisk<InspectionBuildingFoundationParticularRisk>(risk);
			return DuplicateRisk<InspectionBuildingWallParticularRisk>(risk);
		}

		private T DuplicateRisk<T>(BuildingParticularRisk risk) where T : InspectionBuildingParticularRisk, new()
		{
			return new T
			{
				Id = risk.Id,
				Comments = risk.Comments,
				CreatedOn = risk.CreatedOn,
				Dimension = risk.Dimension,
				HasOpening = risk.HasOpening,
				IdBuilding = risk.IdBuilding,
				IsActive = risk.IsActive,
				IsWeakened = risk.IsWeakened,
				Sector = risk.Sector,
				Wall = risk.Wall,
				Pictures = CopyRiskPictures(risk.Pictures)
			};
		}

		private List<InspectionBuildingParticularRiskPicture> CopyRiskPictures(ICollection<BuildingParticularRiskPicture> riskPictures)
		{
			return riskPictures
				.Select(pic => new InspectionBuildingParticularRiskPicture
				{
					CreatedOn = pic.CreatedOn,
					Id = pic.Id,
					IdBuildingParticularRisk = pic.IdBuildingParticularRisk,
					IdPicture = pic.IdPicture,
					IsActive = pic.IsActive,
					Picture = CopyPicture(pic.Picture)
				})
				.ToList();
		}

		private void CopyBuildingAnomalies(Guid buildingId)
		{
			var anomalies = Context.BuildingAnomalies.AsNoTracking()
				.Where(anomaly => anomaly.IdBuilding == buildingId)
				.Include(anomaly => anomaly.Pictures)
				.ThenInclude(pic => pic.Picture)
				.ToList();

			foreach (var anomaly in anomalies)
			{
				Context.Add(new InspectionBuildingAnomaly
				{
					CreatedOn = anomaly.CreatedOn,
					Id = anomaly.Id,
					IdBuilding = anomaly.IdBuilding,
					IsActive = anomaly.IsActive,
					Notes = anomaly.Notes,
					Theme = anomaly.Theme,
					Pictures = CopyAnomalyPictures(anomaly)
				});
			}
		}

		private List<InspectionBuildingAnomalyPicture> CopyAnomalyPictures(BuildingAnomaly anomaly)
		{
			return anomaly.Pictures
				.Select(pic => new InspectionBuildingAnomalyPicture
				{
					CreatedOn = pic.CreatedOn,
					Id = pic.Id,
					IdBuildingAnomaly = pic.IdBuildingAnomaly,
					IdPicture = pic.IdPicture,
					IsActive = pic.IsActive,
					Picture = CopyPicture(pic.Picture)
				})
				.ToList();
		}

		private InspectionPicture CopyPicture(Picture picture)
		{
			if (picture == null)
				return null;
			return new InspectionPicture
			{
				Data = picture.Data,
				CreatedOn = picture.CreatedOn,
				Id = picture.Id,
				IsActive = picture.IsActive,
				MimeType = picture.MimeType,
				Name = picture.Name,
				SketchJson = picture.SketchJson
			};
		}

		private void CopyBuildingCourses(Guid buildingId)
		{
			var courses = Context.BuildingCourses.AsNoTracking()
				.Where(course => course.IdBuilding == buildingId)
				.Include(course => course.Lanes)
				.ToList();

			foreach (var course in courses)
				AddCourseCopy(course);
		}

		private void AddCourseCopy(BuildingCourse course)
		{
			Context.Add(new InspectionBuildingCourse
			{
				CreatedOn = course.CreatedOn,
				Id = course.Id,
				IdBuilding = course.IdBuilding,
				IdFirestation = course.IdFirestation,
				IsActive = course.IsActive,
				Lanes = CopyCourseLanes(course)
			});
		}

		private static List<InspectionBuildingCourseLane> CopyCourseLanes(BuildingCourse course)
		{
			return course.Lanes
				.Select(lane => new InspectionBuildingCourseLane
				{
					CreatedOn = lane.CreatedOn,
					Id = lane.Id,
					IdBuildingCourse = lane.IdBuildingCourse,
					IdLane = lane.IdLane,
					IsActive = lane.IsActive,
					Direction = lane.Direction,
					Sequence = lane.Sequence
				}).ToList();
		}

		private InspectionBuilding GenerateInspectionBuilding(Building building)
		{
			var copy = DuplicateBuilding<Building, InspectionBuilding>(building);
			copy.IdInspection = InspectionId;
			copy.AlarmPanels = new AlarmPanelDuplicator()
				.Duplicate<BuildingAlarmPanel, InspectionBuildingAlarmPanel>(building.AlarmPanels).ToList();
			copy.Contacts = new ContactDuplicator()
				.Duplicate<BuildingContact, InspectionBuildingContact>(building.Contacts).ToList();
			copy.FireHydrants = new FireHydrantDuplicator()
				.Duplicate<BuildingFireHydrant, InspectionBuildingFireHydrant>(building.FireHydrants).ToList();
			copy.Detail = CopyDetail(building.Detail);
			copy.HazardousMaterials = new HazardousMaterialDuplicator()
				.Duplicate<BuildingHazardousMaterial, InspectionBuildingHazardousMaterial>(building.HazardousMaterials).ToList();
			copy.PersonsRequiringAssistance = new PersonRequiringAssistanceDuplicator()
				.Duplicate<BuildingPersonRequiringAssistance, InspectionBuildingPersonRequiringAssistance>(building.PersonsRequiringAssistance).ToList();
			copy.Sprinklers = new SprinklerDuplicator()
				.Duplicate<BuildingSprinkler, InspectionBuildingSprinkler>(building.Sprinklers).ToList();
			copy.Localizations = CopyLocalizations(building.Localizations).ToList();

			return copy;
		}

		private IEnumerable<InspectionBuildingLocalization> CopyLocalizations(ICollection<BuildingLocalization> buildingLocalizations)
		{
			foreach (var loc in buildingLocalizations)
				yield return new InspectionBuildingLocalization
				{
					CreatedOn = loc.CreatedOn,
					Id = loc.Id,
					IdParent = loc.IdParent,
					LanguageCode = loc.LanguageCode,
					Name = loc.Name,
					IsActive = loc.IsActive
				};
		}

		private InspectionBuildingDetail CopyDetail(BuildingDetail detail)
		{
			return new InspectionBuildingDetail
			{
				Id = detail.Id,
				AdditionalInformation = detail.AdditionalInformation,
				ApprovedOn = detail.ApprovedOn,
				IsActive = detail.IsActive,
				CreatedOn = detail.CreatedOn,
				EstimatedWaterFlow = detail.EstimatedWaterFlow,
				Height = detail.Height,
				IdBuilding = detail.IdBuilding,
				IdBuildingSidingType = detail.IdBuildingSidingType,
				IdBuildingType = detail.IdBuildingType,
				IdConstructionFireResistanceType = detail.IdConstructionFireResistanceType,
				IdConstructionType = detail.IdConstructionType,
				IdRoofMaterialType = detail.IdRoofMaterialType,
				IdRoofType = detail.IdRoofType,
				IdUnitOfMeasureEstimatedWaterFlow = detail.IdUnitOfMeasureEstimatedWaterFlow,
				RevisedOn = detail.RevisedOn,
				IdUnitOfMeasureHeight = detail.IdUnitOfMeasureHeight,
				PlanPicture = CopyPicture(detail.PlanPicture)
			};
		}		
	}
}