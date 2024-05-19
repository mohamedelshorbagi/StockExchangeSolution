using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Core.Entites;
using Stocks.Core.Repositories;

namespace StockExchange.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockHistoryController : ControllerBase
    {
        private readonly IGenaricRepository<StockHistory> _stockHistoryRepo;

        public StockHistoryController(IGenaricRepository<StockHistory> stockHistoryRepo)
        {
            _stockHistoryRepo = stockHistoryRepo;
        }

        [HttpGet("{symbol}/history")]
        public async Task<ActionResult<StockHistory>> GetStockHistory(string symbol)
        {
            var StockHistory =  await _stockHistoryRepo.GetBySymbolAsync(symbol);
            return Ok(StockHistory);

        }

    }
}
