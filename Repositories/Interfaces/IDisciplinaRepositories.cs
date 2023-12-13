using SistemaAcademicoCoruja.Domain;

namespace SistemaAcademicoCoruja.Repositories.Interfaces
{
    public interface IDisciplinaRepositories
    {
        //Criando uma função assincrona que retorna uma lista de alunos
        Task<List<DisciplinaDomain>> BuscarTodasDisciplinas();

        //Criando uma função assincrona que retorna um aluno
        Task<DisciplinaDomain> BuscarPorId(int id);

        //Criando uma função que adiciona um aluno
        Task<DisciplinaDomain> Adicionar(DisciplinaDomain disciplina);

        //Criando uma função que atualiza o aluno
        Task<DisciplinaDomain> Atualizar(DisciplinaDomain disciplina, int id);

        //criando uma função para deletar o aluno
        Task<bool> Apagar(int id);

    }
}
