using Microsoft.EntityFrameworkCore;

namespace Desafio_Unifenas.Models
{
    public class _DbContext : DbContext 
    {
        public _DbContext(DbContextOptions<_DbContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Aluno> alunos { get; set; } 
    }
}
