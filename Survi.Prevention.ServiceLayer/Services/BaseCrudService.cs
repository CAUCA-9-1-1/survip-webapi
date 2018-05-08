using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public abstract class BaseCrudService<T> : BaseService
		where T : BaseModel
	{
		protected BaseCrudService(ManagementContext context) 
			: base(context)
		{
		}

		public virtual Guid AddOrUpdate(T entity)
		{
			var isExistRecord = Context.Set<T>().Any(c => c.Id == entity.Id);
			
			if (isExistRecord)
				Context.Set<T>().Update(entity);
			else
				Context.Set<T>().Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.Set<T>().Find(id);
			entity.IsActive = false;
			Context.SaveChanges();

			return true;
		}

		public abstract T Get(Guid id);
		public abstract List<T> GetList();
	}
}