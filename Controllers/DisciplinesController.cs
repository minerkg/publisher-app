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

        private readonly IDisciplineService _disciplineService;
        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        // Get : api/Disciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetDisciplines()
        {
           var discipline= await _disciplineService.GetDisciplinesAsync();
            return Ok(discipline);
        }

        // Get : api/Disciplines/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetDiscipline(long id)
        {
            var discipline= await _disciplineService.GetDisciplineAsync(id);
            return Ok(discipline);
        }

        // Post : api/Disciplines
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostDiscipline(Publisher discipline)
        {
            await _disciplineService.CreateDisciplineAsync(discipline);
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
            if(! await _disciplineService.DisciplineExistsAsync(id))
            {
                return NotFound();
            }
            await _disciplineService.UpdateDisciplineAsync(discipline);
            return NoContent();
        }

        

        // Delete : api/Disciplines/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publisher>> DeleteDiscipline(int id)
        {
            try
            {
                await _disciplineService.DeleteDisciplineAsync(id);
            }
            catch (ArgumentException ) { return NotFound(); }
            return NoContent() ;

        }
    }
}
