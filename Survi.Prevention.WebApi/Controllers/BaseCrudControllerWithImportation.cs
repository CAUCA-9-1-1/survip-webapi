using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    public abstract class BaseCrudControllerWithImportation<TService, TModel, TImportedModel> : BaseCrudController<TService, TModel>
        where TModel : BaseImportedModel, new()
        where TImportedModel : BaseTransferObject
        where TService : BaseCrudServiceWithImportation<TModel, TImportedModel>
    {
        protected BaseCrudControllerWithImportation(TService service) : base(service)
        {
        }

        [HttpPost, Route("import")]
        public ActionResult Import([FromBody] List<TImportedModel> importedEntities)
        {
            if (importedEntities == null)
                return BadRequest();
            return Ok(Service.Import(importedEntities));
        }
    }
}