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
    internal class PlaylistMusicService : IService<PlaylistMusic>
    {
        public void Add(PlaylistMusic model)
        {
            Sql.ExecuteCommand($"INSERT INTO PlaylistMusics VALUES ({model.PlaylistId},{model.MusicId})");
        }

        public PlaylistMusic Create()
        {
            int id;
            int id2;
            Console.WriteLine("Enter Playlist id");
            while (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            Console.WriteLine("Enter Music Id");
            while (int.TryParse(Console.ReadLine(), out id2))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            PlaylistMusic pm = new PlaylistMusic
            {
                MusicId = id2,
                PlaylistId = id
            };
            return pm;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE PlaylistMusics WHERE Id = {id}");
        }

        public List<PlaylistMusic> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery("SELECT pm.Id,u.Username [Username],pm.PlaylistId,p.Name [Playlist],pm.MusicId,m.Name [Music] " +
                "FROM PlaylistMusics as pm JOIN Playlists p ON pm.PlaylistId = p.Id " +
                "JOIN Musics m ON pm.MusicId = m.Id JOIN Users u ON p.UserId = u.Id");
            List<PlaylistMusic> list = new List<PlaylistMusic>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new PlaylistMusic
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    MusicId = Convert.ToInt32(dr["MusicId"]),
                    PlaylistId = Convert.ToInt32(dr["PlaylistId"]),
                    Username = dr["Username"].ToString(),
                    Music = dr["Music"].ToString(),
                    Playlist = dr["Playlist"].ToString(),

                });
            }
            return list;
        }

        public PlaylistMusic GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT pm.Id,u.Username [Username],pm.PlaylistId,p.Name [Playlist],pm.MusicId,m.Name [Music] " +
            $"FROM PlaylistMusics as pm JOIN Playlists p ON pm.PlaylistId = p.Id " +
            $"JOIN Musics m ON pm.MusicId = m.Id JOIN Users u ON p.UserId = u.Id WHERE pm.Id = {id} ");
            DataRow dr = dt.Rows[0];
            PlaylistMusic model = new PlaylistMusic
            {
                Id = Convert.ToInt32(dr["Id"]),
                MusicId = Convert.ToInt32(dr["MusicId"]),
                PlaylistId = Convert.ToInt32(dr["PlaylistId"]),
                Username = dr["Username"].ToString(),
                Music = dr["Music"].ToString(),
                Playlist = dr["Playlist"].ToString(),
            };
            return model;
        }

        public void Update(PlaylistMusic model)
        {
            Sql.ExecuteCommand($"UPDATE PlaylistMusics SET PlaylistId = {model.PlaylistId},MusicId = {model.MusicId} WHERE Id = {model.Id}");
        }
    }
}
