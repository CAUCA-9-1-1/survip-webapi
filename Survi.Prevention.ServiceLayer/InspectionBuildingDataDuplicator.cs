using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer
{
    public class InspectionBuildingDataCopyManager : IDisposable
    {
	    private ManagementContext context;
		private readonly Guid inspectionId;
		private readonly Guid mainBuildingId;

		public InspectionBuildingDataCopyManager(ManagementContext context, Guid inspectionId)
		{
			this.context = context;
			this.inspectionId = inspectionId;
			mainBuildingId = GetInspectionMainBuilding(context, inspectionId);
		}

	    private static Guid GetInspectionMainBuilding(ManagementContext context, Guid inspectionId)
	    {
		    return context.Inspections.AsNoTracking()
			    .Where(inspection => inspection.Id == inspectionId)
			    .Select(inspection => inspection.IdBuilding)
			    .FirstOrDefault();
	    }

	    public void Dispose()
	    {
			context = null;
	    }

		public void DuplicateData()
		{
			if (!DataHaveAlreadyBeenDuplicated())
				CopyInspectionBuildings();
		}

		private bool DataHaveAlreadyBeenDuplicated()
		{
			return context.InspectionBuildings.AsNoTracking()
				.Any(building => building.IdInspection == inspectionId);
		}

		private void CopyInspectionBuildings()
		{
			var buildings = context.Buildings
				.Where(building => building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId))
				.Include(building => building.AlarmPanels)
				.Include(building => building.Contacts)
				.Include(building => building.Detail)
					.ThenInclude(detail => detail.PlanPicture)
				.Include(building => building.FireHydrants)
				.Include(building => building.HazardousMaterials)
				.Include(building => building.Localizations)
				.Include(building => building.PersonsRequiringAssistance)
				.Include(building => building.Sprinklers)
				.ToList();
				

			foreach(var building in buildings)
			{
				if (building.Detail == null)
					building.Detail = new BuildingDetail {IdBuilding = building.Id};
				context.Add(GenerateInspectionBuilding(building));
				CopyBuildingChildren(building.Id);
			}

			context.SaveChanges();
		}

	    private void CopyBuildingChildren(Guid buildingId)
	    {
		    CopyBuildingCourses(buildingId);
		    CopyBuildingAnomalies(buildingId);
		    CopyBuildingParticularRisks(buildingId);
	    }

	    private void CopyBuildingParticularRisks(Guid buildingId)
	    {
		    var risks = context.BuildingParticularRisks.AsNoTracking()
			    .Where(risk => risk.IdBuilding == buildingId)
				.Include(risk => risk.Pictures)
					.ThenInclude(riskPicture => riskPicture.Picture)
			    .ToList();

			foreach(var risk in risks)				
				context.Add(CreateRiskCopy(risk));			
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

	    private T DuplicateRisk<T>(BuildingParticularRisk risk) where T: InspectionBuildingParticularRisk, new()
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
			var anomalies = context.BuildingAnomalies.AsNoTracking()
				.Where(anomaly => anomaly.IdBuilding == buildingId)
				.Include(anomaly => anomaly.Pictures)
					.ThenInclude(pic => pic.Picture)
				.ToList();

			foreach(var anomaly in anomalies)
			{
				context.Add(new InspectionBuildingAnomaly
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
			var courses = context.BuildingCourses.AsNoTracking()
				.Where(course => course.IdBuilding == buildingId)
				.Include(course => course.Lanes)				
				.ToList();

			foreach(var course in courses)
				AddCourseCopy(course);
		}

	    private void AddCourseCopy(BuildingCourse course)
	    {
		    context.Add(new InspectionBuildingCourse
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
		    return new InspectionBuilding
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
				IdInspection = inspectionId,
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
				YearOfConstruction = building.YearOfConstruction,
				AlarmPanels = CopyAlarmPanels(building.AlarmPanels).ToList(),
				Contacts = CopyContacts(building.Contacts).ToList(),
				FireHydrants = CopyFireHydrants(building.FireHydrants).ToList(),
				Detail = CopyDetail(building.Detail),
				HazardousMaterials = CopyHazardousMaterials(building.HazardousMaterials).ToList(),
				PersonsRequiringAssistance = CopyPersonsRequiringAssistance(building.PersonsRequiringAssistance).ToList(),
				Sprinklers = CopySprinklers(building.Sprinklers).ToList(),	
				Localizations = CopyLocalizations(building.Localizations).ToList()
		    };
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

	    private IEnumerable<InspectionBuildingSprinkler> CopySprinklers(ICollection<BuildingSprinkler> buildingSprinklers)
	    {
		    foreach (var sprinkler in buildingSprinklers)
			    yield return new InspectionBuildingSprinkler
			    {
					CollectorLocation = sprinkler.CollectorLocation,
					CreatedOn = sprinkler.CreatedOn,
					Floor = sprinkler.Floor,
					Id = sprinkler.Id,
					IdBuilding = sprinkler.IdBuilding,
					IdSprinklerType = sprinkler.IdSprinklerType,
					IsActive = sprinkler.IsActive,
					PipeLocation = sprinkler.PipeLocation,
					Sector = sprinkler.Sector,
					Wall = sprinkler.Wall
			    };
	    }

	    private IEnumerable<InspectionBuildingPersonRequiringAssistance> CopyPersonsRequiringAssistance(ICollection<BuildingPersonRequiringAssistance> buildingPersonsRequiringAssistance)
	    {
		    foreach (var person in buildingPersonsRequiringAssistance)
			    yield return new InspectionBuildingPersonRequiringAssistance
			    {
					ContactName = person.ContactName,
					ContactPhoneNumber = person.ContactPhoneNumber,
					CreatedOn = person.CreatedOn,
					DayIsApproximate = person.DayIsApproximate,
					DayResidentCount = person.DayResidentCount,
					Description = person.Description,
					EveningIsApproximate = person.EveningIsApproximate,
					EveningResidentCount = person.EveningResidentCount,
					Floor = person.Floor,
					Id = person.Id,
					IdBuilding = person.IdBuilding, 
					IdPersonRequiringAssistanceType = person.IdPersonRequiringAssistanceType,
					IsActive = person.IsActive,
					Local = person.Local,
					NightIsApproximate = person.NightIsApproximate,
					NightResidentCount = person.NightResidentCount,
					PersonName = person.PersonName,
			    };
	    }

	    private IEnumerable<InspectionBuildingHazardousMaterial> CopyHazardousMaterials(ICollection<BuildingHazardousMaterial> buildingHazardousMaterials)
	    {
		    foreach (var material in buildingHazardousMaterials)
			    yield return new InspectionBuildingHazardousMaterial
			    {
					CapacityContainer = material.CapacityContainer,
					Container = material.Container,
					CreatedOn = material.CreatedOn,
					Floor = material.Floor,
					GasInlet = material.GasInlet,
					Id = material.Id,
					IdBuilding = material.IdBuilding,
					IdHazardousMaterial = material.IdHazardousMaterial,
					IdUnitOfMeasure = material.IdUnitOfMeasure,
					IsActive = material.IsActive,
					OtherInformation = material.OtherInformation,
					Place = material.Place,
					Quantity = material.Quantity,
					Sector = material.Sector,
					SecurityPerimeter = material.SecurityPerimeter,
					SupplyLine = material.SupplyLine,
					TankType = material.TankType,
					Wall = material.Wall
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
				//todo: picture!!!!				
		    };
	    }

	    private IEnumerable<InspectionBuildingFireHydrant> CopyFireHydrants(ICollection<BuildingFireHydrant> buildingFireHydrants)
	    {
		    foreach (var hydrant in buildingFireHydrants)
			    yield return new InspectionBuildingFireHydrant
			    {
					CreatedOn = hydrant.CreatedOn,
					DeletedOn = hydrant.DeletedOn,
					Id = hydrant.Id,
					IdBuilding = hydrant.IdBuilding,
					IdFireHydrant = hydrant.IdFireHydrant,
					IsActive = hydrant.IsActive
			    };
	    }

	    private IEnumerable<InspectionBuildingContact> CopyContacts(ICollection<BuildingContact> buildingContacts)
	    {
		    foreach (var contact in buildingContacts)
			    yield return new InspectionBuildingContact
			    {
					Id = contact.Id,
					CallPriority = contact.CallPriority,
					 CellphoneNumber = contact.CellphoneNumber,
					CreatedOn = contact.CreatedOn,
					IdBuilding = contact.IdBuilding,
					IsActive = contact.IsActive,
					FirstName =contact.FirstName,
					IsOwner = contact.IsOwner,
					LastName = contact.LastName,
					OtherNumber = contact.OtherNumber,
					OtherNumberExtension = contact.OtherNumberExtension,
					PagerCode = contact.PagerCode,
					PagerNumber = contact.PagerNumber,
					PhoneNumber = contact.PhoneNumber,
					PhoneNumberExtension = contact.PhoneNumberExtension
			    };
	    }

	    private IEnumerable<InspectionBuildingAlarmPanel> CopyAlarmPanels(ICollection<BuildingAlarmPanel> buildingAlarmPanels)
	    {
		    foreach (var panel in buildingAlarmPanels)
			    yield return new InspectionBuildingAlarmPanel
			    {
				    Id = panel.Id,
				    CreatedOn = panel.CreatedOn,
				    Floor = panel.Floor,
				    IdAlarmPanelType = panel.IdAlarmPanelType,
				    IdBuilding = panel.IdBuilding,
				    IsActive = panel.IsActive,
				    Sector = panel.Sector,
				    Wall = panel.Wall
			    };
	    }
    }
}
