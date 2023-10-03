using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiNew.Models
{
    internal interface IRepository<T>
    {
        List<T> ReadAll();

        T GetById(string id);


        void Insert(T item);

        void Update(T item);


        void Delete(string id);
    }
}
