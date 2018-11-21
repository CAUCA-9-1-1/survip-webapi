﻿using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using HazardousMaterial = Survi.Prevention.ApiClient.DataTransferObjects.HazardousMaterial;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class HazardousMaterialImportationConverter
        : BaseLocalizableEntityConverter<
            HazardousMaterial,
            Models.Buildings.HazardousMaterial,
            HazardousMaterialLocalization>
    {
        public HazardousMaterialImportationConverter(
            IManagementContext context,
            AbstractValidator<HazardousMaterial> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            HazardousMaterial importedObject,
            Models.Buildings.HazardousMaterial entity)
        {
            entity.GuideNumber = importedObject.GuideNumber;
            entity.Number = importedObject.Number;
            entity.ReactToWater = importedObject.ReactToWater;
            entity.ToxicInhalationHazard = importedObject.ToxicInhalationHazard;
        }
    }
}