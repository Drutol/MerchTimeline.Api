using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Domain.Configuration;

namespace MerchTimeline.Interfaces
{
    public interface IConfigurationProvider
    {
        Secrets Secrets { get; }
    }
}
