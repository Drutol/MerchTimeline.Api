using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchItemUsagePeriod
    {
        public long Id { get; set; }

        public long MerchItemId { get; set; }
        public MerchItem MerchItem { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }       
    }
}
