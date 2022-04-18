
using Stefanini.Application.Interfaces.Repositories;
using Stefanini.Domain.Aggregates;
using Stefanini.Data;
using Microsoft.EntityFrameworkCore;

namespace Stefanini.Application.Repositories
{
    public class CirtyRepository : ICityRepository, IDisposable
    {
        private readonly StefaniniContext _context;

        public CirtyRepository(StefaniniContext context)
        {
            _context = context;
        }

        public async Task CreateNewCity(City city)
        {
           await _context.Cities.AddAsync(city); 
           await _context.SaveChangesAsync();
        }

        public async Task DeleteCity(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<City> GetCityById(int id)
        {
            return await _context.Cities.FindAsync(id); 
        }

        public async Task UpdateCity(City city)
        {
             _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
