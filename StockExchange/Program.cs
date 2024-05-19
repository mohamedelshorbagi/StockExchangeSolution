
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockExchange.Extensions;
using Stocks.Core.Entites.identity;
using Stocks.Core.Repositories;
using Stocks.Repository;
using Stocks.Repository.Data;
using Stocks.Repository.Identity;

namespace StockExchange
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configer Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StockContext>(Option =>
            {
                Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
            });

            builder.Services.AddScoped(typeof(IGenaricRepository<>) , typeof(GenaricRepository<>));
            builder.Services.AddDbContext<AppIdentityDbContext>(options => { 
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });


            builder.Services.AddIdentityServices(); // Extension Method 


            #endregion

            var app = builder.Build();

            #region Update Database

            var Scope = app.Services.CreateScope();

            var Service = Scope.ServiceProvider;

            var LoggerFactory = Service.GetRequiredService<ILoggerFactory>();

            try 
            {

                var dbcontext = Service.GetRequiredService<StockContext>();

                await dbcontext.Database.MigrateAsync();
                await StockContextSeed.SeedAsync(dbcontext);

                var IdentityDbContext = Service.GetRequiredService<AppIdentityDbContext>();
                await IdentityDbContext.Database.MigrateAsync();
                var UserManager = Service.GetRequiredService<UserManager<AppUser>>();

                await AppIdentityDbContextSeed.SeedUserAsync(UserManager);
            }
            catch (Exception ex)
            { 

                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex , "Error While Migrate Tables to Database");
            }

            #endregion




            #region Configure HTTP Request pipeline
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
