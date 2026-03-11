using Almoxarifado.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almoxarifado.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Item> Itens { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Item>().ToTable("item").HasKey(i => i.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
