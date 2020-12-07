using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieXam.ViewModels
{
    [Table("Movies")]
     public class MovieModel : INotifyPropertyChanged
    {
        #region IdProp

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        #endregion

        #region TitleProp

        public string _Title;
        public string Title
        {
            get { return _Title; }

            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region GenreProp
        public string _Genre;
        public string Genre
        {
            get { return _Genre; }
            
            set
            {
                _Genre = value;
                OnPropertyChanged(nameof(Genre));       
            }
        }

        #endregion

        #region PropertyChange

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
