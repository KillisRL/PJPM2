using SQLite;
using MotoAPP.Models; // Importe seus modelos
using System.IO; // Para usar Path.Combine

namespace MotoAPP.Services
{
    public class DataBaseService
    {
        // 1. O campo 'readonly' para armazenar a conexão ÚNICA
        private readonly SQLiteConnection _database;

        // 2. O Construtor é chamado UMA VEZ (pelo MauiProgram.cs)
        public DataBaseService()
        {
            // 3. Pega o caminho padrão do MAUI para salvar o banco
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "motoapp.db3");

            // 4. Inicializa a conexão
            _database = new SQLiteConnection(dbPath);

            // 5. CRIA AS TABELAS (SE ELAS NÃO EXISTIREM)
            //    Esta é a correção principal para o seu erro!
            _database.CreateTable<Usuario>();
            _database.CreateTable<Moto>();
            _database.CreateTable<MotoCompra>(); // <-- A TABELA FALTANTE
        }

        // 6. O método agora retorna a conexão ÚNICA que já foi criada
        public SQLiteConnection GetConexao()
        {
            return _database;
        }
    }
}