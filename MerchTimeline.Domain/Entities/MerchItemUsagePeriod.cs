using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchItemUsagePeriod : EntityBase, IEntityWithOwner
    { 
        public long OwnerId { get; set; }
        public long MerchItemId { get; set; }
        public MerchItem MerchItem { get; set; }

        public long MerchSlotId { get; set; }
        public MerchSlot MerchSlot { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        class Config : IEntityTypeConfiguration<MerchItemUsagePeriod>
        {
            public void Configure(EntityTypeBuilder<MerchItemUsagePeriod> builder)
            {
                builder.HasOne(period => period.MerchSlot)
                    .WithMany(slot => slot.UsagePeriods)
                    .HasForeignKey(period => period.MerchSlotId);
            }
        }
    }
}
