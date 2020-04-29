using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using ESoftPlus.Api.Services;
using ESoftPlus.Common;
using ESoftPlus.Common.Authentication;
using ESoftPlus.Common.Consul;
using ESoftPlus.Common.Dispatchers;
using ESoftPlus.Common.Jaeger;
using ESoftPlus.Common.Mvc;
using ESoftPlus.Common.RabbitMq;
using ESoftPlus.Common.Redis;
using ESoftPlus.Common.RestEase;
using ESoftPlus.Common.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ESoftPlus.Api
{
    public class Startup
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddConsul();
            services.AddJwt();
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddRedis();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithExposedHeaders(Headers));
            });
            services.RegisterServiceForwarder<IOperationsService>("operations-service");
            services.RegisterServiceForwarder<ICountriesService>("countries-service");
            services.RegisterServiceForwarder<ICitiesService>("cities-service");
            services.RegisterServiceForwarder<ICompaniesService>("companies-service");
            services.RegisterServiceForwarder<IFieldsService>("fields-service");
            services.RegisterServiceForwarder<IDevicesService>("devices-service");
            services.RegisterServiceForwarder<IIndustrialProtocolsService>("industrialprotocols-service");
            services.RegisterServiceForwarder<ITagsService>("tags-service");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq();

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}