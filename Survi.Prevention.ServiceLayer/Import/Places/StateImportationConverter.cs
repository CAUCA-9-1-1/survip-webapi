using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using ImportedState = Survi.Prevention.ApiClient.DataTransferObjects.State;
using State = Survi.Prevention.Models.FireSafetyDepartments.State;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class StateImportationConverter
        : BaseLocalizableEntityConverter<ImportedState, State, StateLocalization>
    {
        public StateImportationConverter(IManagementContext context, AbstractValidator<ImportedState> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(ImportedState importedObject, State entity)
        {
            entity.IdCountry = Guid.Parse(importedObject.IdCountry);
            entity.AnsiCode = importedObject.AnsiCode;
        }

        protected override void GetRealForeignKeys(ImportedState importedObject)
        {
            importedObject.IdCountry = GetRealId<Country>(importedObject.IdCountry);
        }
    }
}
