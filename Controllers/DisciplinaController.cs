using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademicoCoruja.Domain;
using SistemaAcademicoCoruja.Repositories.Interfaces;

namespace SistemaAcademicoCoruja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepositories _disciplinaRepositories;

        public DisciplinaController(IDisciplinaRepositories disciplinaRepositories)
        {
            _disciplinaRepositories = disciplinaRepositories;
        }
        [HttpGet]
        public async Task<ActionResult<List<DisciplinaDomain>>> BuscarTodasDisciplinas()
        {
            List<DisciplinaDomain> Disciplinas = await _disciplinaRepositories.BuscarTodasDisciplinas();
            
            return Ok(Disciplinas); //Retornando código 200
        }

        [HttpGet("{id}")] //Buscar Disciplina por ID
        public async Task<ActionResult<DisciplinaDomain>> BuscarPorId(int id)
        {
            DisciplinaDomain Disciplina = await _disciplinaRepositories.BuscarPorId(id);

            return Ok(Disciplina); //Retornando código 200
        }

        [HttpPost]
        public async Task<ActionResult<DisciplinaDomain>> Adicionar([FromBody]DisciplinaDomain Disciplina)
        {
            DisciplinaDomain disciplina = await _disciplinaRepositories.Adicionar(Disciplina);

            return Ok(disciplina);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DisciplinaDomain>> Atualizar([FromBody] DisciplinaDomain disciplinaDomain, int id)
        {
            disciplinaDomain.Id = id;

            DisciplinaDomain disciplina = await _disciplinaRepositories.Atualizar(disciplinaDomain, id);

            return Ok(disciplina);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DisciplinaDomain>> Apagar(int id)
        {
            bool apagado = await _disciplinaRepositories.Apagar(id);

            return Ok(apagado);
        }
    }
}
