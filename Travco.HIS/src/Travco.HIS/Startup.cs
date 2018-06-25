using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Travco.Configuration;
using Travco.Data.Common.Couchbase;
using Travco.Data.Common.NEST;
using Travco.Data.EventStore;
using Travco.Framework.RestClient;
using Travco.HIS.Api;
using Travco.HIS.Model;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Travco.HIS
{
    public class Startup
	{
		private readonly IHostingEnvironment _env;
		private IContainer _container;

        public IConfiguration Configuration { get; set; }

		public Startup(IHostingEnvironment env, IConfiguration configuration)
		{

			Configuration = configuration;
			_env = env;
		}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Switch to disable telemetry. Defaults to enabled, if the key is missing from the config file
            TelemetryConfiguration.Active.DisableTelemetry = Convert.ToBoolean(Configuration["telemetry:disabled"]);

            services.AddAuthorization();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    build =>
                    {
                        build
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            services.Configure<XMLConfigOptions>(options =>
            {
                options.DMGEndpoint = Configuration["HIS:DMG:endpoint"];
                options.Agent = Configuration["HIS:DMG:agent"];
                options.Password = Configuration["HIS:DMG:password"];
                options.CMSConnection = Configuration["HIS:CMS:connectionstring"];
            });
            services.Configure<HISExportOptions>(options =>
            {
                options.Uri = Configuration["HIS:export:uri"];
                options.Username = Configuration["HIS:export:username"];
                options.Password = Configuration["HIS:export:password"];
                options.ConnectionString = Configuration["HIS:export:connectionstring"];
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                //.AddIdentityServerAuthentication(options =>
                //{
                //    options.Authority = Configuration["authorisation:tokenserver:endpoint"];
                //    options.RequireHttpsMetadata = false;
                //    options.EnableCaching = false;
                //    options.ApiName = Configuration["authorisation:scope"];
                //    options.ApiSecret = Configuration["authorisation:secret"];
                //    options.SupportedTokens = SupportedTokens.Both;
                //});
                .AddFakeAuthentication();

            // Create the autofac container
            var builder = new ContainerBuilder()
                .AddDataCommonNest()
                .AddSearchApi();

            builder.RegisterInstance(Configuration).As<IConfiguration>();
            builder.RegisterModule<Modules.MapperModule>();
            builder.RegisterModule<Modules.SearchModule>();

            //Registered here as its
            builder.Populate(services);
            _container = builder.Build();

            return _container.Resolve<IServiceProvider>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory, ILogger<Startup> logger)
		{
            logger.LogInformation("started");

            RestExtensions.Logger = loggerfactory.CreateLogger(nameof(RestExtensions));

            app.UseAuthentication();

            app.UseCors("AllowAllOrigins")
                .UseStaticFiles()
                .UseSimpleHealthCheck()
                .Use(async (context, next) =>
                {
                    // If it's a POST request with no ContentType then assume it's XML and set it accordingly 
                    // for further up the chain so we don't 415 the request. THANKS OTA - TM20180521
                    if (context.Request.Method == "POST" && context.Request.ContentType == null)
                        context.Request.ContentType = "application/xml";
                    await next.Invoke();
                })
				.UseMvc(routes =>
				{
					routes.MapRoute(
						name: "default",
						template: "api/{controller}/{action}/{id?}",
						defaults: new { controller = "Search", action = "Search" });
				});

            loggerfactory.AddFile(Configuration["HIS:DMG:logfile"]);
		}
    }

    static class FakeAuthentication
    {
        public static AuthenticationBuilder AddFakeAuthentication(this AuthenticationBuilder builder)
        {
            builder.AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>(IdentityServerAuthenticationDefaults.AuthenticationScheme, options => { });
            return builder;
        }
    }

    public class FakeAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FakeAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory, 
            UrlEncoder urlEncoder,
            ISystemClock clock
        ) : base(options, loggerFactory, urlEncoder, clock)
        {

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var identity = new ClaimsIdentity("Dummy");
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                IdentityServerAuthenticationDefaults.AuthenticationScheme
            );
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }

}
