using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/UnitOfMeasure")]
    public class UnitOfMeasureController 
        : BaseCrudControllerWithImportation<UnitOfMeasureService, UnitOfMeasure, ApiClient.DataTransferObjects.UnitOfMeasure>
    {
	    public UnitOfMeasureController(UnitOfMeasureService service) : base(service)
	    {
	    }

        [HttpGet, Route("all")]
        public ActionResult<IEnumerable<UnitOfMeasureForDisplay>> GetAllMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }

        [HttpGet, Route("rate")]
	    public ActionResult<List<GenericModelForDisplay>> GetRateMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Rate));
	    }

	    [HttpGet, Route("diameter")]
	    public ActionResult<List<GenericModelForDisplay>> GetDiameterMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Diameter));
		}

	    [HttpGet, Route("pressure")]
	    public ActionResult<List<GenericModelForDisplay>> GetPressureMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Pressure));
		}

	    [HttpGet, Route("capacity")]
	    public ActionResult<List<GenericModelForDisplay>> GetCapacityMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Capacity));
		}

	    [HttpGet, Route("dimension")]
	    public ActionResult GetDimensionMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Dimension));
		}
	}
}
