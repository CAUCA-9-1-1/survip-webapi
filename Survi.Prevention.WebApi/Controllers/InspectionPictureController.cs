using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
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
		public async Task<ActionResult> GetPicture(Guid id)
		{
			var data = await service.GetFile(id);
			if (data == null)
				return BadRequest();
			return Ok(data);
		}

		[HttpPut]
		public ActionResult PostPictureFile([FromBody]InspectionPicture picture)
		{
			return Ok(service.UploadFile(picture));
		}
	}
}