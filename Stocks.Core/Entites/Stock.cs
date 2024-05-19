using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Entites
{
    public class Stock : BaseEntity
    {
      
        public string Symbol { get; set; } = null!;
        public decimal CurrentPrice { get; set; }
        public DateTime Timestamp { get; set; }

        public ICollection<StockHistory> StockHistory { get; set; } = new List<StockHistory>();



    }
}
