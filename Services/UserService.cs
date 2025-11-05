using SQLite;
using MotoAPP.Models;

namespace MotoAPP.Services
{
    public class UserService
    {
        private SQLiteConnection _connection;
        public UserService()
        {
            DataBaseService dataBaseService = new DataBaseService();

            _connection = dataBaseService.GetConexao();

            _connection.CreateTable<Usuario>();
        }

        public Usuario ValidarLogin(string username, string senha)
        {
            // Procura por um usuário com o mesmo username
            var usuario = _connection.Table<Usuario>()
                                     .Where(u => u.Username == username)
                                     .FirstOrDefault();

            // Se encontrou um usuário...
            if (usuario != null)
            {
                // ...verifica se a senha corresponde.
                if (usuario.Senha == senha)
                {
                    // Se a senha estiver correta, retorna o objeto do usuário
                    return usuario;
                }
            }

            // Se o usuário não for encontrado ou a senha estiver incorreta,
            // retorna null
            return null;
        }

        public Usuario UsuarioLogado(string username, string senha)
        {
            // Procura por um usuário com o mesmo username
            var usuario = _connection.Table<Usuario>()
                                     .Where(u => u.Username == username)
                                     .FirstOrDefault();

            // Se encontrou um usuário...
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }


        // Consultas do Banco

        public bool Insert(Usuario value)
        {
            return
                _connection.Insert(value) > 0;
        }

        public bool Update(Usuario value)
        {
            return _connection.Update(value) > 0;
        }
            
        public bool Delete(Usuario value)
        {
            return _connection.Delete(value) > 0;
        }

        public List<Usuario> GetAll()
        {
            return 
                _connection.Table<Usuario>().ToList();
        }

        public Usuario GetById(int value)
        {
            return
                _connection.Find<Usuario>(value);
        }

        public List<Usuario> GetByNome(string nome)
        {
            return
                _connection.Table<Usuario>().
                Where(x => x.Username.Contains(nome)).ToList();
        }

    }
}
