﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.ServiceLayer.Tests.Mocks
{
    public class BaseContextMock: Mock<IManagementContext>
    {
	    internal Mock<DbSet<T>> GetMockDbSet<T>(ICollection<T> entities) where T : class
	    {
		    var mockSet = new Mock<DbSet<T>>();
		    mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
		    mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
		    mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
		    mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
		    mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(entities.Add);
		    return mockSet;
	    }
    }
}
