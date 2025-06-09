using publisher_app.Models;
using publisher_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace publisher_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {

        private readonly IPublisherService _disciplineService;
        public DisciplinesController(IPublisherService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        // Get : api/Disciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetDisciplines()
        {
           var discipline= await _disciplineService.GetPublishersAsync();
            return Ok(discipline);
        }

        // Get : api/Disciplines/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetDiscipline(long id)
        {
            var discipline= await _disciplineService.GetPublisherAsync(id);
            return Ok(discipline);
        }

        // Post : api/Disciplines
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostDiscipline(Publisher discipline)
        {
            await _disciplineService.CreatePublisherAsync(discipline);
            return Ok(discipline);
        }

        // Put : api/Disciplines/2
        [HttpPut]
        public async Task<ActionResult<Publisher>> PutDiscipline(long id, Publisher discipline)
        {
            if (id != discipline.Id)
            {
                return BadRequest();
            }
            if(! await _disciplineService.PublisherExistsAsync(id))
            {
                return NotFound();
            }
            await _disciplineService.UpdatePublisherAsync(discipline);
            return NoContent();
        }

        

        // Delete : api/Disciplines/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publisher>> DeleteDiscipline(int id)
        {
            try
            {
                await _disciplineService.DeletePublisherAsync(id);
            }
            catch (ArgumentException ) { return NotFound(); }
            return NoContent() ;

        }
    }
}
