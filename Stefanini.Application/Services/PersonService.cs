using Stefanini.Application.Common;
using Stefanini.Application.Dto;
using Stefanini.Application.Interfaces;
using Stefanini.Domain.Aggregates;
using AutoMapper;

namespace Stefanini.Application.Services
{
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Person> GetPersonById(int id)
        {
           return await _repository.GetPersonById(id);
        }

        public async Task CreateNewPerson(PersonDto dto)
        {
            ValidatesCreateNewPerson(dto);
            Person person = new Person(dto.Name, dto.Cpf, dto.Age, dto.CityId);
            await _repository.CreateNewPerson(person);
        }

        private void ValidatesCreateNewPerson(PersonDto dto)
        {
            PersonDtoValidation validator = new PersonDtoValidation();
            var validation = validator.Validate(dto);
            if (validation.Errors.Any())
                throw new ArgumentException(validation.Errors.FirstOrDefault().ErrorMessage);
        }

        public async Task UpdatePerson(PersonDto dto)
        {
            Person person = await GetPersonById(dto.Id.Value);
            UpdateChanges(person, dto);
            await _repository.UpdatePerson(person);
        }

        private void UpdateChanges(Person person, PersonDto dto)
        {
            if (ValidatesToUpdate(person.Name, dto.Name))
                person.setName(dto.Name);

            if(ValidatesToUpdate(person.Cpf, dto.Cpf))
                person.setCpf(dto.Cpf); 

            if(ValidatesToUpdate(person.Age, dto.Age))
                person.SetAge(dto.Age);

            if(ValidatesToUpdate(person.CityId, dto.CityId))
                person.SetCity(dto.CityId);
        }

        public async Task DeletePerson(int id)
        {
            await _repository.DeletePerson(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons()
        {
           var persons = await _repository.GetAllPersons();

            var result = ConvertPersonToDto(persons);

            return result;
        }

        private List<PersonDto> ConvertPersonToDto(IEnumerable<Person> persons)
        {
            var DtoList = new List<PersonDto>();

            foreach (var person in persons)
            {
                var dto = _mapper.Map<Person, PersonDto>(person);
                DtoList.Add(dto);
            }

            return DtoList;
        }
    }
}
