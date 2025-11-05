using SQLite;

namespace MotoAPP.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public bool TipoUsuario { get; set; }
    }
}
