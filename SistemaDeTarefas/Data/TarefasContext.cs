using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class TarefasContext : DbContext
    {
        // Método construtor
        public TarefasContext(DbContextOptions<TarefasContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
