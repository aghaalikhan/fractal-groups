using FractalGroupsApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FractalGroupsApi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PersonsDbContext _personDbContext;

        public GroupRepository(PersonsDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task<bool> DoesGroupExistAsnyc(int groupId)
        {
            return await _personDbContext.Groups.AnyAsync(group => group.GroupId == groupId);
        }

        public async Task<IList<Group>> GetGroupsAsync()
        {
            return await _personDbContext.Groups.ToListAsync();        
        }
    }
}
