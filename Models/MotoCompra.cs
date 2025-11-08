using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPP.Models
{
    [Table("MotoCompra")] // Opcional, mas boa prática
    public class MotoCompra
    {
        // 1. O ID da Compra (Chave Primária)
        [PrimaryKey, AutoIncrement]
        public int IDCompraMoto { get; set; }

        // 2. Os Dados da Moto (Salva o ID)
        [Indexed] // Melhora a performance de busca por MotoId
        public int MotoId { get; set; } // <--- Correção 1: Salva o ID da Moto

        // 3. Os Dados do Usuário (Salva o ID)
        [Indexed] // Melhora a performance de busca por UserId
        public int UserId { get; set; } // <--- Correção 2: Salva o ID do Usuário

        // 4. O Valor (Usa 'decimal' para dinheiro)
        public decimal ValorCompra { get; set; } // <--- Correção 3: 'decimal' é o tipo correto para dinheiro

        // --- Propriedades de Navegação (Para uso no App) ---
        // O [Ignore] diz ao SQLite para NÃO tentar salvar estas
        // colunas no banco de dados.

        [Ignore]
        public Moto? Moto { get; set; } // Você preencherá isso manualmente no seu ViewModel

        [Ignore]
        public Usuario? Usuario { get; set; } // Você preencherá isso manualmente no seu ViewModel
    }
}
