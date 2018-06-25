using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Travco.Data.Common;

namespace Travco.HIS.Api.Modules
{
    public class SearchApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(p => new SearchServiceClient(
                p.Resolve<IOptions<SearchOptions>>(),
                new HttpClient(),
                p.Resolve<IAuthorisationSettings>()
            ))
            .As<ISearchServiceClient>()
            .SingleInstance();

            builder.Register(p => new HISExportClient(
                p.Resolve<IOptions<HISExportOptions>>(),
                p.Resolve<ILogger<HISExportClient>>(),
                new HttpClient()
            ))
            .As<IHISExportClient>()
            .SingleInstance();

        }
    }
}