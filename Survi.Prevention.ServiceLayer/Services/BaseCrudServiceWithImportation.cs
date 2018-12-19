using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public abstract class BaseCrudServiceWithImportation<TEntity, TImportedEntity> : BaseCrudService<TEntity>
        where TEntity : BaseImportedModel, new()
        where TImportedEntity : BaseTransferObject
    {
        protected IEntityConverter<TImportedEntity, TEntity> Converter;

        protected BaseCrudServiceWithImportation(
            IManagementContext context,
            IEntityConverter<TImportedEntity, TEntity> converter) 
            : base(context)
        {
            Converter = converter;
        }

        public List<ImportationResult> Import(List<TImportedEntity> inputs)
        {            
            Stopwatch watch = Stopwatch.StartNew();

            var resultList = new List<(ImportationResult result, TEntity entity)>();
            foreach (var input in inputs)
                resultList.Add(Import(input));            

            Stopwatch watchSave = Stopwatch.StartNew();

            Context.SaveChanges();

            watchSave.Stop();
            Console.WriteLine($"SaveChanges : {watchSave.Elapsed.TotalSeconds} seconds");

            watch.Stop();
            var timespan = watch.Elapsed;
            Console.WriteLine($"FromDatabase : {Metrics.GetEntitiyFromDatabase.TotalSeconds} seconds");
            Console.WriteLine($"ForeignKeys : {Metrics.GetRealForeignKeysTotalTime.TotalSeconds} seconds");
            Console.WriteLine($"CreateNew : {Metrics.CreateNew.TotalSeconds} seconds");
            Console.WriteLine($"{typeof(TEntity).Name} - elapsed : {timespan.Minutes:00}:{timespan.Seconds:00}:{timespan.Milliseconds / 10:00}");
            Metrics.Reset();

            return resultList.Select(result => result.Item1).ToList();
        }

        protected (ImportationResult result, TEntity entity) Import(TImportedEntity input)
        {
            var result = GetImportationResult(input);

            if (result.result.IsValid)
                result.result.HasBeenImported = true;

            return result;
        }

        protected (ImportationResult result, TEntity entity) GetImportationResult(TImportedEntity input)
        {
            var conversionResult = Converter.Convert(input);
            return (new ImportationResult
            {
                IdEntity = input.Id,
                EntityName = typeof(TImportedEntity).Name,
                Messages = conversionResult.ValidationErrors
            }, conversionResult.Result);
        }
    }
}