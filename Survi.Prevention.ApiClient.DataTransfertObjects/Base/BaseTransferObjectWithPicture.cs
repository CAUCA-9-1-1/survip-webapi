namespace Survi.Prevention.ApiClient.DataTransferObjects.Base
{
    public abstract class BaseTransferObjectWithPicture : BaseTransferObject
    {
        public string PictureData { get; set; }
        public string MimeType { get; set; }
        public string PictureName { get; set; }
        public string SketchJson { get; set; }
    }
}