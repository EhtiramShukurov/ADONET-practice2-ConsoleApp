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
    internal class CategoryService : IService<Category>
    {
        public void Add(Category model)
        {
            Sql.ExecuteCommand($"INSERT INTO Categories  VALUES (N'{model.Name}')");

        }

        public Category Create()
        {
            string Name;
            do
            {
                Console.WriteLine("Enter category name:");
                Name = Console.ReadLine();
            } while (string.IsNullOrEmpty(Name));
            Category category = new Category
            {
                Name = Name
            };
            return category;
        }

        public void DeleteById(int id)
        {
            Sql.ExecuteCommand($"DELETE Categories WHERE Id = {id}");

        }

        public List<Category> GetAll()
        {
            DataTable dt = Sql.ExecuteQuery("SELECT * FROM Categories");
            List<Category> categories = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                categories.Add(new Category
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString()
                });
            }
            return categories;
        }

        public Category GetById(int id)
        {
            DataTable dt = Sql.ExecuteQuery("SELECT * FROM Categories");
            DataRow dr = dt.Rows[0];
            Category category = new Category
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString()
            };
            return category;

        }

        public void Update(Category model)
        {
            Sql.ExecuteCommand($"UPDATE Categories SET Name = N'{model.Name}' WHERE Id = {model.Id}");
        }
    }
}
