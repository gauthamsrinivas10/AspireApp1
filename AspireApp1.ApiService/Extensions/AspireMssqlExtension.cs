using AspireApp1.ApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Extensions
{
    public static class AspireMssqlExtension
    {
        public static void MapMssqlAspireEndpoint(this WebApplication app)
        {
            app.MapGet("/mssql", async (MssqlDbContext mssqlDbContext) =>
            {
                await mssqlDbContext.Customers.AddAsync(new Customer()
                {
                    Title = "test@gmail.com",
                    Description = "gauth"
                });
                int rows = await mssqlDbContext.SaveChangesAsync();
                if (rows > 0)
                {
                    return await mssqlDbContext.Customers.FirstOrDefaultAsync();
                }
                else
                {
                    return null;
                }
            });
        }
    }

    internal class MssqlDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
    }
}
