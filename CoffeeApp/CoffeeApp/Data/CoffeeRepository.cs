using CoffeeApp.Data.Models;
using CoffeeApp.Data.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApp.Data
{
    class CoffeeRepository : IRepository<Coffee>
    {
        private readonly AppDbContext _context;

        public CoffeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Coffee item)
        {
            _context.Coffee.Add(item);
        }
        public  Coffee Get(int index)
        {
            return  _context.Coffee.ToList().ElementAt(index);
        }

        public IEnumerable<Coffee> GetAll()
        {
            return _context.Coffee;
        }
    }
}
