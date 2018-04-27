using Autofac;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;
using Serilog;
using RawRabbit.Configuration;
using Collectively.Messages.Commands;
using Collectively.Messages.Events;
using Collectively.Common.Extensions;
using Collectively.Common.Mongo;
using Collectively.Common.NancyFx;
using System.Reflection;
using Collectively.Common.Exceptionless;
using Collectively.Common.RabbitMq;
using Collectively.Common.Security;
using Collectively.Common.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using Collectively.Services.Blockchain.Services;
using Collectively.Services.Blockchain.Services.BlockCypher;
using Collectively.Services.Blockchain.Services.BlokchainInfo;
using Collectively.Services.Blockchain.Services.Mappers;
using Collectively.Services.Blockchain.Services.BlokchainInfo.Mappers;
using Info.Blockchain.API.Models;

namespace Collectively.Services.Blockchain.Framework
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private static readonly ILogger Logger = Log.Logger;
        private readonly IConfiguration _configuration;
        private IServiceCollection _services;

        public Bootstrapper(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }   

        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            base.ConfigureApplicationContainer(container);
            container.Update(builder =>
            {
                builder.Populate(_services);
                builder.RegisterType<CustomJsonSerializer>().As<JsonSerializer>().SingleInstance();
                builder.RegisterInstance(_configuration.GetSettings<JwtTokenSettings>()).SingleInstance();
                builder.RegisterType<BlokchainInfoService>().As<IBlokchainInfoService>().InstancePerLifetimeScope();
                builder.RegisterType<BlockCypherService>().As<IBlockCypherService>().InstancePerLifetimeScope();
                builder.RegisterType<IBlockCypherService>().As<IBlockchainService>().InstancePerLifetimeScope();
                builder.RegisterType<BlockchainInfoTransactionMapper>().As<ITransactionMapper<Transaction>>().SingleInstance();
                builder.RegisterType<BlockchainInfoAddressMapper>().As<IAddressMapper<Address>>().SingleInstance();
                SecurityContainer.Register(builder, _configuration);
            });
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            pipelines.SetupTokenAuthentication(container.Resolve<IJwtTokenHandler>());
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            pipelines.AfterRequest += (ctx) =>
            {
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization, Origin, X-Requested-With, Content-Type, Accept");
            };
            Logger.Information("Collectively.Services.Blockchain API has started.");
        }
    }
}