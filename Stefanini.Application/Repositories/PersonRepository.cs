using Stefanini.Application.Dto;
using Stefanini.Application.Interfaces;
using Stefanini.Data;
using Stefanini.Domain.Aggregates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Stefanini.Application.Repositories
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private readonly StefaniniContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper, StefaniniContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateNewPerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task DeletePerson(int id)
        {

            var entity = await _context.Persons.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

           public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
