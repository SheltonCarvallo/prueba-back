using Data.domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
  public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {

        }
        public TiendaDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=DESKTOP-REDKEOB;initial catalog= TiendaDB;user id= PortalApi;password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true");

        public DbSet<ProductoModel> Productos => Set<ProductoModel>();
    }
}
