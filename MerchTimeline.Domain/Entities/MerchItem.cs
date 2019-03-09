using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchItem
    {
        public long Id { get; set; }

        public long OwnerId { get; set; }
        public long ItemTypeId { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public AppUser Owner { get; set; }
        public MerchType ItemType { get; set; }

        public ICollection<MerchItemUsagePeriod> UsagePeriods { get; set; } = new HashSet<MerchItemUsagePeriod>();
        public ICollection<MerchItemSlot> MerchSlots { get; set; } = new HashSet<MerchItemSlot>();


        public class Dto
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public MerchKind Kind { get; set; }
            public string ImageUrl { get; set; }

            public Dto()
            {

            }

            public Dto(MerchItem item)
            {
                Id = item.Id;
                Name = item.Name;
                Kind = item.ItemType.Kind;
                ImageUrl = item.ImageUrl;
            }
        }

        class Config : IEntityTypeConfiguration<MerchItem>
        {
            public void Configure(EntityTypeBuilder<MerchItem> builder)
            {
                builder
                    .HasMany(item => item.UsagePeriods)
                    .WithOne(period => period.MerchItem)
                    .HasForeignKey(period => period.MerchItemId);
            }
        }
    }
}
