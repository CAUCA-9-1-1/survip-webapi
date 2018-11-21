using System;
using FluentValidation;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class RiskLevelImportationValidator 
        : BaseImportValidator<ApiClient.DataTransferObjects.RiskLevel>
    {
    }
}