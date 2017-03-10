﻿using System.Reflection;

using Autofac.Extras.IocManager;

namespace Domain.Data.Migrator
{
    public static class DataMigratorRegistrationExtensions
    {
        public static IIocBuilder UseDataMigrator(this IIocBuilder builder)
        {
            return builder
                .RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()));
        }
    }
}