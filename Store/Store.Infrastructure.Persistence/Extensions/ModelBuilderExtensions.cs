﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Store.Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                                              .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic &&
                                               typeof(BaseType).IsAssignableFrom(c));
            foreach (Type type in types)
                modelBuilder.Entity(type);
        }
    }
}
