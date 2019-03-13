using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchSlot : EntityBase, IEntityWithOwner
    {
        public long OwnerId { get; set; }

        public string Name { get; set; }

        public AppUser Owner { get; set; }

        public ICollection<MerchItemUsagePeriod> UsagePeriods { get; set; }

        public class Dto
        {
            public long Id { get; set; }
            public string Name { get; set; }

            public Dto()
            {

            }

            public Dto(MerchSlot slot)
            {
                Id = slot.Id;
                Name = slot.Name;
            }
        }
    }
}
