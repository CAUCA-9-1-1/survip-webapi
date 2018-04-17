using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Picture")]
	public class PictureController : BaseSecuredController
	{
		private readonly PictureService service;

		public PictureController(PictureService service)
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

		[Route("{id:Guid}"), HttpPost]
		public ActionResult PostPicture(Guid id, [FromBody]PictureForWeb picture)
		{
			return Ok(service.UploadFile(id, picture));
		}
	}
}
