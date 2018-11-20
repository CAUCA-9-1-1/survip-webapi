﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public abstract class BaseLocalizableEntityConverter<TIn, TOut, TLocalization>
        : BaseEntityConverter<TIn, TOut>
        where TIn : BaseLocalizableTransferObject
        where TLocalization: BaseLocalization, new()
        where TOut : BaseLocalizableImportedModel<TLocalization>, new()
    {
        protected BaseLocalizableEntityConverter(
            IManagementContext context, 
            AbstractValidator<TIn> validator) 
            : base(context, validator)
        {}

        protected override void CopyImportedFieldsToEntity(TIn importedObject, TOut entity)
        {
            CopyLocalizationFields(importedObject, entity);
            base.CopyImportedFieldsToEntity(importedObject, entity);
        }

        protected virtual void CopyLocalizationFields(TIn importedObject, TOut entity)
        {
            entity.Localizations = TransferLocalizationsFromImported(importedObject.Localizations, entity);
        }

        public List<TLocalization> TransferLocalizationsFromImported(
            ICollection<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, 
            TOut entity)
        {
            List<TLocalization> newLocalizations = new List<TLocalization>();
            importedLocalizations.ToList()
                .ForEach(localization => newLocalizations.Add(ImportLocalization(localization, entity)));

            return newLocalizations;
        }

        public TLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, TOut entity)
        {
            TLocalization existingLocalization =
                entity.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
            if (existingLocalization != null)
                return UpdateLocalization(importedLoc, existingLocalization, entity.IsActive);
            return CreateLocalization(importedLoc, entity.Id, entity.IsActive);
        }

        public TLocalization UpdateLocalization(
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

        public TLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
        {
            return new TLocalization { IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name, IsActive = isActive };
        }

        protected override TOut GetEntityFromDatabase(string externalId)
        {
            return Context.Set<TOut>()
                .Include(entity => entity.Localizations)
                .FirstOrDefault(entity => entity.IdExtern == externalId);
        }
    }
}