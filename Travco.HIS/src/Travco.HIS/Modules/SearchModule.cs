using Autofac;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nest;
using System.Linq;
using System.Reflection;
using Travco.Data.Common;
using Travco.Data.Common.Commands;
using Travco.Data.Common.NEST;
using Travco.Helpers.HIS;
using Travco.HIS.Api;

namespace Travco.HIS.Modules
{
    public class SearchModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
		{
            builder.Register(p => new ElasticClient(p.Resolve<IOptions<ElasticsearchOptions>>().Value.Get())).As<IElasticClient>().SingleInstance();
            var assembly = Assembly.GetEntryAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuery<,>))
                && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommand<,>)).AsSelf();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IValidator<>)).SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(NestQuery<>)).AsSelf();

            builder.Register(m => new Exporter(
                    m.Resolve<IOptions<HISExportOptions>>(), 
                    m.Resolve<ILogger<Exporter>>(),
                    m.Resolve<IHISExportClient>()
                ))
                .As<Exporter>()
                .SingleInstance();

            //builder.RegisterType<ElasticsearchHealthCheck>().As<HealthCheck>().SingleInstance();
            //builder.RegisterType<MetricsProvider>().As<IMetricsProvider>().SingleInstance();
            //builder.RegisterType<Version>().As<HealthCheck>().SingleInstance();
            //builder.RegisterType<CouchbaseHealthCheck>().As<HealthCheck>().SingleInstance();
        }
    }
}