using Microsoft.EntityFrameworkCore;
using Stocks.Core.Entites;
using Stocks.Core.Repositories;
using Stocks.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StockContext _dbContext;

        public GenaricRepository(StockContext dbContex)
        {
            _dbContext = dbContex;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbContext.Set<T>().ToListAsync();
        

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T> GetBySymbolAsync(string symbol)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(s => s.GetType().GetProperty("Symbol").GetValue(s).ToString() == symbol);
        }

    }
}
