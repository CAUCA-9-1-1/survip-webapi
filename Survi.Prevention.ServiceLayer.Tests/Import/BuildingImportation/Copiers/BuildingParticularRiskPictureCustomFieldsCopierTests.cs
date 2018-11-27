using System;
using System.Text;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingParticularRiskPictureCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly BuildingParticularRiskPicture imported;
        private readonly Models.Buildings.BuildingParticularRiskPicture entity;
        private readonly BuildingParticularRiskPictureCustomFieldCopier copier;

        public BuildingParticularRiskPictureCustomFieldsCopierTests()
        {
            copier = new BuildingParticularRiskPictureCustomFieldCopier();
            idParent = Guid.NewGuid();
            imported = new BuildingParticularRiskPicture
            {
                IdBuildingParticularRisk = idParent.ToString(),
                MimeType = "NewMimeType",
                PictureName = "NewPic",
                SketchJson = "NewSketch",
                PictureData = Encoding.ASCII.GetBytes("NewPic")
            };

            entity = new Models.Buildings.BuildingParticularRiskPicture
            {
                IdBuildingParticularRisk = Guid.NewGuid(),
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
            Assert.Equal(idParent, entity.IdBuildingParticularRisk);
        }
    }
}