using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Entites
{
    public class StockHistory : BaseEntity
    {
       
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        public string symbol { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
