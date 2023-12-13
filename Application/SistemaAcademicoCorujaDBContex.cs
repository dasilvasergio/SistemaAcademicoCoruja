using Microsoft.EntityFrameworkCore;
using SistemaAcademicoCoruja.Application.Map;
using SistemaAcademicoCoruja.Domain;

namespace SistemaAcademicoCoruja.Application
{
    public class SistemaAcademicoCorujaDBContex : DbContext
    {
        //Criando um construtor
        public SistemaAcademicoCorujaDBContex(DbContextOptions<SistemaAcademicoCorujaDBContex> options
            ) : base( options )
        { 
        }

        //Criando os DBset(s)
        public DbSet<AlunoDomain> Alunos { get; set; }

        public DbSet<DisciplinaDomain> Disciplinas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap()); 
            base.OnModelCreating(modelBuilder);
        }

    }
}
