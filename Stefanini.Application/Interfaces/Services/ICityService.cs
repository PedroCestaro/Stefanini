using Stefanini.Domain.Aggregates;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityById(int id);

        Task CreateNewCity(CityDto dto);

        Task UpdateCity(CityDto dto);

        Task DeleteCity(int id);

        Task<IEnumerable<CityDto>> GetAllCities();
    }
}
