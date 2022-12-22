using SpotifyProject.Abstractions;
using SpotifyProject.Helper;
using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Services
{
    internal class PlaylistService : IService<Playlist>
    {
        public void Add(Playlist model)
        {
            Sql.ExecuteCommand($"INSERT INTO Playlists VALUES ({model.UserId},N'{model.Name}')");
        }

        public Playlist Create()
        {
            int id;
            string Name;
            Console.WriteLine("Enter User id");
            while (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            Console.WriteLine("Enter playlist name:");
            do
            {
                Name = Console.ReadLine();
            } while (string.IsNullOrEmpty(Name));
            Playlist playlist = new Playlist
            {
                Name = Name,
                UserId = id
            };
            return playlist;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Playlists WHERE Id = {id}");
        }

        public List<Playlist> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery("SELECT p.Id,p.UserId,u.Username,p.Name FROM Playlists p JOIN Users u ON p.UserId = u.Id");
            List<Playlist> playlists = new List<Playlist>();
            foreach (DataRow dr in dt.Rows)
            {
                playlists.Add(new Playlist
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    UserId = Convert.ToInt32(dr["UserId"]),
                    Username = dr["Username"].ToString(),
                    Name = dr["Name"].ToString()
                });
            }
            return playlists;

        }

        public Playlist GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery("SELECT p.Id,p.UserId,u.Username,p.Name FROM Playlists p JOIN Users u ON p.UserId = u.Id");
            DataRow dr = dt.Rows[0];
            Playlist playlist = new Playlist
            {
                Id = Convert.ToInt32(dr["Id"]),
                UserId = Convert.ToInt32(dr["UserId"]),
                Username = dr["Username"].ToString(),
                Name = dr["Name"].ToString()
            };
            return playlist;
        }

        public void Update(Playlist model)
        {
            Sql.ExecuteCommand($"UPDATE Playlists SET UserId = {model.UserId},Username = N'{model.Username}'," +
                $"Name = N'{model.Name}' WHERE Id = {model.Id}");
        }
    }
}
