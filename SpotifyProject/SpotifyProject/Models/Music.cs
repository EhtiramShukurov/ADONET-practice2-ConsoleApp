using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Duration + " " + CategoryName;
        }
    }
}
