using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Survi.Prevention.Models
{
	public class Picture : BaseModel
	{
        public string Name { get; set; } = "";
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public string Json { get; set; }

        public string DataUri
        {
            set
            {
                var pattern = new Regex(@"data:(?<type>.+?);base64,(?<data>.+)");
                var match = pattern.Match(value);
                var base64Data = match.Groups[2].Value;
                var contentType = match.Groups[1].Value;

                this.MimeType = contentType;
                this.Data = Convert.FromBase64String(base64Data);
            }
        }
	}
}

        [Column(TypeName = "json")]
        public string Json { get; set; }