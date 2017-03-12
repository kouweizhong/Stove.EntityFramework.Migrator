﻿using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.EntityFramework;

namespace Stove.Migrator.Executer
{
    public static class StoveMigratorRegistrationExtensions
    {
        public static IIocBuilder UseStoveMigrator(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()))
                          .UseStoveEntityFramework()
                          .UseStoveDbContextEfTransactionStrategy()
                          .UseStoveTypedConnectionStringResolver();
        }

        public static IIocBuilder UseStoveDbContextMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbContextMigrationStrategy>(); });
        }

        public static IIocBuilder UseStoveDbUpMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbUpMigrationStrategy>(); });
        }

        public static IIocBuilder UseStoveAllMigrationStrategies(this IIocBuilder builder)
        {
            return builder.RegisterServices(r =>
            {
                r.Register<IMigrationStrategy, DbContextMigrationStrategy>();
                r.Register<IMigrationStrategy, DbUpMigrationStrategy>();
            });
        }
    }
}