using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Travco.HIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            string environment = "Azure";
            if (args.Length > 1)
                environment = args[1];
            var basePath = Directory.GetCurrentDirectory();

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddCommandLine(args)
                .AddJsonFile(basePath + $"/App_Data/{environment}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseUrls(config["searchapi:listenuri"])
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
