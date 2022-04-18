using Stefanini.Domain.Aggregates;

namespace Stefanini.Application.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetCityById(int id);
        Task CreateNewCity(City city);
        Task DeleteCity(int id);
        Task UpdateCity(City city);
        Task<IEnumerable<City>> GetAllCities();
    }
}
