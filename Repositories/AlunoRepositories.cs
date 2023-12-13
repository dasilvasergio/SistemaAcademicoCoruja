using Microsoft.EntityFrameworkCore;
using SistemaAcademicoCoruja.Application;
using SistemaAcademicoCoruja.Domain;
using SistemaAcademicoCoruja.Repositories.Interfaces;

namespace SistemaAcademicoCoruja.Repositories
{
    public class AlunoRepositories : IAlunoRepositories
    {
        private readonly SistemaAcademicoCorujaDBContex _dbContex;
        //Criando um Construtor
        public AlunoRepositories(SistemaAcademicoCorujaDBContex sistemaAcademicoCorujaDBContex)
        {
            _dbContex = sistemaAcademicoCorujaDBContex;
        }

        public async Task<AlunoDomain> BuscarPorId(int id)
        {
            return await _dbContex.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AlunoDomain>> BuscarTodosAlunos()
        {
            return await _dbContex.Alunos.ToListAsync();
        }

        public async Task<AlunoDomain> Adicionar(AlunoDomain aluno)
        {
           await _dbContex.Alunos.AddAsync(aluno);
           await _dbContex.SaveChangesAsync();

            return aluno;
            
        }

        public async Task<AlunoDomain> Atualizar(AlunoDomain aluno, int id)
        {
            AlunoDomain alunoPorId = await BuscarPorId(id);

            if(alunoPorId == null)
            {
                throw new Exception($"Aluno de ID: {id} não foi encontrado na base de dados.");
            }

            alunoPorId.Id = id;
            alunoPorId.Nome = aluno.Nome;
            alunoPorId.Endereco = aluno.Endereco;
            alunoPorId.Cpf = aluno.Cpf;
            alunoPorId.Email = aluno.Email;

            _dbContex.Alunos.Update(alunoPorId);
            await _dbContex.SaveChangesAsync();

            return alunoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AlunoDomain alunoPorId = await BuscarPorId(id);

            if (alunoPorId == null)
            {
                throw new Exception($"Aluno de ID: {id} não foi encontrado na base de dados.");
            }

            _dbContex.Alunos.Remove(alunoPorId);
           await _dbContex.SaveChangesAsync();

            return true;


        }

        

        
    }
}
