using Microsoft.EntityFrameworkCore;
using RicckyStore.Models;

namespace RicckyStore.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<Produits> Produits { get; set; }
    }
}
