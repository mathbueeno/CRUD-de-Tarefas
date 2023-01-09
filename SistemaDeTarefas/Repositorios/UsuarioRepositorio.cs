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
            await _DbContext.Usuarios.AddAsync(usuario);
            await _DbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"O usuário para o Id:{id} não foi encontrado no banco de dados");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _DbContext.Usuarios.Update(usuarioPorId);
             await _DbContext.SaveChangesAsync();

            return usuarioPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

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
