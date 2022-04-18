using Stefanini.Domain.Aggregates;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Person> GetPersonById (int id);

        Task CreateNewPerson(PersonDto dto);

        Task UpdatePerson(PersonDto dto);

        Task DeletePerson(int id);

        Task<IEnumerable<PersonDto>> GetAllPersons();
    }
}
