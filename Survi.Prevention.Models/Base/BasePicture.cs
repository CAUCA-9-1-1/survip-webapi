using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Survi.Prevention.Models.Base
{
	public abstract class BasePicture : BaseModel
	{
		public string Name { get; set; } = "";
		public string MimeType { get; set; }
		public byte[] Data { get; set; }
		[Column(TypeName = "json")]
		public string SketchJson { get; set; }

		public string DataUri
		{
			set
			{
				var pattern = new Regex(@"data:(?<type>.+?);base64,(?<data>.+)");
				var match = pattern.Match(value);
				var base64Data = match.Groups[2].Value;
				var contentType = match.Groups[1].Value;
				MimeType = contentType;
				Data = Convert.FromBase64String(base64Data);
			}
		}
	}
}