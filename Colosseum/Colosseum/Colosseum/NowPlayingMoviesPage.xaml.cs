using Colosseum.Models;
using Colosseum.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colosseum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingMoviesPage : ContentPage
    {
        public ObservableCollection<NowPlayingMovie> NowPlayingMovies;

        public NowPlayingMoviesPage()
        {
            InitializeComponent();
            NowPlayingMovies = new ObservableCollection<NowPlayingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var nowPlayingMovies = await apiServices.GetNowPlayingMovies();
            foreach (var nowPlayingMovie in nowPlayingMovies)
            {
                NowPlayingMovies.Add(nowPlayingMovie);
            }
            LvNowPlaying.ItemsSource = NowPlayingMovies;
        }
    }
}