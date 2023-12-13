using Microsoft.EntityFrameworkCore;
using SistemaAcademicoCoruja.Application;
using SistemaAcademicoCoruja.Domain;
using SistemaAcademicoCoruja.Repositories.Interfaces;

namespace SistemaAcademicoCoruja.Repositories
{
    public class DisciplinaRepositories : IDisciplinaRepositories
    {
        private readonly SistemaAcademicoCorujaDBContex _dbContext;
        public DisciplinaRepositories(SistemaAcademicoCorujaDBContex sistemaAcademicoCorujaDBContex)
        {
            _dbContext = sistemaAcademicoCorujaDBContex;
        }

        public async Task<DisciplinaDomain> BuscarPorId(int id)
        {
            return await _dbContext.Disciplinas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DisciplinaDomain>> BuscarTodasDisciplinas()
        {
            return await _dbContext.Disciplinas.ToListAsync();
        }

        public async Task<DisciplinaDomain> Adicionar(DisciplinaDomain disciplina)
        {
            await _dbContext.Disciplinas.AddAsync(disciplina);
            await _dbContext.SaveChangesAsync();

            return disciplina;
        }

        public async Task<DisciplinaDomain> Atualizar(DisciplinaDomain disciplina, int id)
        {
            DisciplinaDomain disciplinaPorId = await BuscarPorId(id);

            if (disciplinaPorId == null)
            {
                throw new Exception($"Disciplina com o ID: {id} não encontrada no Banco de dados");
            }

            disciplinaPorId.Id = id;
            disciplinaPorId.Nome = disciplina.Nome;
            disciplinaPorId.Sigla = disciplina.Sigla;
            disciplinaPorId.Credito = disciplina.Credito;
            disciplinaPorId.Periodo = disciplina.Periodo;

            _dbContext.Disciplinas.Update(disciplinaPorId);
            await _dbContext.SaveChangesAsync();

            return disciplinaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            DisciplinaDomain disciplinaPorId = await BuscarPorId(id);

            if(disciplinaPorId == null)
            {
                throw new Exception($"Disciplina com o ID: {id} não encontrada no Banco de dados");
            }

            _dbContext.Disciplinas.Remove(disciplinaPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }
   
    }
}
