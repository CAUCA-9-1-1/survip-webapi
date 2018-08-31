using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingParticularRiskPictureGroupHandler : BaseReportGroupHandler<BuildingChildPictureForWeb>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.ParticularRiskPicture;

		public ReportBuildingParticularRiskPictureGroupHandler(ManagementContext context) : base(context)
		{
		}

		protected override List<BuildingChildPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			var query =
				from picRisk in Context.BuildingParticularRiskPictures.AsNoTracking()
				where picRisk.IdBuildingParticularRisk == idParent && picRisk.IsActive
				let pic = picRisk.Picture
				select new BuildingChildPictureForWeb
				{
					Id = pic.Id,
					IdPicture = pic.Id,
					PictureData = string.Format(
						"data:{0};base64,{1}",
						pic.MimeType == "" || pic.MimeType == null ? "image/jpeg" : pic.MimeType,
						Convert.ToBase64String(pic.Data)),
					SketchJson = pic.SketchJson
				};

			return query.ToList();
		}

		protected override string FormatPropertyValue((string name, string value) property)
		{
			if (property.name == "PictureData")
			{
				return "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " +
				       property.value +
				       "\" height=\"400\" />";
			}
			return base.FormatPropertyValue(property);
		}
	}
}