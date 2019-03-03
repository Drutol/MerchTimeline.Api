using System;
using System.Collections.Generic;
using System.Text;

namespace MerchTimeline.Domain.Models
{
    public class TimelineSlot
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public List<TimelineEntry> TimelineEntries { get; set; }
    }
}
