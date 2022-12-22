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
    internal class RoleService : IService<Role>
    {
        public void Add(Role model)
        {
            Sql.ExecuteCommand($"INSERT INTO Roles  VALUES (N'{model.Type}')");

        }

        public Role Create()
        {
            string Type;
            do
            {
                Console.WriteLine("Enter role name:");
                Type = Console.ReadLine();
            } while (string.IsNullOrEmpty(Type));
            Role role = new Role
            {
                Type = Type
            };
            return role;
        }

        public  void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Roles WHERE Id = {id}");
        }

        public List<Role> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery("SELECT * FROM Roles");
            List<Role> roles = new List<Role>();
            foreach (DataRow dr in dt.Rows)
            {
                roles.Add(new Role
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Type = dr["Type"].ToString()
                });
            }
            return roles;
        }

        public Role GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery($"SELECT * FROM Roles WHERE Id = {id}");
            DataRow dr = dt.Rows[0];
            Role role = new Role
            {
                Id = Convert.ToInt32(dr["Id"]),
                Type = dr["Type"].ToString()
            };
            return role;

        }

        public void Update(Role model)
        {
            Sql.ExecuteCommand($"UPDATE Roles SET Type = N'{model.Type}' WHERE Id = {model.Id}");
        }
    }
}
