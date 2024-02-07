using Muzik.Models;
using Muzik.Repositories;
using System;

namespace Muzik
{
    public partial class MuzikEkle : ContentPage
    {
        private readonly SongRepository _songRepository;

        public MuzikEkle()
        {
            InitializeComponent();

            _songRepository = new SongRepository(new AppDbContext()); // AppDbContext'ý burada oluþturarak geçebilirsiniz.
        }

        private async void OnGeriDonButtonClicked(object sender, EventArgs e)
        {
            _songRepository.UpdateSongs();

            await Shell.Current.GoToAsync("//Muzikler");

        }
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            string title = titleEntry.Text;
            string artist = artistEntry.Text;
            string link = linkEntry.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(artist) || string.IsNullOrWhiteSpace(link))
            {
                DisplayAlert("Hata", "Tüm alanlarý doldurun.", "Tamam");
            }
            else
            {
                Song newSong = new Song(title, artist, link);
                _songRepository.AddSong(newSong);

                DisplayAlert("Baþarýlý", "Müzik baþarýyla eklendi.", "Tamam");

                _songRepository.UpdateSongs();
            }
        }
    }
}
