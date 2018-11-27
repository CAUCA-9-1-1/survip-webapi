using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public abstract class BaseCustomFieldsCopierWithPicture<TIn, TOut> : BaseCustomFieldsCopier<TIn, TOut>
        where TIn : BaseTransferObjectWithPicture
        where TOut : BaseModel
    {
        public override void DuplicateFieldsValues(TIn importedObject, TOut entity)
        {
            base.DuplicateFieldsValues(importedObject, entity);
            CreatePictureWhenNeeded(importedObject, entity);
            CopyPictureFields(importedObject, entity);
        }

        protected abstract BasePicture GetEntityPicture(TOut entity);

        protected void CopyPictureFields(BaseTransferObjectWithPicture importedPicture, TOut entity)
        {
            var picture = GetEntityPicture(entity);
            if (picture != null && importedPicture != null)
            {
                picture.Data = importedPicture.PictureData;
                picture.Name = importedPicture.PictureName;
                picture.SketchJson = importedPicture.SketchJson;
                picture.MimeType = importedPicture.MimeType;
            }
        }

        protected abstract void CreatePictureWhenNeeded(TIn importedObject, TOut entity);
    }
}