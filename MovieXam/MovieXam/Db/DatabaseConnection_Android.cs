using SQLite;
using System.IO;

namespace MovieXam
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "MovieDb.mdb";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}
