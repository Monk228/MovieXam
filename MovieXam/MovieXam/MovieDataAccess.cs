using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using MovieXam.ViewModels;

namespace MovieXam
{
    public class MovieDataAccess
    {
        public SQLiteConnection database = new SQLiteConnection("");

        private static object collisionLock = new object();
        public ObservableCollection<MovieModel> Movies { get; set; }
        public MovieDataAccess()
        {
           DatabaseConnection_Android conn= new DatabaseConnection_Android();
           database = conn.DbConnection();
           database.CreateTable<MovieModel>();
         
           
            this.Movies =
              new ObservableCollection<MovieModel>(
              database.Table<MovieModel>());

        }
      
        public SQLiteConnection AddNewMovie(string title, string genre)
        {
            this.Movies.
              Add(new MovieModel
              {  
                  
                  Title = title,
                  Genre = genre,
              });

            SaveAllMovies();

            return database;
        }

      
        public int DeleteMovie(MovieModel movie)
        {
            var id = movie.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<MovieModel>(id);
                }
            }
            this.Movies.Remove(movie);
            return id;
        }
        public void SaveAllMovies()
        {
            lock (collisionLock)
            {
                foreach (var movie in this.Movies)
                {
                    if (movie.Id != 0)
                    {
                        database.Update(movie);
                    }
                    else
                    {
                        database.Insert(movie);
                    }
                }
            }
        }
        public void RemoveMovie(string id)
        {
            lock (collisionLock)
            {
                for (int i = 0; i < Movies.Count; i++)
                {
                    if (Movies[i].Id.ToString() == id)
                    {
                        Movies.Remove(Movies[i]);
                    }
                }
                SaveAllMovies();
            }
        }
        public void DeleteAllMovies()
        {
            lock (collisionLock)
            {
                database.DropTable<MovieModel>();
                database.CreateTable<MovieModel>();
            }
            this.Movies = null;
            this.Movies = new ObservableCollection<MovieModel>
              (database.Table<MovieModel>());
        }
    }
}
