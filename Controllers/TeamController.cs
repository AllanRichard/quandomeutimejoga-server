using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quandomeutimejoga_server.Data;
using quandomeutimejoga_server.Models;
using quandomeutimejoga_server.Models.Views;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(Guid id, TeamView model)
        {
            var validations = model.Validations();
            if (validations.Count > 0)
                return BadRequest(validations);

            var update = await _context.Teams.FindAsync(id);
            if (update == null)
            {
                return NotFound();
            }

            update.FullName = model.FullName;
            update.ShortName = model.ShortName;
            update.Initials = model.Initials;
            update.CountryId = model.CountryId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TeamExists(id))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamView model)
        {
            var validations = model.Validations();
            if (validations.Count > 0)
                return BadRequest(validations);

            var team = new Team();
            team.Id = new Guid();
            team.FullName = model.FullName;
            team.ShortName = model.ShortName;
            team.Initials = model.Initials;
            team.CountryId = model.CountryId;

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return Created($"/v1/teams/{team.Id}", team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(Guid id)
        {
            return _context.Teams.Any(t => t.Id == id);
        }
    }
}
