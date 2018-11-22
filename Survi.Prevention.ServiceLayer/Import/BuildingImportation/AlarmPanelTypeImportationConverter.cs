﻿using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using AlarmPanelType = Survi.Prevention.ApiClient.DataTransferObjects.AlarmPanelType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class AlarmPanelTypeImportationConverter
        : BaseLocalizableEntityConverter<
            AlarmPanelType,
            Models.Buildings.AlarmPanelType,
            AlarmPanelTypeLocalization>
    {
        public AlarmPanelTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<AlarmPanelType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            AlarmPanelType importedObject,
            Models.Buildings.AlarmPanelType entity)
        { }
    }
}