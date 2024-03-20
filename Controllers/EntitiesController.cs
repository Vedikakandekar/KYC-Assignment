using AssignmentForKYC360.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentForKYC360.Controllers
{
    [Route("kyc/entities")]
    [ApiController]
    public class EntitiesController(MockedDatabase db) : ControllerBase
    {
        private readonly MockedDatabase _db = db;

        //Endpoint TO get ALL Entities
        [HttpGet("getAll")]
        public IActionResult GetAllEntities()
        {
            var entities = _db.GetAllEntities();
            return Ok(entities);
        }


        //Endpoint TO get Entity by ID
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

        //Endpoint TO create new Entity

        [HttpPost("create")]
        public IActionResult CreateEntity([FromBody] Entity et)
        {


            _db.AddEntity(et);

            return Ok(GetEntityById(et.Id));
        }


         //Endpoint TO search  Entities by address or Name

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


        //Endpoint TO filter  Entities on the basis of gender , country & dates
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
