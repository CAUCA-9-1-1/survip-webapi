using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.DataLayer.Mapping.Base
{
  public static class ModelBuilderExtensions
  {
    private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
    {
      return assembly.GetTypes()
        .Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => IntrospectionExtensions.GetTypeInfo(y).IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
    }

    public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
    {
      var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));
      foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
      {
        config.Map(modelBuilder);
      }
    }
  }
}
