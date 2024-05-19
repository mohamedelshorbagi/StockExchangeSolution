using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocks.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Repository.Data.Confguration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.StockSymbol).IsRequired().HasMaxLength(10);
            builder.Property(o => o.OrderType).IsRequired().HasMaxLength(10);
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.CreationTime).IsRequired();
        }
    }
}
