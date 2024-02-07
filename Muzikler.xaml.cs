using Muzik.Models;
using Muzik.Repositories;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Maui.Core.Primitives;

namespace Muzik
{
    public partial class Muzikler : ContentPage
    {
        private SongRepository _songRepository;

        public ObservableCollection<Song> Songs { get; set; }

        public Song SelectedSong { get; set; }
        public Muzikler()
        {

            InitializeComponent();

            // Veritabaný baðlantýsý ve SongRepository nesnesinin oluþturulmasý
            var dbContext = new AppDbContext();
            _songRepository = new SongRepository(dbContext);

            // Þarkýlar listesi için ObservableCollection'ýn oluþturulmasý ve verilerin yüklenmesi
            Songs = new ObservableCollection<Song>(_songRepository.GetAllSongs());

            // Binding Context'in ayarlanmasý
            BindingContext = this;


        }




        private void OrnekVeriEkle(object sender, EventArgs e)
        {
            // Örnek veri eklemek için kullanýlacak kodlar
        }

        private ICommand _playCommand;

        public ICommand PlayCommand
        {
            get
            {
                if (_playCommand == null)
                    _playCommand = new Command<Song>(PlaySong);
                return _playCommand;
            }
        }

        private void PlaySong(Song song)
        {
            var mediaElement = this.FindByName<MediaElement>("MyMediaElement");

            if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Stop();
            }

            mediaElement.Source = new Uri(song.Link);
            Debug.WriteLine("Müzik çalmaya baþlandý");
            mediaElement.Play();
        }

        private void OnPlayButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var song = button?.BindingContext as Song;

            var mediaElement = this.FindByName<MediaElement>("MyMediaElement");

            if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Stop();
            }

            mediaElement.Source = new Uri(song.Link);
            Debug.WriteLine("Müzik çalmaya baþlandý");
            mediaElement.Play();
        }


        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var song = button?.BindingContext as Song;

            if (song != null)
            {
                _songRepository.DeleteSong(song);
                Songs.Remove(song);
            }
        }

        private async void OnMuzikEkleButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MuzikEkle");
        }




    }
}
