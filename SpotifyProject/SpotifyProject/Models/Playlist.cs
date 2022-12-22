using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public override string ToString()
        {
            return Id + " " + UserId + " " + Username + " " + Name;
        }

    }
}
