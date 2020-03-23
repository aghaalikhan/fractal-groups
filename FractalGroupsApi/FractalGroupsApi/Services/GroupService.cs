using FractalGroupsApi.Dtos;
using FractalGroupsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FractalGroupsApi.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IList<Group>> GetGroupsAsync()
        {
            var groups = await _groupRepository.GetGroupsAsync();

            return groups.Select(group =>
            {
                return new Group
                {
                    GroupId = group.GroupId,
                    Name = group.Name
                };
            }).ToList();
        }
    }
}