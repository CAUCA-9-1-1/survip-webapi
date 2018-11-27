using System;
using System.Text;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class BaseCustomFieldsCopierWithPictureTests
    {
        private readonly BuildingParticularRiskPicture imported;
        private readonly Models.Buildings.BuildingParticularRiskPicture entity;
        private readonly CustomFieldsWithPictureCopierMock copier;

        public BaseCustomFieldsCopierWithPictureTests()
        {
            copier = new CustomFieldsWithPictureCopierMock();
            var idParent = Guid.NewGuid();
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
                IdBuildingParticularRisk = idParent,
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
        public void PictureIsCreatedWhenMissing()
        {
            entity.Picture = null;
            copier.DuplicateFieldsValues(imported, entity);
            Assert.True(copier.HasCreatedPicture);
        }

        [Fact]
        public void PictureIsNotCreatedWhenNotNeeded()
        {
            entity.Picture = null;
            imported.PictureData = null;

            copier.DuplicateFieldsValues(imported, entity);
            Assert.False(copier.HasCreatedPicture);
        }

        [Fact]
        public void PictureIsNotCreatedWhenAlreadyExisting()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.False(copier.HasCreatedPicture);
        }

        [Fact]
        public void PictureNameIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(entity.Picture.Name, imported.PictureName);
        }

        [Fact]
        public void PictureMimeTypeIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(entity.Picture.MimeType, imported.MimeType);
        }

        [Fact]
        public void PictureSketchJsonIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(entity.Picture.SketchJson, imported.SketchJson);
        }

        [Fact]
        public void PictureDataIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(entity.Picture.Data, imported.PictureData);
        }
    }
}