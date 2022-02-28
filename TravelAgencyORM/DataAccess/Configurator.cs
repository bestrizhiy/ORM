namespace DataAccess
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    public static class Configurator
    {
        private static FluentConfiguration fluentConfiguration;

        public static ISessionFactory GetSessionFactory(
            Settings settings,
            Assembly assembly = null,
            bool showSql = false)
        {
            return GetConfiguration(settings, assembly ?? Assembly.GetExecutingAssembly(), showSql)
                .BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration(
            Settings settings,
            Assembly assembly,
            bool showSql = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(
                    x => x
                        .Server(settings.GetDatabaseServer())
                        .Database(settings.GetDatabaseName())
                        .TrustedConnection());

                if (showSql)
                {
                    databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
                }

                fluentConfiguration = Fluently.Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    .ExposeConfiguration(BuildSchema);
            }

            return fluentConfiguration;
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}
