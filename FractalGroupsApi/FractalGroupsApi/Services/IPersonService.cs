using FractalGroupsApi.Dtos;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public interface IPersonService
    {
        Task<int> AddPersonAsync(Person person);
        Task<Dtos.Person> GetPersonAsync(int personId);
    }
}