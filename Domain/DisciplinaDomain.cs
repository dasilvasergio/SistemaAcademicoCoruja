using SistemaAcademicoCoruja.Enum;

namespace SistemaAcademicoCoruja.Domain
{
    public class DisciplinaDomain
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Sigla { get; set; }

        public Credito Credito { get; set; }

        public PeriodoLetivo Periodo { get; set; }
    }
}
