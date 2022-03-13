using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quandomeutimejoga_server.Data;
using quandomeutimejoga_server.Models;
using quandomeutimejoga_server.ViewModels;

namespace quandomeutimejoga_server.Controllers
{
    [Route("api/v1/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetListTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams is not null ? Ok(teams) : NotFound();
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            return team is not null ? Ok(team) : NotFound();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTeam(Guid id, Team model)
        //{
        //    //var team = model.MapTo();
        //    //if (!model.IsValid)
        //    //    return BadRequest(model.Notifications);

        //    var team = await _context.Teams.FindAsync(id);
        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    findTeamById.FullName = team.FullName;
        //    findTeamById.ShortName = team.ShortName;
        //    findTeamById.Initials = team.Initials;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return BadRequest();
        //    }

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamViewModel model)
        {
            var team = model.MapTo();
            if (!model.IsValid)
                return BadRequest(model.Notifications);

            await _context.AddAsync(team);
            await _context.SaveChangesAsync();

            return Created($"/v1/teams/{team.Id}", team);
        }
    }
}
