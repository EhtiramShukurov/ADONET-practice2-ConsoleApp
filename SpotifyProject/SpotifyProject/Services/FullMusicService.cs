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
    internal class FullMusicService : IService<FullMusic>
    {
        public void Add(FullMusic model)
        {
            Sql.ExecuteCommand($"INSERT INTO FullMusics VALUES ({model.MusicId},{model.ArtistId}");
        }

        public FullMusic Create()
        {
            int id;
            int id2;
            Console.WriteLine("Enter Music id");
            while (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            Console.WriteLine("Enter Artist Id");
            while (int.TryParse(Console.ReadLine(), out id2))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            FullMusic pm = new FullMusic
            {
                MusicId = id,
                ArtistId = id2
            };
            return pm;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE  FullMusics WHERE Id = {id}");
        }

        public List<FullMusic> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery("SELECT f.Id,f.MusicId,f.ArtistId,m.Name [Music Name],a.Name [Artist Name]" +
                "FROM FullMusics f JOIN Musics as m ON f.MusicId = m.Id JOIN Artists a ON f.ArtistId = a.Id");
            List<FullMusic> fullMusics = new List<FullMusic>();
            foreach (DataRow dr in dt.Rows)
            {
                fullMusics.Add(new FullMusic
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    MusicName = dr["Music Name"].ToString(),
                    ArtistName = dr["Artist Name"].ToString(),
                    ArtistId = Convert.ToInt32(dr["ArtistId"]),
                    MusicId = Convert.ToInt32(dr["MusicId"])

                });
            }
            return fullMusics;

        }

        public FullMusic GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery("SELECT f.Id,f.ArtistId,f.MusicId,m.Name [Music Name],a.Name [Artist Name]" +
            "FROM FullMusics f JOIN Musics as m ON f.MusicId = m.Id JOIN Artists a ON f.ArtistId = a.Id");
            DataRow dr = dt.Rows[0];
            FullMusic fullMusic = new FullMusic
            {
                Id = Convert.ToInt32(dr["Id"]),
                MusicName = dr["Music Name"].ToString(),
                ArtistName = dr["Artist Name"].ToString(),
                ArtistId = Convert.ToInt32(dr["ArtistId"]),
                MusicId = Convert.ToInt32(dr["MusicId"])
            };
            return fullMusic;
        }

        public void Update(FullMusic model)
        {
            Sql.ExecuteCommand($"UPDATE FullMusics SET MusicId = {model.MusicId},ArtistId = {model.ArtistId} WHERE Id = {model.Id}");
        }
    }
}
