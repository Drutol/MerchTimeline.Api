using System;
using System.Collections.Generic;
using System.Text;

namespace MerchTimeline.Domain.Models
{
    public class TimelineEntry
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
