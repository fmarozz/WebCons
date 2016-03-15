using System.Runtime.CompilerServices;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using WebCons.Data;

namespace WebCons.WebUI
{
    public static class NhibernateConfiguration
    {
        public static string stringaConnessione;
        public static ISessionFactory CreateSessionFactory()
        {
            var model = AutoMap.AssemblyOf<Movimenti>()
                .Where(x => x.BaseType == typeof(AnagraficaBase) || x == typeof(Movimenti))
                .Conventions.Add(ConventionBuilder.Id.Always(x=>x.GeneratedBy.Identity()))
                .Conventions.Add
        (

            ConventionBuilder.Reference.Always(x => x.Cascade.None()),

            PrimaryKey.Name.Is(o => "Id"),
            ForeignKey.EndsWith("Id"),
            DefaultLazy.Never(),
            DefaultCascade.All()).IgnoreBase<AnagraficaBase>();

            //model.WriteMappingsTo(@"c:\hbm");
            return Fluently.Configure()
                .Database(JetDriverConfiguration.Standard.ConnectionString(stringaConnessione))
                .Mappings(m =>
                    m.AutoMappings.Add(model)
       
        )
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            if (1!=1)
            new SchemaExport(config).Create(false,true);
            else
            new SchemaUpdate(config)
                     .Execute(false, true);
        }
    }
}