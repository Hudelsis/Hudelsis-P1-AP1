
using Microsoft.EntityFrameworkCore;
using Hudelsis_P1_AP1.Entidades;

namespace Hudelsis_P1_AP1.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Ciudad> Ciudad {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Parcial.db");
        }
    }
}
