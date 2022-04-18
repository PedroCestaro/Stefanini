using Stefanini.Domain.Aggregates;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(int id);
        Task CreateNewPerson(Person person);
        Task DeletePerson(int id);
        Task UpdatePerson(Person person);
        Task<IEnumerable<Person>> GetAllPersons();
    }
}
