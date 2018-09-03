using CoffeeApp.Data.Models;
using CoffeeApp.Data.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApp.Data
{
    public class IngredientsRepository : IRepository<Ingredients>
    {
        private readonly AppDbContext _context;
        public IngredientsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Ingredients item)
        {
            _context.Ingredients.Add(item);
        }
        public IEnumerable<Ingredients> GetAll()
        {
            return _context.Ingredients;
        }
        public  Ingredients Get(int index)
        {
            return  _context.Ingredients.AsQueryable().ElementAt(index);
        }
    }
}
