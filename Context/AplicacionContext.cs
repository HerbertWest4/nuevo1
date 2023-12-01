using Microsoft.EntityFrameworkCore;
using NesHer.Models;

namespace NesHer.Context
{
    public class AplicacionContext : DbContext 
    {
        public AplicacionContext (DbContextOptions<AplicacionContext> options)
            : base (options)
        {
          
        } 
        public DbSet <Botella> Botella { get; set; }
        public DbSet<Contenido> Contenido { get; set; }

    }
}
