using System;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionPictureService : BaseService
	{
		public InspectionPictureService(ManagementContext context) : base(context)
		{
		}

		public InspectionPictureForWeb GetFile(Guid pictureId)
		{
			var query =
				from p in Context.InspectionPictures
				where p.IsActive && p.Id == pictureId
				select p;

			var picture = query.FirstOrDefault();

			return picture == null ? null : new InspectionPictureForWeb
			{
				Id = picture.Id,
				IdPicture = picture.Id,
				IdParent = pictureId,
				DataUri = string.Format(
						"data:{0};base64,{1}",
						string.IsNullOrEmpty(picture.MimeType) ? "image/jpeg" : picture.MimeType,
						Convert.ToBase64String(picture.Data)),
                SketchJson = picture.SketchJson
            };
		}

		public Guid UploadFile(InspectionPictureForWeb picture, Guid idWebUserLastModifiedBy)
		{
			var pic = new InspectionPicture{Id = picture.Id, DataUri = picture.DataUri, SketchJson = picture.SketchJson, IdWebUserLastModifiedBy = idWebUserLastModifiedBy};

			var isExistRecord = Context.InspectionPictures.Any(p => p.Id == pic.Id);

			if (!isExistRecord)
				Context.Add(pic);
			else
			{
				pic.LastModifiedOn = DateTime.Now;
				Context.Update(pic);
			}

			Context.SaveChanges();
			return pic.Id;
		}
	}
}