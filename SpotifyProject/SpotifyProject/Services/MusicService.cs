using SpotifyProject.Abstractions;
using SpotifyProject.Helper;
using SpotifyProject.Models;
using System.Data;

namespace SpotifyProject.Services
{
    internal class MusicService : IService<Music>
    {
        //ADD MUSIC
        public void Add(Music model)
        {
            Sql.ExecuteCommand($"INSERT INTO Musics (Name,Duration,CategoryId) VALUES (N'{model.Name}','{model.Duration}',{model.CategoryId})");
        }

        public Music Create()
        {
            string Name;
            TimeSpan duration;
            int  categoryId;
            do
            {
                Console.WriteLine("Enter name:");
                Name = Console.ReadLine();
            } while (string.IsNullOrEmpty(Name));
            while (!TimeSpan.TryParse(Console.ReadLine(),out duration))
            {
                Console.WriteLine("Wrong input enter again");
            }
            Console.WriteLine("Enter Category id");
            while (int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            Music music = new Music
            {
                Name = Name,
                Duration = duration,
                CategoryId = categoryId
            };
            return music;
        }

        //DELETE MUSIC
        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Musics WHERE Id = {id}");
        }
        //GET ALL MUSICS
        public List<Music> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT m.Id, m.Name,m.Duration,c.Name [Category] " +
                $"FROM Musics as m JOIN Categories as c ON m.CategoryId = c.Id");
            List<Music> musics = new List<Music>();
            foreach (DataRow dr in dt.Rows)
            {
                musics.Add(new Music
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Duration = TimeSpan.Parse(dr["Duration"].ToString()),
                    CategoryName = dr["Category"].ToString()
                });
            }
            return musics;
        }


        //GET MUSIC BY ID
        public Music GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT m.Id, m.Name,m.Duration,m.CategoryId,c.Name [Category] " +
    $"FROM Musics as m JOIN Categories as c ON m.CategoryId = c.Id WHERE m.Id = {id}");
            DataRow dr = dt.Rows[0];
            Music music = new Music
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Duration = TimeSpan.Parse(dr["Duration"].ToString()),
                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                CategoryName = dr["Category"].ToString()
            };
            return music;
        }


        // UPDATE MUSICS TABLE
        public void Update(Music model)
        {
            Sql.ExecuteCommand($"UPDATE Musics SET Name = N'{model.Name}',Duration = '{model.Duration}',CategoryId = {model.CategoryId} WHERE Id = {model.Id}");
        }
    }
}