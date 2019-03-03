using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using MerchTimeline.Api.Middleware;
using MerchTimeline.DataAccess;
using MerchTimeline.DataAccess.Services;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Domain.Requests.Queries;
using MerchTimeline.Interfaces;
using MerchTimeline.Processing.Behaviours;
using MerchTimeline.Processing.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ConfigurationProvider = MerchTimeline.Api.Providers.ConfigurationProvider;
using IConfigurationProvider = MerchTimeline.Interfaces.IConfigurationProvider;

namespace MerchTimeline.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<TimelineDbContext>();
            services.AddSingleton<IConfigurationProvider, ConfigurationProvider>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            services.AddMediatR(Assembly.GetAssembly(typeof(GetMerchItemsQueryHandler)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseMiddleware<ExceptionFormattingMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
