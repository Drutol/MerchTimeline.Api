using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class MerchType : EntityBase
    {
        public string Name { get; set; }
        public MerchKind Kind { get; set; }

        public ICollection<MerchItem> MerchItems { get; set; }

        class Config : IEntityTypeConfiguration<MerchType>
        {
            public void Configure(EntityTypeBuilder<MerchType> builder)
            {
                builder
                    .HasMany(type => type.MerchItems)
                    .WithOne(item => item.ItemType)
                    .HasForeignKey(item => item.ItemTypeId);
            }
        }
    }
}
