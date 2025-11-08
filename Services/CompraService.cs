using SQLite;
using MotoAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPP.Services
{
    public class CompraService
    {
        private readonly SQLiteConnection _database; // (Recebido via injeção ou inicializado)

        public CompraService(DataBaseService dbService) // Exemplo de DI
        {
            _database = dbService.GetConexao();
        }

        // *** SEU CÓDIGO VAI AQUI ***
        public void SalvarCompra(Moto motoSelecionada, Usuario usuarioLogado, decimal valor)
        {
            MotoCompra novaCompra = new MotoCompra
            {
                MotoId = motoSelecionada.MotoId, // Pega o ID da moto
                UserId = usuarioLogado.UserId, // Pega o ID do usuário
                ValorCompra = valor
            };

            _database.Insert(novaCompra);
        }
    }
}
