using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InspectionPicture")]
	public class InspectionPictureController : BaseSecuredController
	{
		private readonly InspectionPictureService service;

		public InspectionPictureController(InspectionPictureService service)
		{
			this.service = service;
		}

		[Route("{id:Guid}"), HttpGet]
		public ActionResult GetPicture(Guid id)
		{
			var data = service.GetFile(id);
			if (data == null)
				return BadRequest();
			return Ok(data);
		}

		[HttpPut]
		public ActionResult PostPictureFile([FromBody]InspectionPictureForWeb picture)
		{
			return Ok(service.UploadFile(picture));
		}
	}
}