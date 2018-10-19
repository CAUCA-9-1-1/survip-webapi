using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public abstract class BaseCrudService<T> : BaseService
		where T : BaseModel, new()
	{
		
		protected BaseCrudService(ManagementContext context) 
			: base(context)
		{
		}

		public virtual Guid AddOrUpdate(T entity)
		{
			var isExistRecord = Context.Set<T>().Any(c => c.Id == entity.Id);
			
			entity.LastModifiedOn = DateTime.Now;
			if (isExistRecord){
				entity.IdWebUserLastModifiedBy = idUserModified;
				Context.Set<T>().Update(entity);
			}
			else
				Context.Set<T>().Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.Set<T>().Find(id);

			if (entity == null)
			{
				return false;
			}

			entity.IsActive = false;
			Context.SaveChanges();
			
			return true;
		}

		public virtual bool RemoveRange(List<Guid> ids)
		{
			ids.ForEach(id =>
			{
				var entity = new T {Id = id};
				Context.Set<T>().Attach(entity);
				entity.IsActive = false;
			});
			Context.SaveChanges();
			return true;
		}
		
		public virtual T Get(Guid id)
		{
			return Context.Set<T>().Find(id);
		}

		public virtual List<T> GetList()
		{
			return Context.Set<T>().ToList();
		}

		public T PartialCopyTo(Guid originalId, JObject json)
		{
			var replaceEntity = json.ToObject<T>();
			var originalEntity = Get(originalId);

			if (originalEntity == null)
			{
				return null;
			}

			foreach (var item in json)
			{
				var propertyName = item.Key.First().ToString().ToUpper() + String.Join("", item.Key.Skip(1));
				var propertyValue = replaceEntity.GetType().GetProperty(propertyName).GetValue(replaceEntity, null);

				originalEntity.GetType().GetProperty(propertyName).SetValue(originalEntity, propertyValue, null);
			}
			
			return originalEntity;
		}
	}
}