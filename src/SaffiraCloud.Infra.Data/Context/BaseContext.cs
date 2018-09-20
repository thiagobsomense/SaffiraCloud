using Microsoft.EntityFrameworkCore;
using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.Infra.Data.Extensions;

namespace SaffiraCloud.Infra.Data.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<Pais> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=DB_SaffiraCloud;Uid=root;Pwd=368549");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
