using Stefanini.Application.Interfaces;
using Stefanini.Application.Interfaces.Repositories;
using Stefanini.Domain.Aggregates;
using Stefanini.Application.Dto;
using Stefanini.Application.Models.Dto.Validations;
using Stefanini.Application.Common;
using AutoMapper;

namespace Stefanini.Application.Services
{
    public class CityService : BaseService, ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<City> GetCityById(int id)
        {
            return await _repository.GetCityById(id);
        }

        public async Task CreateNewCity(CityDto dto)
        {
            ValidatesCreateNewCity(dto);
            City city = new City(dto.Name, dto.Uf);
            await _repository.CreateNewCity(city);
        }

        private void ValidatesCreateNewCity(CityDto dto)
        {
            CityDtoValidation validator = new CityDtoValidation();
            var validation = validator.Validate(dto);
            if (validation.Errors.Any())
                throw new ArgumentException(validation.Errors.FirstOrDefault().ErrorMessage);
        }

        public async Task UpdateCity(CityDto dto)
        {
            City city = await GetCityById(dto.Id);
            UpdateChanges(city, dto);
            await _repository.UpdateCity(city);
        }

        private void UpdateChanges(City city, CityDto dto)
        {
            if(ValidatesToUpdate(city.Uf,dto.Uf))
                city.setUf(dto.Uf);

            if (ValidatesToUpdate(city.Name, dto.Name))
                city.setName(dto.Name);
        }

        public async Task DeleteCity(int id)
        {
            await _repository.DeleteCity(id);
        }

        public async Task<IEnumerable<CityDto>> GetAllCities()
        {
            var cities = await _repository.GetAllCities();

            var result = ConvertCityToDto(cities);

            return result;
        }

        private List<CityDto> ConvertCityToDto(IEnumerable<City> cities)
        {
            var DtoList = new List<CityDto>();

            foreach (var city in cities)
            {
                var dto = _mapper.Map<City, CityDto>(city);
                DtoList.Add(dto);
            }

            return DtoList;
        }
    }
}
