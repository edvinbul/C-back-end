using Microsoft.EntityFrameworkCore;
using CarShop.Models;

namespace CarShop.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<CarRent> Rents { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {

        }

    }
}
