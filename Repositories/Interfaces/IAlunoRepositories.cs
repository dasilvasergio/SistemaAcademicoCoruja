using SistemaAcademicoCoruja.Domain;

namespace SistemaAcademicoCoruja.Repositories.Interfaces
{
    public interface IAlunoRepositories
    {
        //Criando uma função assincrona que retorna uma lista de alunos
        Task<List<AlunoDomain>> BuscarTodosAlunos();

        //Criando uma função assincrona que retorna um aluno
        Task<AlunoDomain> BuscarPorId(int id);

        //Criando uma função que adiciona um aluno
        Task<AlunoDomain> Adicionar(AlunoDomain aluno);

        //Criando uma função que atualiza o aluno
        Task<AlunoDomain> Atualizar(AlunoDomain aluno, int id);

        //criando uma função para deletar o aluno
        Task<bool> Apagar(int id);



    }
}
