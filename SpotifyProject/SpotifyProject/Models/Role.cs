using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class Role
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return Id + " " + Type;
        }
    }
}
