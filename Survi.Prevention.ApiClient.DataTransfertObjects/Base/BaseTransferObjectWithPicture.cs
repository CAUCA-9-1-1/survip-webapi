namespace Survi.Prevention.ApiClient.DataTransferObjects.Base
{
    public abstract class BaseTransferObjectWithPicture : BaseTransferObject
    {
        public byte[] PictureData { get; set; }
        public string MimeType { get; set; }
        public string PictureName { get; set; }
        public string SketchJson { get; set; }
    }
}