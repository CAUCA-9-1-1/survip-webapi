using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using UtilisationCode = Survi.Prevention.ApiClient.DataTransferObjects.UtilisationCode;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class UtilisationCodeImportationConverter
        : BaseLocalizableEntityConverter<
            UtilisationCode,
            Models.Buildings.UtilisationCode,
            UtilisationCodeLocalization>
    {
        public UtilisationCodeImportationConverter(
            IManagementContext context,
            AbstractValidator<UtilisationCode> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            UtilisationCode importedObject,
            Models.Buildings.UtilisationCode entity)
        {
            entity.Cubf = importedObject.Cubf;
            entity.Scian = importedObject.Scian;
        }
    }
}