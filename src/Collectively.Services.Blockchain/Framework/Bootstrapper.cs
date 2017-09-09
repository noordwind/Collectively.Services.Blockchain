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
using Collectively.Common.Nancy;
using System.Reflection;
using Collectively.Common.Exceptionless;
using Collectively.Common.RabbitMq;
using Collectively.Common.Security;
using Collectively.Common.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;

namespace Collectively.Services.Blockchain.Framework
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        //private static readonly ILogger Logger = Log.Logger;
        // private static IExceptionHandler _exceptionHandler;
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
                // builder.RegisterInstance(_configuration.GetSettings<ExceptionlessSettings>()).SingleInstance();
                // builder.RegisterType<ExceptionlessExceptionHandler>().As<IExceptionHandler>().SingleInstance();
                //SecurityContainer.Register(builder, _configuration);
            });
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            //pipelines.SetupTokenAuthentication(container.Resolve<IJwtTokenHandler>());
            // pipelines.OnError.AddItemToEndOfPipeline((ctx, ex) =>
            // {
            //     _exceptionHandler.Handle(ex, ctx.ToExceptionData(),
            //         "Request details", "Collectively", "Service", "Supervisor");

            //     return ctx.Response;
            // });
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // pipelines.AfterRequest += (ctx) =>
            // {
            //     ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //     ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization, Origin, X-Requested-With, Content-Type, Accept");
            // };
            // _exceptionHandler = container.Resolve<IExceptionHandler>();
            //Logger.Information("Collectively.Services.Supervisor API has started.");
        }
    }
}