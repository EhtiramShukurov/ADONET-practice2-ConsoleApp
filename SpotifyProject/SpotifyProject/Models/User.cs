using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Gender { get; set; }
        public string RoleName { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Surname + " " + Username + " " + Password + " " + Gender + " " +  RoleName;
        }

    }
}
