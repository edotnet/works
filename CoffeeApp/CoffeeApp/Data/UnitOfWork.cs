using CoffeeApp.Data.Models;
using CoffeeApp.Data.Services;
using System;
using System.Threading.Tasks;

namespace CoffeeApp.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context = new AppDbContext();
        private bool disposed;
        private IRepository<Coffee> coffeeRepository;
        private IRepository<Ingredients> ingredientsRepository;

        public IRepository<Coffee> Coffee
        {
            get
            {
                if (coffeeRepository == null)
                    coffeeRepository = new CoffeeRepository(_context);
                return coffeeRepository;
            }
        }

        public IRepository<Ingredients> Ingredients
        {
            get
            {
                if (ingredientsRepository == null)
                    ingredientsRepository = new IngredientsRepository(_context);
                return ingredientsRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   _context.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
