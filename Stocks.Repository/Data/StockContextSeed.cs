using Stocks.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stocks.Repository.Data
{
    public class StockContextSeed
    {
        public static async Task SeedAsync(StockContext dbContext) 
        {

            #region Stock DataSeed

            if (!dbContext.Stock.Any())
            {
                var StockData = File.ReadAllText("../Stocks.Repository/Data/DataSeed/Stock.json");
                var Stocks = JsonSerializer.Deserialize<List<Stock>>(StockData);

                if (Stocks?.Count < 0)
                {

                    foreach (var Stock in Stocks)
                    {
                        await dbContext.Set<Stock>().AddAsync(Stock);

                    }

                    await dbContext.SaveChangesAsync();
                }

            }

            #endregion
            #region StocksHistory DataSeed


         
                var StockHistoryData = File.ReadAllText("../Stocks.Repository/Data/DataSeed/StockHistory.json");
                var StockHistory = JsonSerializer.Deserialize<List<StockHistory>>(StockHistoryData);

                if (StockHistory?.Count < 0)
                {

                    foreach (var OneStockHistory in StockHistory)
                    {
                        await dbContext.Set<StockHistory>().AddAsync(OneStockHistory);

                    }

                    await dbContext.SaveChangesAsync();
                }

         

            #endregion
            #region Order DataSeed

            if (!dbContext.Order.Any())
            {
                var OrderData = File.ReadAllText("../Stocks.Repository/Data/DataSeed/Order.json");
                var Orders = JsonSerializer.Deserialize<List<Order>>(OrderData);

                if (Orders?.Count < 0)
                {

                    foreach (var order in Orders)
                    {
                        await dbContext.Set<Order>().AddAsync(order);

                    }

                    await dbContext.SaveChangesAsync();
                }
            }


            #endregion


        }
    }
}
