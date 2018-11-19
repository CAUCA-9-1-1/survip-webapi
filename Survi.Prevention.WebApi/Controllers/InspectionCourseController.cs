using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
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
		
		[HttpGet, Route("{idInspection:Guid}/listcourse")]
		public ActionResult GetCompleteList(Guid idInspection)
		{
			return Ok(service.GetCompleteCourses(idInspection));
		}

		[HttpGet, Route("course/{idCourse:Guid}")]
		public ActionResult GetCourse(Guid idCourse, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetCourse(idCourse, languageCode));
		}

		[HttpGet, Route("courselane/{idCourseLane:Guid}")]
		public ActionResult GetCourseLane(Guid idCourseLane)
		{
			return Ok(service.GetCourseLane(idCourseLane));
		}

		[HttpPost, Route("courselane")]
		public ActionResult SaveCourseLane([FromBody] InspectionBuildingCourseLane courseLane)
		{
			return Ok(service.AddOrUpdate(courseLane, CurrentUserId));
		}

		[HttpPost, Route("course")]
		public ActionResult SaveCourse([FromBody]InspectionBuildingCourse course)
		{
			return Ok(service.AddOrUpdate(course, CurrentUserId));
		}
		
		[HttpPost, Route("listcourse")]
		public ActionResult SaveCompleteCourses([FromBody]InspectionBuildingCourse course)
		{
			return Ok(service.SaveCompleteCourses(course));
		}

		[HttpDelete, Route("course/{idCourse:Guid}")]
		public ActionResult DeleteCoures(Guid idCourse)
		{
			return Ok(service.Delete<InspectionBuildingCourse>(idCourse));
		}

		[HttpPost, Route("courselane/{idCourseLane:Guid}/sequence/{sequence}")]
		public ActionResult UpdateCourseLaneSequence(Guid idCourseLane, int sequence)
		{
			return Ok(service.UpdateCourseLaneSequence(idCourseLane, sequence));
		}

		[HttpDelete, Route("courselane/{idCourseLane:Guid}")]
		public ActionResult DeleteCourseLane(Guid idCourseLane)
		{
			return Ok(service.Delete<InspectionBuildingCourseLane>(idCourseLane));
		}
	}
}