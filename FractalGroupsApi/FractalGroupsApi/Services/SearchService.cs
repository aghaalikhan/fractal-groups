using FractalGroupsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly IPersonRepository _personRepository;

        public SearchService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IList<Dtos.Person>> SearchAsync(string query)
        {
            var matchingPersonEntities = _personRepository.SearchPersons(query);

            return matchingPersonEntities.Select(person =>
            {
                return new Dtos.Person
                {
                    PersonId = person.PersonId,                     
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    CreatedDate = person.CreatedDate,
                    GroupId = person.PersonGroup.GroupId
                };
            }).ToList();
        }
    }
}
