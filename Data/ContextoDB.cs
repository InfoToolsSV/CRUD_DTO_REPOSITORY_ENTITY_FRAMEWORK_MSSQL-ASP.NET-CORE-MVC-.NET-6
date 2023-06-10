using Microsoft.EntityFrameworkCore;
using RepositorioDTO_EF.Models;

namespace RepositorioDTO_EF.Data
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
            Productos = Set<Producto>();
        }

        public DbSet<Producto> Productos { get; set; }
    }
}