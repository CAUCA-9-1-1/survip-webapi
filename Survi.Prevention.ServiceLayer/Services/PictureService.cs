using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PictureService : BaseService
	{
		public PictureService(ManagementContext context) : base(context)
		{
		}

		public async Task<PictureForWeb> GetFile(Guid pictureId)
		{
			var query =
				from p in Context.Pictures
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

        public Guid UploadFile(Picture picture)
        {
            var isExistRecord = Context.Pictures.Any(p => p.Id == picture.Id);

            if (!isExistRecord)
                Context.Add(picture);
            else
	            Context.Update(picture);

            Context.SaveChanges();
            return picture.Id;
        }
	}
}