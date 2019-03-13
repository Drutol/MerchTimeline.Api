using System;
using System.Collections.Generic;
using System.Text;

namespace MerchTimeline.Domain.Entities
{
    public interface IEntityWithOwner 
    {
        long OwnerId { get; }
    }
}
