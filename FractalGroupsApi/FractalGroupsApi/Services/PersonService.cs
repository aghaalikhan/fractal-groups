using FractalGroupsApi.Entities;
using FractalGroupsApi.Repositories;
using System;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IPersonRepository _personRepository;

        public PersonService(IGroupRepository groupRepository, IPersonRepository personRepository)
        {
            _groupRepository = groupRepository;
            _personRepository = personRepository;
        }

        public async Task<int> AddPersonAsync(Dtos.Person person)
        {
            if (!(await _groupRepository.DoesGroupExistAsnyc(person.GroupId)))
            {
                throw new ArgumentException($"{nameof(person.GroupId)} is not valid");
            }

            var personEntity = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonGroup = new PersonGroup
                {
                    GroupId = person.GroupId
                },
                CreatedDate = DateTimeOffset.UtcNow
            };


            var personId = await _personRepository.AddPersonAsync(personEntity);

            return personId;

        }

        public async Task<Dtos.Person> GetPersonAsync(int personId)
        {
            var personEntity = await _personRepository.GetPersonAsync(personId);

            if(personEntity == null)
            {
                return null;
            }

            return new Dtos.Person
            {
                PersonId = personEntity.PersonId,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                GroupId = personEntity.PersonGroup.GroupId,
                CreatedDate = personEntity.CreatedDate,
            };
        }
    }
}
