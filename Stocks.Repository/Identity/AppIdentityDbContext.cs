using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stocks.Core.Entites.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stocks.Repository.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base (options)
        {
            
        } 




    }
}
