
using Microsoft.EntityFrameworkCore;

namespace Hudelsis_P1_AP1.DAL
{

    public class Contexto : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Parcial.db");
        }
    }
}
