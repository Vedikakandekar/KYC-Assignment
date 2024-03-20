using Microsoft.AspNetCore.Mvc;

namespace AssignmentForKYC360.Controllers
{
    [Route("kyc/entities")]
    [ApiController]
    public class EntitiesController(MockedDatabase db) : ControllerBase
    {
        private readonly MockedDatabase _db = db;

        [HttpGet]
        public IActionResult GetAllEntities()
        {
            var entities = _db.GetAllEntities();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public IActionResult GetEntityById(string id)
        {
            var entity = _db.GetEntityById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("search")]
        public IActionResult SearchEntities([FromQuery] string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            var filteredEntities = _db.GetAllEntities()
                .Where(e =>
                    e.Names.Any(n => n.FirstName.ToLower().Contains(searchTerm) || n.Surname.ToLower().Contains(searchTerm) || n.MiddleName.ToLower().Contains(searchTerm)) ||
                    e.Addresses.Any(a => a.AddressLine.ToLower().Contains(searchTerm) || a.Country.ToLower().Contains(searchTerm))
                );
            return Ok(filteredEntities);
        }

        [HttpGet("filter")]
        public IActionResult FilterEntities([FromQuery] string gender, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] string country)
        {
            gender = gender.ToLower();
            country = country.ToLower();
            var filteredEntities = _db.GetAllEntities()
       .Where(e =>
           (string.IsNullOrEmpty(gender) || e.Gender.ToLower() == gender) &&
           (string.IsNullOrEmpty(country) || e.Addresses.Any(a => a.Country.ToLower() == country)) &&
           (!startDate.HasValue || e.Dates.Any(d => d.DateValue >= startDate)) &&
           (!endDate.HasValue || e.Dates.Any(d => d.DateValue <= endDate))
       );
            return Ok(filteredEntities);
        }

    }
}
