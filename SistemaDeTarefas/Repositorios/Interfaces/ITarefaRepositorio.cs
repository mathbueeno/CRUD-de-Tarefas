using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<Tarefa>> BuscarTodasTarefas();
        Task<Tarefa> BuscarPorId(int id);
        Task<Tarefa> Adicionar(Tarefa tarefa);
        Task<Tarefa> Atualizar(Tarefa tarefa, int id);
        Task<bool> Apagar(int id);

    }
}
