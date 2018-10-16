using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

		public List<InspectionPictureForWeb> GetFile(Guid pictureId)
		{
			var query =
				from p in Context.InspectionPictures
				where p.IsActive && p.Id == pictureId
				select p;

			var picture = query.ToList();
			if (picture == null)
			{
				return null;
			}

			/*return new PictureForWeb
			{
				Id = picture.Id,
				DataUri = string.Format(
					"data:{0};base64,{1}",
					picture.MimeType == "" || picture.MimeType is null ? "image/jpeg" : picture.MimeType,
					Convert.ToBase64String(picture.Data)
				),
				SketchJson = picture.SketchJson,
			};*/

			return picture.Select(pic => new InspectionPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.Id,
				IdParent = pictureId,
				PictureData = string.Format(
						"data:{0};base64,{1}",
						pic.MimeType == "" || pic.MimeType == null ? "image/jpeg" : pic.MimeType,
						Convert.ToBase64String(pic.Data)),
                SketchJson = pic.SketchJson
            }).ToList();
		}

		public Guid UploadFile(InspectionPictureForWeb picture)
		{
			var pic = new InspectionPicture{Id = picture.Id, DataUri = picture.PictureData, SketchJson = picture.SketchJson};

			var isExistRecord = Context.InspectionPictures.Any(p => p.Id == pic.Id);

			if (!isExistRecord)
				Context.Add(pic);
			else
				Context.Update(pic);

			Context.SaveChanges();
			return pic.Id;
		}
	}
}