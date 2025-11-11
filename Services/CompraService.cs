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
        private readonly SQLiteConnection _database; 
        private readonly MotoService _motoService;
        private readonly UserService _userService;

        public CompraService(DataBaseService dbService, MotoService motoService, UserService userService) 
        {
            _database = dbService.GetConexao();
            _motoService = motoService; 
            _userService = userService; 

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
        public List<MotoCompra> GetComprasPorUsuario(int userId)
        {
            // 1. Busca todas as compras que batem com o UserId
            var comprasDoBanco = _database.Table<MotoCompra>()
                                          .Where(c => c.UserId == userId)
                                          .ToList();

            // 2. "Re-hidrata" os objetos (Preenche os campos [Ignore])
            // Opcional, mas recomendado para a UI
            foreach (var compra in comprasDoBanco)
            {
                compra.Moto = _motoService.GetById(compra.MotoId);
                compra.Usuario = _userService.GetById(compra.UserId);
            }

            return comprasDoBanco;
        }

        public List<MotoCompra> GetComprasTotal()
        {
            // 1. Busca TODAS as compras, sem filtro 'Where'
            var todasAsCompras = _database.Table<MotoCompra>().ToList();

            // 2. "Re-hidrata" os objetos (Preenche Moto e Usuario)
            foreach (var compra in todasAsCompras)
            {
                // Busca a moto associada a esta compra
                compra.Moto = _motoService.GetById(compra.MotoId);

                // Busca o usuário (cliente) associado a esta compra
                compra.Usuario = _userService.GetById(compra.UserId);
            }

            return todasAsCompras;
        }
    }
}
