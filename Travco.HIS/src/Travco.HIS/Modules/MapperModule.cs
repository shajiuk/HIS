using Autofac;
using AutoMapper;
using Travco.HIS.Config;

namespace Travco.HIS.Modules
{
    public class MapperModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
            builder.Register(m =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutoMapperConfig>();
                });

                return config;
            }).As<MapperConfiguration>().SingleInstance();

            builder.Register(m => m.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            builder.Register(m => new Mapper(m.Resolve<MapperConfiguration>()))
                .As<IMapper>()
                .SingleInstance();
        }
    }
}