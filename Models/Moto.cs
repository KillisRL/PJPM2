using SQLite;
using SQLitePCL;

namespace MotoAPP.Models
{
    public class Moto
    {
        [PrimaryKey, AutoIncrement]
        public int MotoId { get; set; }
        [NotNull]
        public string Descricao { get; set; }
        [NotNull]
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [NotNull]
        public string Ano { get; set; }
    }
}
