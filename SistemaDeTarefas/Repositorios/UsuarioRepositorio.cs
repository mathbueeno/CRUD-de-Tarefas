using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TarefasContext _DbContext;
        public UsuarioRepositorio(TarefasContext tarefasContext)
        {
            _DbContext = tarefasContext;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _DbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _DbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            _DbContext.Usuarios.Add(usuario);
            _DbContext.SaveChanges();

            return usuario;
        }

        public Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"O usuário para o Id:{id} não foi encontrado no banco de dados");
            }
        }


        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        
        
    }
}
