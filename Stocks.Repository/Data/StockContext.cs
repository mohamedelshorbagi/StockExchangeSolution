using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocks.Core.Entites;

namespace Stocks.Repository.Data
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options):base(options) 
        {
            
        }
        public DbSet <Stock> Stock { get; set; }
        public DbSet<StockHistory> StockHistory { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}
 