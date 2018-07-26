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
            {
                Context.Add(picture);
            }

            Context.SaveChanges();
            return picture.Id;
        }

        public Guid UploadFileBase64(PictureForWeb data)
		{
			Picture picture = null;
			if (data.Id.HasValue)
				picture = Context.Pictures.Find(data.Id);

			if (picture == null)
			{
				picture = new Picture{ Name = ""};
				Context.Add(picture);		
			}

			var encodedPicture = DecodeBase64Picture(data.Picture); //Bae64UrlEncoder.DecodeBytes(data.Picture);
			picture.Data = encodedPicture;
            picture.SketchJson = data.SketchJson;
            Context.SaveChanges();
			return picture.Id;
		}

        public static byte[] DecodeBase64Picture(string picture)
		{
			string s = picture;
			s = s.Replace('-', '+'); // 62nd char of encoding
			s = s.Replace('_', '/'); // 63rd char of encoding
			switch (s.Length % 4) // Pad with trailing '='s
			{
				case 0: break; // No pad chars in this case
				case 2: s += "=="; break; // Two pad chars
				case 3: s += "="; break; // One pad char
				default:
					throw new System.Exception(
						"Illegal base64url string!");
			}
			return Convert.FromBase64String(s); // Standard base64 decoder
		}
	}
}
            picture.SketchJson = data.SketchJson;
            Context.SaveChanges();