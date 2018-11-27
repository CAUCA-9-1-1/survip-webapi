using System;
using System.Text;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Copiers
{
    public class BuildingAnomalyPictureCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly BuildingAnomalyPicture imported;
        private readonly Models.Buildings.BuildingAnomalyPicture entity;
        private readonly BuildingAnomalyPictureCustomFieldCopier copier;

        public BuildingAnomalyPictureCustomFieldsCopierTests()
        {
            copier = new BuildingAnomalyPictureCustomFieldCopier();
            idParent = Guid.NewGuid();
            imported = new BuildingAnomalyPicture
            {
                IdBuildingAnomaly = idParent.ToString(),
                MimeType = "NewMimeType",
                PictureName = "NewPic",
                SketchJson = "NewSketch",
                PictureData = Encoding.ASCII.GetBytes("NewPic")
            };

            entity = new Models.Buildings.BuildingAnomalyPicture
            {
                IdBuildingAnomaly = Guid.NewGuid(),
                Picture = new Picture
                {
                    MimeType = "OldMimeType",
                    Name = "OldName",
                    Data = Encoding.ASCII.GetBytes("OldPic"),
                    SketchJson = "OldSketch"
                }
            };
        }

        [Fact]
        public void IdParentIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idParent, entity.IdBuildingAnomaly);
        }
    }
}