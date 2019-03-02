using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchTimeline.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using IConfigurationProvider = MerchTimeline.Interfaces.IConfigurationProvider;

namespace MerchTimeline.Api.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public ConfigurationProvider(IConfiguration configuration)
        {
            Secrets = configuration.GetSection("Secrets").Get<Secrets>();
        }

        public Secrets Secrets { get; }
    }
}
