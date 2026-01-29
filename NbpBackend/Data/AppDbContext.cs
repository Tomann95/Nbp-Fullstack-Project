using Microsoft.EntityFrameworkCore;
using NbpBackend.Models;

namespace NbpBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
    }
}
