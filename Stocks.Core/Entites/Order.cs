using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Entites
{
    public class Order : BaseEntity
    {
        
        public string StockSymbol { get; set; } = null!;
        public string OrderType { get; set; } = null!; 
        public int Quantity { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;


    }
}
