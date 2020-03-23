using System.Collections.Generic;
using System.Threading.Tasks;
using FractalGroupsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FractalGroupsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IList<Dtos.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<Dtos.Person>>> Post([FromQuery]string query)
        {
            if(string.IsNullOrWhiteSpace(query))
            {
                return BadRequest();
            }

            var result = await _searchService.SearchAsync(query);

            return Ok(result);
        }
    }
}
