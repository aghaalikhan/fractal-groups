using FractalGroupsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalGroupsApi.Repositories
{
    public interface IPersonRepository
    {
        IList<Person> SearchPersons(string query);
        Task<int> AddPersonAsync(Person person);
        Task<Person> GetPersonAsync(int id);
    }
}