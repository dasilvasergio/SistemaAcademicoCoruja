using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademicoCoruja.Domain;
using SistemaAcademicoCoruja.Repositories.Interfaces;

namespace SistemaAcademicoCoruja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositories _alunoRepositories;

        public AlunoController(IAlunoRepositories alunoRepositories)
        {
            _alunoRepositories = alunoRepositories;
        }


        [HttpGet]
        public async Task <ActionResult<List<AlunoDomain>>> BuscarTodosalunos()
        {
            List<AlunoDomain> Alunos = await _alunoRepositories.BuscarTodosAlunos();

            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDomain>> BuscarPorId(int id)
        {
            AlunoDomain Aluno = await _alunoRepositories.BuscarPorId(id);

            return Ok(Aluno);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoDomain>> Adicionar([FromBody] AlunoDomain alunoDomain)
        {
           AlunoDomain aluno = await _alunoRepositories.Adicionar(alunoDomain);

            return Ok(aluno);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoDomain>> Atualizar([FromBody] AlunoDomain alunoDomain, int id)
        {
            alunoDomain.Id = id;

            AlunoDomain aluno = await _alunoRepositories.Atualizar(alunoDomain, id);

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoDomain>> Deletar(int id)
        {
            bool apagado = await _alunoRepositories.Apagar(id);

            return Ok(apagado);
        }
    }
}
