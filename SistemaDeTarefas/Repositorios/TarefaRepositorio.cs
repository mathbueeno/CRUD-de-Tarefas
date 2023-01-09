using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TarefasContext _DbContext;
        public TarefaRepositorio(TarefasContext tarefasContext)
        {
            _DbContext = tarefasContext;
        }

        public async Task<Tarefa> BuscarPorId(int id)
        {
            return await _DbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tarefa>> BuscarTodasTarefas()
        {
            return await _DbContext.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> Adicionar(Tarefa tarefa)
        {
            await _DbContext.Tarefas.AddAsync(tarefa);
            await _DbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> Atualizar(Tarefa tarefa, int id)
        {
            Tarefa tarefaPorId = await BuscarPorId(id);
            
            if(tarefaPorId == null)
            {
                throw new Exception($"A tarefa para o Id:{id} não foi encontrado no banco de dados");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioTarefaId = tarefa.UsuarioTarefaId;

            _DbContext.Tarefas.Update(tarefaPorId);
             await _DbContext.SaveChangesAsync();

            return tarefaPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            Tarefa tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"A tarefa para o Id:{id} não foi encontrado no banco de dados");
            }

            _DbContext.Tarefas.Remove(tarefaPorId);
             await  _DbContext.SaveChangesAsync();
            return true;

        }

        
        
    }
}
