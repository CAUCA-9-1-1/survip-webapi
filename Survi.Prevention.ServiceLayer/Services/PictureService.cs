using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.DataLayer;
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
				from picture in Context.Pictures
				where picture.IsActive && picture.Id == pictureId
				select picture.Data;

			var data = await query.SingleOrDefaultAsync();
			if (data != null)
				return new PictureForWeb { Id = pictureId, Picture = Base64UrlEncoder.Decode(Convert.ToBase64String(data)) };
			return null;
		}

		public Guid UploadFile(Guid? pictureId, PictureForWeb data)
		{
			var picture = Context.Pictures.Find(pictureId);
			if (picture == null)
			{
				picture = new Models.Picture();
				Context.Add(picture);				
			}

			picture.Data = Convert.FromBase64String(Base64UrlEncoder.Encode(data.Picture));
			Context.SaveChanges();
			return picture.Id;
		}
	}
}