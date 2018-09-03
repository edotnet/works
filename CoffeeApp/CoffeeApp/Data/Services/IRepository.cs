using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeApp.Data.Services
{
    public interface IRepository<T> where T : class
    {
        T Get(int index);
        IEnumerable<T> GetAll();
        void Add(T item);
    }
}
