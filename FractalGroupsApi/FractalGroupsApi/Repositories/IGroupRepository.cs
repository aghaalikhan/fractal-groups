using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalGroupsApi.Repositories
{
    public interface IGroupRepository
    {
        Task<bool> DoesGroupExistAsnyc(int groupId);
        Task<IList<Entities.Group>> GetGroupsAsync();
    };
}