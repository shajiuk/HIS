using Autofac;
using Travco.HIS.Api.Modules;

namespace Travco.HIS.Api
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddSearchApi(this ContainerBuilder self)
        {
            self.RegisterModule<SearchApiModule>();
            return self;
        }
    }
}
