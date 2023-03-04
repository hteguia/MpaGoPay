using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MpaGoPay.Domain.Entities;

namespace MpaGoPay.Infrastructure.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardRecharge> CardRecharges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            if (Database.ProviderName == "Microsoft.EntityFramework.Sqlite")
            {
                foreach (var entity in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entity.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                    var dateandtimepropertise = entity.ClrType.GetProperties()
                        .Where(t => t.PropertyType == typeof(DateTimeOffset));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entity.Name).Property(property.Name)
                            .HasConversion<double>();
                    }
                    foreach (var property in dateandtimepropertise)
                    {
                        modelBuilder.Entity(entity.Name).Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }
    }
}
