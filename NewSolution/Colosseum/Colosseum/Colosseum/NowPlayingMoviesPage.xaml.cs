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
        private static bool First = true;

        public NowPlayingMoviesPage()
        {
            InitializeComponent();
            NowPlayingMovies = new ObservableCollection<NowPlayingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var nowPlayingMovies = await apiServices.GetNowPlayingMovies();
                foreach (var nowPlayinMovie in nowPlayingMovies)
                {
                    NowPlayingMovies.Add(nowPlayinMovie);
                }

                LvNowPlaying.ItemsSource = NowPlayingMovies;
            }

            First = false;
        }
    }
}