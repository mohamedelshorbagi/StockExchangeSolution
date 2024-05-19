using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Core.Entites;
using Stocks.Core.Repositories;

namespace StockExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IGenaricRepository<Stock> _stocksRepo;

        public StocksController(IGenaricRepository<Stock> StocksRepo)
        {
            _stocksRepo = StocksRepo;
        }

        // Get All Stocks 

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var Stocks = await _stocksRepo.GetAllAsync();
            return Ok(Stocks);

        }

        // Get Stock By ID 

        [HttpGet("{Id}")]
        public async Task<ActionResult<Stock>> GetStock(int Id)
        {
            var Stock = await _stocksRepo.GetByIdAsync(Id);
            return Ok(Stock);

        }

    }
}
