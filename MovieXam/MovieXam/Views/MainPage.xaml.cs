using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieXam.ViewModels;
using SQLite;

namespace MovieXam.Views
{
    public partial class MainPage : ContentPage
    {
        MovieDataAccess dataAccess;
        public MainPage()
        {
            InitializeComponent();
            this.dataAccess = new MovieDataAccess();     
            
        }     
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.dataAccess;
        }
    
        private void OnAddClick(object sender, EventArgs e)
        {
            AddStack.IsVisible = true;           
        }
     
        private void OnRemoveClick(object sender, EventArgs e)
        {
            var movie =
              this.MovieView.SelectedItem as MovieModel;
            
            if (movie != null)
            {
                this.dataAccess.DeleteMovie(movie);
            }
        }
             
        private void OnConfirmClick(object sender, EventArgs e)
        {
            AddStack.IsVisible = false;
            dataAccess.AddNewMovie(_title.Text, _genre.Text);

        }

       
    }
}
