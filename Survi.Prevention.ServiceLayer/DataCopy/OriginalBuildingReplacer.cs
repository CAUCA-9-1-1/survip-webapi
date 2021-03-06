﻿using System;
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
	public class OriginalBuildingReplacer
	{
		private readonly IManagementContext context;

		public OriginalBuildingReplacer(IManagementContext context)
		{
			this.context = context;
		}

		public void ReplaceOriginalDataWithCopy(List<InspectionBuilding> buildingCopies)
		{
			foreach (var copy in buildingCopies)
				ReplaceBuildingData(copy);
		}

		public void ReplaceBuildingData(InspectionBuilding copy)
		{
			var building = GetBuilding(copy.Id);

            copy.CopyProperties(building);
			ReplaceAlarmPanel(copy, building);
			ReplaceContacts(copy, building);
			ReplaceFireHydrants(copy, building);
			ReplaceHazardousMaterials(copy, building);
			ReplaceParticularRisks(copy, building);
			ReplacePersonsRequiringAssistance(copy, building);
			ReplaceSprinklers(copy, building);
			ReplaceCourses(copy, building);
			ReplaceAnomalies(copy, building);
			ReplaceDetail(copy, building);
			building.Picture = ReplacePicture(copy.Picture, building.Picture);
		}

		private void ReplaceDetail(InspectionBuilding copy, Building building)
		{
			AddBuildingDetailWhenMissing(building);
			copy.Detail.CopyProperties(building.Detail, nameof(copy.Detail.Id));
			building.Detail.PlanPicture = ReplacePicture(copy.Detail.PlanPicture, building.Detail.PlanPicture);
		}

		private static void AddBuildingDetailWhenMissing(Building building)
		{
			if (building.Detail == null)
				building.Detail = new BuildingDetail();
		}

		private void ReplaceAnomalies(InspectionBuilding copy, Building building)
		{
			foreach (var anomaly in copy.Anomalies)
			{
				var original = building.Anomalies.FirstOrDefault(p => p.Id == anomaly.Id);
				if (original == null)
				{
					original = new BuildingAnomaly { Pictures = new List<BuildingAnomalyPicture>() };
					building.Anomalies.Add(original);
				}

				anomaly.CopyProperties(original);
				ReplaceAnomalyPictures(anomaly, original);
			}
		}

		private void ReplaceAnomalyPictures(InspectionBuildingAnomaly copy, BuildingAnomaly anomaly)
		{
			foreach (var anoPic in copy.Pictures)
			{
				var original = anomaly.Pictures.FirstOrDefault(p => p.Id == anoPic.Id);
				if (original == null)
				{
					original = new BuildingAnomalyPicture();
					anomaly.Pictures.Add(original);
				}

				anoPic.CopyProperties(original);
				original.Picture = ReplacePicture(anoPic.Picture, original.Picture);
			}
		}

		private Picture ReplacePicture(InspectionPicture copy, Picture original)
		{
			if (IsNewPicture(copy, original))
			{
				return CreatePicture(copy);
			}

			if (PictureHasChanged(copy, original))
			{
				original.IsActive = false;
				return CreatePicture(copy);
			}

			if (PictureHasBeenDeleted(copy, original))
			{
				original.IsActive = false;
				return original;
			}

			return original;
		}

        private static bool PictureHasBeenDeleted(InspectionPicture copy, Picture original)
        {
            return copy == null && original != null;
        }

        private static bool PictureHasChanged(InspectionPicture copy, Picture original)
        {
            return copy != null && copy.Id != original.Id;
        }

        private static bool IsNewPicture(InspectionPicture copy, Picture original)
        {
            return copy != null && original == null;
        }

        private Picture CreatePicture(InspectionPicture copy)
		{
			return new Picture
			{
				Id = copy.Id,
				CreatedOn = copy.CreatedOn,
				IsActive = copy.IsActive,
				Data = copy.Data,
				MimeType = copy.MimeType,
				Name = copy.Name,
				SketchJson = copy.SketchJson
			};
		}

		private void ReplaceCourses(InspectionBuilding copy, Building building)
		{
			foreach (var course in copy.Courses)
			{
				var original = building.Courses.FirstOrDefault(p => p.Id == course.Id);
				if (original == null)
				{
					original = new BuildingCourse { Lanes = new List<BuildingCourseLane>() };
					building.Courses.Add(original);
				}

				course.CopyProperties(original);
				ReplaceCourseLanes(course, original);
			}
		}

		private void ReplaceCourseLanes(InspectionBuildingCourse copy, BuildingCourse course)
		{
			foreach (var lane in copy.Lanes)
			{
				var original = course.Lanes.FirstOrDefault(p => p.Id == lane.Id);
				if (original == null)
				{
					original = new BuildingCourseLane();
					course.Lanes.Add(original);
				}

				lane.CopyProperties(original);
			}
		}

		private void ReplaceSprinklers(InspectionBuilding copy, Building building)
		{
			foreach (var sprinkler in copy.Sprinklers)
			{
				var original = building.Sprinklers.FirstOrDefault(p => p.Id == sprinkler.Id);
				if (original == null)
				{
					original = new BuildingSprinkler();
					building.Sprinklers.Add(original);
				}

				sprinkler.CopyProperties(original);
			}
		}

		private void ReplacePersonsRequiringAssistance(InspectionBuilding copy, Building building)
		{
			foreach (var person in copy.PersonsRequiringAssistance)
			{
				var original = building.PersonsRequiringAssistance.FirstOrDefault(p => p.Id == person.Id);
				if (original == null)
				{
					original = new BuildingPersonRequiringAssistance();
					building.PersonsRequiringAssistance.Add(original);
				}

				person.CopyProperties(original);
			}
		}

		private void ReplaceParticularRisks(InspectionBuilding copy, Building building)
		{
			foreach (var risk in copy.ParticularRisks)
			{
				var original = building.ParticularRisks.FirstOrDefault(p => p.Id == risk.Id);
				if (original == null)
				{
					original = CreateNewRisk(risk);
					building.ParticularRisks.Add(original);
				}
				risk.CopyProperties(original);
				ReplaceParticularRiskPictures(risk, original);
			}
		}

		private void ReplaceParticularRiskPictures(InspectionBuildingParticularRisk copy, BuildingParticularRisk risk)
		{
			foreach (var anoPic in copy.Pictures)
			{
				var original = risk.Pictures.FirstOrDefault(p => p.Id == anoPic.Id);
				if (original == null)
				{
					original = new BuildingParticularRiskPicture();
					risk.Pictures.Add(original);
				}

				anoPic.CopyProperties(original);
				original.Picture = ReplacePicture(anoPic.Picture, original.Picture);
			}
		}

		private BuildingParticularRisk CreateNewRisk(InspectionBuildingParticularRisk copy)
		{
			if (copy is InspectionBuildingWallParticularRisk)
				return new BuildingWallParticularRisk { Pictures = new List<BuildingParticularRiskPicture>() };
			if (copy is InspectionBuildingFloorParticularRisk)
				return new BuildingFloorParticularRisk { Pictures = new List<BuildingParticularRiskPicture>() };
			if (copy is InspectionBuildingFoundationParticularRisk)
				return new BuildingFoundationParticularRisk { Pictures = new List<BuildingParticularRiskPicture>() };
			return new BuildingRoofParticularRisk { Pictures = new List<BuildingParticularRiskPicture>() };
		}

		private void ReplaceHazardousMaterials(InspectionBuilding copy, Building building)
		{
			foreach (var material in copy.HazardousMaterials)
			{
				var original = building.HazardousMaterials.FirstOrDefault(p => p.Id == material.Id);
				if (original == null)
				{
					original = new BuildingHazardousMaterial();
					building.HazardousMaterials.Add(original);
				}

				material.CopyProperties(original);
			}
		}

		private void ReplaceFireHydrants(InspectionBuilding copy, Building building)
		{
			foreach (var hydrant in copy.FireHydrants)
			{
				var original = building.FireHydrants.FirstOrDefault(p => p.Id == hydrant.Id);
				if (original == null)
				{
					original = new BuildingFireHydrant();
					building.FireHydrants.Add(original);
				}

				hydrant.CopyProperties(original);
			}
		}

		private void ReplaceContacts(InspectionBuilding copy, Building building)
		{
			foreach (var contact in copy.Contacts)
			{
				var original = building.Contacts.FirstOrDefault(p => p.Id == contact.Id);
				if (original == null)
				{
					original = new BuildingContact();
					building.Contacts.Add(original);
				}

				contact.CopyProperties(original);
			}
		}

		private void ReplaceAlarmPanel(InspectionBuilding copy, Building building)
		{
			foreach (var panel in copy.AlarmPanels)
			{
				var original = building.AlarmPanels.FirstOrDefault(p => p.Id == panel.Id);
				if (original == null)
				{
					original = new BuildingAlarmPanel();
					building.AlarmPanels.Add(original);
				}

				panel.CopyProperties(original);
			}
		}

		private Building GetBuilding(Guid buildingId)
		{
			return context.Buildings
				.Where(building => building.IsActive && building.Id == buildingId)
				.Include(building => building.AlarmPanels)
				.Include(building => building.Courses)
				.ThenInclude(course => course.Lanes)
				.Include(building => building.Contacts)
				.Include(building => building.Detail)
				.ThenInclude(detail => detail.PlanPicture)
				.Include(building => building.FireHydrants)
				.Include(building => building.HazardousMaterials)
				.Include(building => building.PersonsRequiringAssistance)
				.Include(building => building.Sprinklers)
				.Include(building => building.Anomalies)
				.ThenInclude(anomaly => anomaly.Pictures)
				.ThenInclude(pic => pic.Picture)
				.Include(building => building.ParticularRisks)
				.ThenInclude(risk => risk.Pictures)
				.ThenInclude(riskPic => riskPic.Picture)
				.First();
		}
	}
}