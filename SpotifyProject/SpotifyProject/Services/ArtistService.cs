using SpotifyProject.Abstractions;
using SpotifyProject.Helper;
using SpotifyProject.Models;
using System.Data;

namespace SpotifyProject.Services
{
    internal class ArtistService : IService<Artist>
    {
        public void Add(Artist model)
        {
            Sql.ExecuteCommand($"INSERT INTO Artists  VALUES (N'{model.Name}',N'{model.Surname}','{model.Birthday}',N'{model.Gender}')");
        }

        public Artist Create()
        {
            string Name;
            string Surname;
            DateTime Birthday;
            string Gender;
            do
            {
                Console.WriteLine("Enter name:");
                Name = Console.ReadLine();
            } while (string.IsNullOrEmpty(Name));
            do
            {
                Console.WriteLine("Enter Surname:");
                Surname = Console.ReadLine();
            } while (string.IsNullOrEmpty(Surname));
            Console.WriteLine("Enter birthday");
            while (!DateTime.TryParse(Console.ReadLine(),out Birthday))
            {
                Console.WriteLine("Wrong input, enter again");
            }
            do
            {
                Console.WriteLine("Enter gender");
                Gender = Console.ReadLine();
            } while (string.IsNullOrEmpty(Gender));
            Artist artist = new Artist
            {
                Name = Name,
                Surname = Surname,
                Birthday = Birthday,
                Gender = Gender
            };
            return artist;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Artists WHERE Id = {id}");
        }

        public List<Artist> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT * FROM Artists");
            List<Artist> artists = new List<Artist>();
            foreach (DataRow dr in dt.Rows)
            {
                artists.Add(new Artist
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(dr["Birthday"])
                }) ;
            }
            return artists;
        }

        public Artist GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT * FROM Artists WHERE Id = {id}");
            DataRow dr = dt.Rows[0];
            Artist artist = new Artist
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Surname = dr["Surname"].ToString(),
                Gender = dr["Gender"].ToString(),
                Birthday = Convert.ToDateTime(dr["Birthday"])
            };
            return artist;
        }

        public void Update(Artist model)
        {
            Sql.ExecuteCommand($"UPDATE Artists SET Name = N'{model.Name}',Surname = N'{model.Surname}',Birthday = '{model.Birthday}'," +
                $"Gender =  N'{model.Gender}' WHERE Id = {model.Id}");
        }
    }
}
