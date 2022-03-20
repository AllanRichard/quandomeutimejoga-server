using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quandomeutimejoga_server.Data;
using quandomeutimejoga_server.Models;
using quandomeutimejoga_server.Models.Views;

namespace quandomeutimejoga_server.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetListCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries is not null ? Ok(countries) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            return country is not null ? Ok(country) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, CountryView model)
        {
            var validations = model.Validations();
            if (validations.Count > 0)
                return BadRequest(validations);

            var updateCountry = await _context.Countries.FindAsync(id);
            if (updateCountry == null)
            {
                return NotFound();
            }

            updateCountry.Name = model.Name;
            updateCountry.CountryCode = model.CountryCode;
            updateCountry.Continent = (Models.Enums.Continent)model.Continent;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CountryExists(id))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CountryView model)
        {
            var validations = model.Validations();
            if (validations.Count > 0)
                return BadRequest(validations);

            var country = new Country();
            country.Id = new Guid();
            country.Name = model.Name;
            country.CountryCode = model.CountryCode;
            country.Continent = (Models.Enums.Continent)model.Continent;

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return Created($"/v1/countries/{country.Id}", country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCountry(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(Guid id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }
    }
}
