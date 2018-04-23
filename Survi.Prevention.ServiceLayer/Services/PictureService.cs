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
				from picture in Context.Pictures
				where picture.IsActive && picture.Id == pictureId
				select picture.Data;

			var data = await query.SingleOrDefaultAsync();
			if (data != null)
			{
				//var pic = Base64UrlEncoder.Encode(data);
				var pic = Convert.ToBase64String(data);
				return new PictureForWeb { Id = pictureId, Picture = pic};
			}				
			return null;
		}

		public Guid UploadFile(PictureForWeb data)
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
			Context.SaveChanges();
			return picture.Id;
		}

		static byte[] DecodeBase64Picture(string picture)
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