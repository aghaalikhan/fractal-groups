using FractalGroupsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public interface ISearchService
    {
        public Task<IList<Person>> SearchAsync(string query);
    }
}