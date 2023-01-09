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

        public async Task<List<Tarefa>> BuscarTodosUsuarios()
        {
            return await _DbContext.Usuarios.ToListAsync();
        }

        public async Task<Tarefa> Adicionar(Tarefa tarefa)
        {
            await _DbContext.Usuarios.AddAsync(tarefa);
            await _DbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Usuario> Atualizar(Tarefa tarefa, int id)
        {
            Tarefa usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"O usuário para o Id:{id} não foi encontrado no banco de dados");
            }

            usuarioPorId.Nome = tarefa.Nome;
            usuarioPorId.Email = tarefa.Email;

            _DbContext.Usuarios.Update(usuarioPorId);
             await _DbContext.SaveChangesAsync();

            return usuarioPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            Tarefa usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário para o Id:{id} não foi encontrado no banco de dados");
            }

            _DbContext.Usuarios.Remove(usuarioPorId);
             await  _DbContext.SaveChangesAsync();
            return true;

        }

        
        
    }
}
