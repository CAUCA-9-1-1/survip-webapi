
using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedFireSafetyDepartment = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartment;
using fireSafetyDepartment = Survi.Prevention.Models.FireSafetyDepartments.FireSafetyDepartment;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment.CustomFieldsCopier
{
    public class FireSafetyDepartmentCustomFieldsCopier : BaseCustomFieldsCopierWithPicture<importedFireSafetyDepartment, fireSafetyDepartment>
    {
        protected override void CopyValues(importedFireSafetyDepartment importedObject, fireSafetyDepartment entity)
        {
            InitiateForeignKeyValues(importedObject, entity);
            InitiateCustomFieldsValues(importedObject, entity);
        }

        protected override void CreatePictureWhenNeeded(importedFireSafetyDepartment importedObject,
            fireSafetyDepartment entity)
        {
            if (entity.Picture == null && importedObject.PictureData != null)
            {
                entity.Picture = new Models.Picture();
            }
        }

        protected override BasePicture GetEntityPicture(fireSafetyDepartment entity)
        {
            return entity.Picture;
        }

        private void InitiateCustomFieldsValues(importedFireSafetyDepartment importedObject,
            fireSafetyDepartment entity)
        {
            entity.Language = importedObject.Language;
        }

        private void InitiateForeignKeyValues(importedFireSafetyDepartment importedObject, fireSafetyDepartment entity)
        {
            entity.IdCounty = Guid.Parse(importedObject.IdCounty);
        }
    }
}
