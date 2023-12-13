using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaAcademicoCoruja.Domain;

namespace SistemaAcademicoCoruja.Application.Map
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoDomain>
    {
        public void Configure(EntityTypeBuilder<AlunoDomain> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
