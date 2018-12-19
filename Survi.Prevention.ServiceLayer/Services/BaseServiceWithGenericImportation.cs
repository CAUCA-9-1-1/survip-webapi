using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public abstract class BaseServiceWithGenericImportation : BaseService
    {
        protected readonly List<object> Converters = new List<object>();

        protected BaseServiceWithGenericImportation(IManagementContext context) : base(context)
        {
        }

        public List<ImportationResult> Import<TEntity, TImportedEntity>(List<TImportedEntity> inputs)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            Stopwatch watch = Stopwatch.StartNew();

            var resultList = new List<(ImportationResult result, TEntity entity)>();
            foreach (var input in inputs)
                resultList.Add(ImportInput<TEntity, TImportedEntity>(input));

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

        protected (ImportationResult result, TEntity entity) ImportInput<TEntity, TImportedEntity>(TImportedEntity input)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            var result = GetImportationResult<TEntity, TImportedEntity>(input);

            if (result.result.IsValid)
                result.result.HasBeenImported = true;

            return result;
        }

        protected (ImportationResult result, TEntity entity) GetImportationResult<TEntity, TImportedEntity>(TImportedEntity input)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            var converter = Converters.OfType<IEntityConverter<TImportedEntity, TEntity>>().First();
            var conversionResult = converter.Convert(input);
            return (new ImportationResult
            {
                IdEntity = input.Id,
                EntityName = typeof(TImportedEntity).Name,
                Messages = conversionResult.ValidationErrors
            }, conversionResult.Result);
        }
    }
}
