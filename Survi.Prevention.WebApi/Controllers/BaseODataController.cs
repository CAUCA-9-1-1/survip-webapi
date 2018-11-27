using System;
using System.IO;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json")]
	public abstract class BaseODataController<TService, TModel> : ODataController
		where TModel : BaseModel, new()
		where TService : BaseCrudService<TModel>
	{
		protected readonly TService Service;
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
		
		protected BaseODataController(TService service)
		{
			Service = service;
		}

		protected string ReadBody()
		{
			using (var reader = new StreamReader(Request.Body))
				return reader.ReadToEnd();
		}
	}
}