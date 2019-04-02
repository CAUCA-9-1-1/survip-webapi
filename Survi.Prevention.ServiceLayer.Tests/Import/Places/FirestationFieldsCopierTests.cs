using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places.Copiers;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class FirestationFieldsCopierTests
    {
        private readonly FirestationFieldsCopier copier;
        private readonly Guid? idBuilding = Guid.NewGuid();
        private readonly Firestation imported;
        private readonly Models.FireSafetyDepartments.Firestation entity;

        public FirestationFieldsCopierTests()
        {
            copier = new FirestationFieldsCopier();

            imported = new Firestation
            {
                Email = "E",
                FaxNumber = "F",
                IdFireSafetyDepartment = idBuilding.ToString(),
                IdBuilding = idBuilding.ToString(),
                Name = "N",
                PhoneNumber = "P"
            };
            entity = new Models.FireSafetyDepartments.Firestation();
        }

        [Fact]
        public void EmailIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.Email, entity.Email);
        }

        [Fact]
        public void FaxNumberIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.FaxNumber, entity.FaxNumber);
        }

        [Fact]
        public void IdFireSafetyDepartmentIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.Name, entity.Name);
        }

        [Fact]
        public void IdBuildingIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idBuilding, entity.IdBuilding);
        }

        [Fact]
        public void NameIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.Name, entity.Name);
        }

        [Fact]
        public void PhoneNumberIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.PhoneNumber, entity.PhoneNumber);
        }
    }
}
