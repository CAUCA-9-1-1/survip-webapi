﻿using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using ImportedRisk = Survi.Prevention.ApiClient.DataTransferObjects.RiskLevel;
using DataRisk = Survi.Prevention.Models.Buildings.RiskLevel;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class RiskLevelImportationConverter
        : BaseLocalizableEntityConverter<
            ImportedRisk,
            DataRisk,
            RiskLevelLocalization>
    {
        public RiskLevelImportationConverter(
            IManagementContext context,
            AbstractValidator<ImportedRisk> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ImportedRisk importedObject,
            DataRisk entity)
        {
            entity.Code = importedObject.Code;
            entity.Color = importedObject.ArgbColor.ToString();
            entity.Sequence = importedObject.Sequence;
        }
    }
}