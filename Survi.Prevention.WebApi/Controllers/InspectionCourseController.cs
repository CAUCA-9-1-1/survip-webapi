﻿using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection")]
	public class InspectionCourseController : BaseSecuredController
	{
		private readonly InspectionBuildingCourseService service;

		public InspectionCourseController(InspectionBuildingCourseService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/course")]
		public ActionResult GetList(Guid idInspection)
		{
			return Ok(service.GetCourses(idInspection));
		}

		[HttpGet, Route("course/{idCourse:Guid}")]
		public ActionResult GetCourse(Guid idCourse, [FromHeader] string languageCode)
		{
			return Ok(service.GetCourse(idCourse, languageCode));
		}

		[HttpGet, Route("courselane/{idCourseLane:Guid}")]
		public ActionResult GetCourseLane(Guid idCourseLane)
		{
			return Ok(service.GetCourseLane(idCourseLane));
		}

		[HttpPost, Route("courselane")]
		public ActionResult SaveCourseLane([FromBody] BuildingCourseLane courseLane)
		{
			return Ok(service.AddOrUpdate(courseLane));
		}

		[HttpPost, Route("course")]
		public ActionResult SaveCourse([FromBody]BuildingCourse course)
		{
			return Ok(service.AddOrUpdate(course));
		}

		[HttpDelete, Route("course/{idCourse:Guid}")]
		public ActionResult DeleteCoures(Guid idCourse)
		{
			return Ok(service.Delete<BuildingCourse>(idCourse));
		}

		[HttpPost, Route("courselane/{idCourseLane:Guid}/sequence/{sequence}")]
		public ActionResult UpdateCourseLaneSequence(Guid idCourseLane, int sequence)
		{
			return Ok(service.UpdateCourseLaneSequence(idCourseLane, sequence));
		}

		[HttpDelete, Route("courselane/{idCourseLane:Guid}")]
		public ActionResult DeleteCourseLane(Guid idCourseLane)
		{
			return Ok(service.Delete<BuildingCourseLane>(idCourseLane));
		}

		/*[HttpPost, Route("buildingcourse")]
		public ActionResult SaveLane()
		{
			return Ok();
		}*/
	}
}