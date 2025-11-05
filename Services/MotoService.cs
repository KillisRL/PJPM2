using MotoAPP.Models;
using SQLite;

namespace MotoAPP.Services
{
    public class MotoService
    {
        private SQLiteConnection _connection;
        public MotoService()
        {
            // Instanciar a classe de conexão
            DataBaseService dataBaseService = new DataBaseService();

            // Gerar a conexão com o DB
            _connection = dataBaseService.GetConexao();

            _connection.CreateTable<Moto>();
        }

        // Consultas do Banco
        public bool Insert(Moto value)
        {
            return
                _connection.Insert(value) > 0;
        }

        public bool Update(Moto value)
        {
            return _connection.Update(value) > 0;
        }

        public bool Delete(Moto value)
        {
            return _connection.Delete(value) > 0;
        }

        public List<Moto> GetAll()
        {
            return
                _connection.Table<Moto>().ToList();
        }

        public Moto GetById(int value)
        {
            return
                _connection.Find<Moto>(value);
        }

        public List<Moto> GetByDesc(string descricao)
        {
            return
                _connection.Table<Moto>().
                Where(x => x.Descricao.Contains(descricao)).ToList();
        }
    }
}
