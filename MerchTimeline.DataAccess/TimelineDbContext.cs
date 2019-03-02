using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchTimeline.DataAccess
{
    public class TimelineDbContext : DbContext
    {
        private readonly IConfigurationProvider _configurationProvider;

        public TimelineDbContext(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configurationProvider.Secrets.DatabaseConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(MerchItem)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
