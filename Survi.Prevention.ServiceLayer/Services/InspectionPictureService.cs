using System;
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

		public async Task<PictureForWeb> GetFile(Guid pictureId)
		{
			var query =
				from p in Context.InspectionPictures
				where p.IsActive && p.Id == pictureId
				select p;

			var picture = await query.SingleOrDefaultAsync();
			if (picture == null)
			{
				return null;
			}

			return new PictureForWeb
			{
				Id = picture.Id,
				DataUri = string.Format(
					"data:{0};base64,{1}",
					picture.MimeType == "" || picture.MimeType is null ? "image/jpeg" : picture.MimeType,
					Convert.ToBase64String(picture.Data)
				),
				SketchJson = picture.SketchJson,
			};
		}

		public Guid UploadFile(InspectionPicture picture)
		{
			var isExistRecord = Context.InspectionPictures.Any(p => p.Id == picture.Id);

			if (!isExistRecord)
				Context.Add(picture);
			else
				Context.Update(picture);

			Context.SaveChanges();
			return picture.Id;
		}
	}
}