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
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Symbol).IsRequired().HasMaxLength(10);
            builder.Property(s => s.CurrentPrice).HasColumnType<decimal>("18,5");
            builder.Property(s => s.Timestamp).IsRequired();
        }
    }
}
