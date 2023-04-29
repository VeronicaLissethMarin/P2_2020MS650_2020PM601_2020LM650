using Microsoft.EntityFrameworkCore;
namespace P2_2020MS650_2020PM601_2020LM650.Models
{
    public class registroContext
    {

        public registroContext(registroContextOptions options) : base(options)
        {
        }

        public DbSet<departamento> departamento { get; set; }

        public DbSet<genero> genero { get; set; }

        public DbSet<reporte> reporte { get; set; }

    }
}
