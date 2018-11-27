using Survi.Prevention.ServiceLayer.Import.BuildingImportation;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Mocks
{
    public class CustomFieldsWithPictureCopierMock : BuildingParticularRiskPictureCustomFieldCopier
    {
        public bool HasCreatedPicture { get; set; }

        protected override void CreatePictureWhenNeeded(ApiClient.DataTransferObjects.BuildingParticularRiskPicture importedObject, Models.Buildings.BuildingParticularRiskPicture entity)
        {
            var hasPicture = entity.Picture != null;
            base.CreatePictureWhenNeeded(importedObject, entity);
            HasCreatedPicture = !hasPicture && entity.Picture != null;
        }
    }
}