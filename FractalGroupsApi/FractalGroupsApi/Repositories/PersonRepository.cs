using FractalGroupsApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FractalGroupsApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonsDbContext _personDbContext;

        public PersonRepository(PersonsDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            await _personDbContext.Persons.AddAsync(person);
            await _personDbContext.SaveChangesAsync();

            return person.PersonId;

        }

        public IList<Person> SearchPersons(string query)
        {
            return (from person in _personDbContext.Persons
                    join personGroup in _personDbContext.PersonGroups on person.PersonId equals personGroup.PersonId
                    join ggroup in _personDbContext.Groups on personGroup.GroupId equals ggroup.GroupId
                    where person.FirstName.Contains(query) || person.LastName.Contains(query) || personGroup.GroupId == ggroup.GroupId && ggroup.Name.Contains(query)
                    select new Person
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        PersonGroup = person.PersonGroup,
                        CreatedDate = person.CreatedDate,
                        PersonId = person.PersonId
                    }).ToList();
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            return await _personDbContext.Persons
                .Include(person => person.PersonGroup)
                .SingleOrDefaultAsync(person => person.PersonId == id);
        }
    }
}
