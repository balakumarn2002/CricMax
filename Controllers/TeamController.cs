using IPL.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamApi _teamApi;

        public TeamController(ITeamApi teamApi)
        {
            _teamApi = teamApi;
        }

        [HttpGet]
        public async Task<ActionResult<Common.Models.Team>> Get(int teamId)
        {
            try
            {
                return Ok(await _teamApi.GetAsync(teamId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Save(Common.Models.Team team)
        {
            try
            {
                return Ok(await _teamApi.SaveAsync(team));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int teamId)
        {
            try
            {
                return Ok(await _teamApi.DeleteAsync(teamId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
