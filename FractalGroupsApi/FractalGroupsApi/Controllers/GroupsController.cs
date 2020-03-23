using FractalGroupsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalGroupsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
       
        [HttpGet]
        [ProducesResponseType(typeof(IList<Dtos.Group>), StatusCodes.Status200OK)]        
        public async Task<ActionResult<IList<Dtos.Group>>> Get()
        {
            return Ok(await _groupService.GetGroupsAsync());
        }
    }
}
