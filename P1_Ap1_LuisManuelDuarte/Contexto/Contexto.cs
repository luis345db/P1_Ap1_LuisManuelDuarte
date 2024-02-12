using Microsoft.EntityFrameworkCore;
using P1_Ap1_LuisManuelDuarte.Models;
namespace P1_Ap1_LuisManuelDuarte.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> Options) : base(Options)
        {
        }

        public DbSet<Metas> Metas { get; set; }

    }
}
    
