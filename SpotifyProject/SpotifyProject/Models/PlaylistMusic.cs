using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class PlaylistMusic
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int MusicId { get; set; }
        public string Username { get; set; }
        public string Playlist { get; set; }
        public string Music { get; set; }

        public override string ToString()
        {
            return Id + " " + Username + " " + " " + Playlist + " " + Music;
        }
    }
}