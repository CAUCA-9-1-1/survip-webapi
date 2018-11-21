using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public class EntityLocalizationConverter<TOut, TLocalization>
        where TLocalization : BaseLocalization, new()
        where TOut : BaseLocalizableImportedModel<TLocalization>, new()
    {
        public List<TLocalization> Convert(
            ICollection<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations,
            TOut entity)
        {
            List<TLocalization> newLocalizations = new List<TLocalization>();
            importedLocalizations.ToList()
                .ForEach(localization => newLocalizations.Add(ImportLocalization(localization, entity)));

            return newLocalizations;
        }

        protected virtual TLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, TOut entity)
        {
            TLocalization existingLocalization =
                entity.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
            if (existingLocalization != null)
                return UpdateLocalization(importedLoc, existingLocalization, entity.IsActive);
            return CreateLocalization(importedLoc, entity.Id, entity.IsActive);
        }

        protected virtual TLocalization UpdateLocalization(
            ApiClient.DataTransferObjects.Base.Localization importedLoc,
            TLocalization existingLocalization, bool isActive)
        {
            existingLocalization.Name = importedLoc.Name;
            existingLocalization.IsActive = isActive;
            CopyCustomLocalizationFields(importedLoc, existingLocalization);
            return existingLocalization;
        }

        protected virtual void CopyCustomLocalizationFields(
            ApiClient.DataTransferObjects.Base.Localization importedLoc,
            TLocalization existingLocalization)
        {
        }

        protected virtual TLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
        {
            var newLocalization = new TLocalization { IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name, IsActive = isActive };
            CopyCustomLocalizationFields(importedLoc, newLocalization);
            return newLocalization;
        }
    }
}