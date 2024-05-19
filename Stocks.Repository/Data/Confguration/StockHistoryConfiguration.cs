using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stocks.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Repository.Data.Confguration
{
    internal class StockHistoryConfiguration : IEntityTypeConfiguration<StockHistory>
    {
        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistory");

            builder.HasKey(sh => sh.Id);
            builder.Property(sh => sh.Price).HasColumnType("decimal(18,5)");
            builder.Property(sh => sh.Timestamp).IsRequired();
            builder.HasOne(sh => sh.Stock)
                   .WithMany(s => s.StockHistory)
                   .HasForeignKey(sh => sh.StockId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
