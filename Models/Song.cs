using System.Windows.Input;

namespace Muzik.Models
{
    public class Song
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public string Link { get; set; }

        public Song(string title, string artist, string link){
            Title = title;  
            Artist = artist;
            Link = link;


        }
    }
}