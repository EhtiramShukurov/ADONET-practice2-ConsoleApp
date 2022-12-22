using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Abstractions
{
    internal interface IService<T>
    {
        void Add(T model); 
        List<T> GetAll();
        T GetById(int id);
        void  DeleteById(int id);
        void Update(T model);
        T Create();
    }
}
