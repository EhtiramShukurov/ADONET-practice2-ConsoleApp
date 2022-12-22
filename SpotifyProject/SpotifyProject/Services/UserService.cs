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
    internal class UserService : IService<User>
    {
        public void Add(User model)
        {
            Sql.ExecuteCommand($"INSERT INTO Users  VALUES (N'{model.Name}',N'{model.Surname}',N'{model.Username}'," +
                $"N'{model.Password}',N'{model.Gender}',{model.RoleId})");
        }

        public User Create()
        {
            string name;
            string username;
            string surname;
            string password;
            string gender;
            int roleId;
            do
            {
                Console.WriteLine("Enter name:");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            do
            {
                Console.WriteLine("Enter Surname:");
                surname = Console.ReadLine();
            } while (string.IsNullOrEmpty(surname));
            do
            {
                Console.WriteLine("Enter username");
                username = Console.ReadLine();
            } while (string.IsNullOrEmpty(username));
            do
            {
                Console.WriteLine("Enter password");
                password = Console.ReadLine();
            } while (string.IsNullOrEmpty(password));
            do
            {
                Console.WriteLine("Enter gender");
                gender = Console.ReadLine();
            } while (string.IsNullOrEmpty(gender));

            Console.WriteLine("Enter Role id");
            while (!int.TryParse(Console.ReadLine(), out roleId))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            User user = new User { Name = name, Surname = surname, Password = password, Gender = gender, RoleId = roleId};
            return user;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Users WHERE Id = {id}");
        }

        public List<User> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT u.Id,u.Name,u.Surname,u.Username,u.Password,u.Gender,r.Type [Role Type] " +
                $"FROM Users as u JOIN Roles as r ON u.RoleId = r.Id");
            List <User> users = new List<User>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new User
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    RoleName = dr["Role Type"].ToString()
                });
            }
            return users;
        }

        public User GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT u.Id,u.Name,u.Surname,u.Username,u.Password,u.Gender,u.RoleId,r.Type [Role Type] " +
                $"FROM Users as u JOIN Roles as r ON u.RoleId = r.Id WHERE u.Id = {id}");
            DataRow dr = dt.Rows[0];
            User user = new User
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Surname = dr["Surname"].ToString(),
                Username = dr["Username"].ToString(),
                Password = dr["Password"].ToString(),
                Gender = dr["Gender"].ToString(),
                RoleId = Convert.ToInt32(dr["RoleId"]),
                RoleName = dr["Role Type"].ToString()
            };
            return user;
        }

        public void Update(User model)
        {
            Sql.ExecuteCommand($"UPDATE Users SET Name =  N'{model.Name}',Surname = N'{model.Surname}',Username = N'{model.Username}'," +
                $"Password = N'{model.Password}',Gender = N'{model.Gender}' RoleId ={model.RoleId} Role Type = N'{model.RoleName}' WHERE Id = {model.Id}");
        }
    }
}
