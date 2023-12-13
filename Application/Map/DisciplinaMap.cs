using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaAcademicoCoruja.Domain;

namespace SistemaAcademicoCoruja.Application.Map
{
    public class DisciplinaMap : IEntityTypeConfiguration<DisciplinaDomain>
    {
        public void Configure(EntityTypeBuilder<DisciplinaDomain> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sigla).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Credito).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Periodo).IsRequired().HasMaxLength(10);
        }
    }
}
