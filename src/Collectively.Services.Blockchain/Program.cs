using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Collectively.Common.Host;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Collectively.Services.Blockchain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceHost
                .Create<Startup>(args: args)
                .Build()
                .Run();

            //BuildWebHost(args).Run();
        }

        // public static IWebHost BuildWebHost(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>()
        //         .UseConfiguration(new ConfigurationBuilder()
        //             .AddEnvironmentVariables()
        //             .AddCommandLine(args)
        //             .Build())
        //         .Build();
    }
}
