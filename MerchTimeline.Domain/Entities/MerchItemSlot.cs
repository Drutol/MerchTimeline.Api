using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchItemSlot
    {
        public long Id { get; set; }

        public MerchSlot MerchSlot { get; set; }
        public MerchItem MerchItem { get; set; }

        class Config : IEntityTypeConfiguration<MerchItemSlot>
        {
            public void Configure(EntityTypeBuilder<MerchItemSlot> builder)
            {
                builder.HasOne(itemSlot => itemSlot.MerchItem).WithMany(item => item.MerchSlots);
                builder.HasOne(itemSlot => itemSlot.MerchSlot).WithMany(slot => slot.MerchItems);
            }
        }
    }
}
