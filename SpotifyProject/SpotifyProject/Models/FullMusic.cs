using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class FullMusic
    {
        public int Id { get; set; }
        public int MusicId { get; set; }
        public int ArtistId { get; set; }
        public string MusicName { get; set; }
        public string ArtistName { get; set; }
        public override string ToString()
        {
            return Id + " " + MusicName + " " + ArtistName + " ";
        }
    }
}
