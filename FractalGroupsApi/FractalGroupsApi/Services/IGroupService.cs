using FractalGroupsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public interface IGroupService
    {
        Task<IList<Group>> GetGroupsAsync();
    }
}