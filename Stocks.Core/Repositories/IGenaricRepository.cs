using Stocks.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Repositories
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        //Get All 

        Task<IEnumerable<T>> GetAllAsync();

        // Get by Id

        Task<T> GetByIdAsync(int Id);

        // Get by Symbol
        Task<T> GetBySymbolAsync(string symbol);



    }
}
