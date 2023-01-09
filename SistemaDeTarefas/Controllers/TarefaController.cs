using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        // Listar Todos
        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> BuscarTodosUsuarios()
        {
           List<Tarefa> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();

            return Ok(tarefas); 
        }

        // Listar apenas um
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tarefa>>> BuscarPorId(int id)
        {

            Tarefa tarefa = await _tarefaRepositorio.BuscarPorId(id);

            return Ok(tarefa);
        }

        //Cadastrar
        // From Body - Significa pelo corpo da requisição
        [HttpPost]
        public async Task<ActionResult<Tarefa>> Cadastrar([FromBody] Tarefa tarefaModel)
        {
           Tarefa tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        //Atualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefa>> Atualizar([FromBody] Tarefa tarefaModel, int id)
        {
            tarefaModel.Id = id; 
            Tarefa tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<Tarefa>> Deletar(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
