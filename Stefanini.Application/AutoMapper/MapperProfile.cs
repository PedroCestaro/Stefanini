using AutoMapper;
using Stefanini.Domain.Aggregates;
using Stefanini.Application.Dto;
using Stefanini.Application.Models;

namespace Stefanini.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Person
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<CreatePersonCommand, PersonDto>().ReverseMap();
            CreateMap<UpdatePersonCommand, PersonDto>().ReverseMap();
            CreateMap<Person, GetPersonByIdResponse>().ReverseMap();

            #endregion

            #region City

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CreateCityCommand, CityDto>().ReverseMap();
            CreateMap<City, GetCityByIdResponse>().ReverseMap();
            CreateMap<UpdateCityCommand, CityDto>().ReverseMap();

            #endregion
        }
    }
}
