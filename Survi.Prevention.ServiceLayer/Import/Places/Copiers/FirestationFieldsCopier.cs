using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.Places.Copiers
{
    public class FirestationFieldsCopier 
        : BaseCustomFieldsCopier<Firestation,Models.FireSafetyDepartments.Firestation>
    {
        protected override void CopyValues(Firestation importedObject, Models.FireSafetyDepartments.Firestation entity)
        {
            entity.Email = importedObject.Email;
            entity.FaxNumber = importedObject.FaxNumber;
            entity.IdBuilding = ParseId(importedObject.IdBuilding);
            entity.IdFireSafetyDepartment = Guid.Parse(importedObject.IdFireSafetyDepartment);
            entity.Name = importedObject.Name;
        }
    }
}
