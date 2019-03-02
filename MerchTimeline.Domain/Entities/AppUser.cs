using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchTimeline.Domain.Entities
{
    public class AppUser
    {
        public long Id { get; set; }

        public string Username { get; set; }
        public string AuthToken { get; set; }

        public ICollection<MerchSlot> MerchSlots { get; set; }
        public ICollection<MerchItem> MerchItems { get; set; }
        

        class Config : IEntityTypeConfiguration<AppUser>
        {
            public void Configure(EntityTypeBuilder<AppUser> builder)
            {
                builder.HasMany(user => user.MerchSlots).WithOne(slot => slot.Owner)
                    .HasForeignKey(slot => slot.OwnerId);
                builder.HasMany(user => user.MerchItems).WithOne(item => item.Owner).HasForeignKey(item => item.OwnerId);
            }
        }
    }
}
