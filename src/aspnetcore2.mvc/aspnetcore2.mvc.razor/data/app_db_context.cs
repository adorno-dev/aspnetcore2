using Microsoft.EntityFrameworkCore;
using Razor.Pages.Models;

namespace Razor.Pages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}