namespace MovieXam
{
    //Если будут подключения для других ОС они должны использовать реализовывать этот интерфейс
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
