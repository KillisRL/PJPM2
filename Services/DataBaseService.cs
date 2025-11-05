using PCLExt.FileStorage.Folders;
using SQLite;

namespace MotoAPP.Services
{
    public class DataBaseService
    {
        public SQLiteConnection connection;
        public SQLiteConnection GetConexao()
        {           
            var folder = new LocalRootFolder();

            var file =
                folder.CreateFile("list",
                    PCLExt.FileStorage.
                    CreationCollisionOption.
                    OpenIfExists);

            return new SQLiteConnection(file.Path);
        }
    }
}
