using publisher_app.Models;
using publisher_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace publisher_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PusblisherController : ControllerBase
    {

        private readonly IPublisherService _publisherService;
        public PusblisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // Get : api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
           var discipline= await _publisherService.GetPublishersAsync();
            return Ok(discipline);
        }

        // Get : api/Publishers/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(long id)
        {
            var publisher= await _publisherService.GetPublisherAsync(id);
            return Ok(publisher);
        }

        // Post : api/Publishers
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        {
            await _publisherService.CreatePublisherAsync(publisher);
            return Ok(publisher);
        }

        // Put : api/Publishers/2
        [HttpPut]
        public async Task<ActionResult<Publisher>> PutPusblisher(long id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }
            if(! await _publisherService.PublisherExistsAsync(id))
            {
                return NotFound();
            }
            await _publisherService.UpdatePublisherAsync(publisher);
            return NoContent();
        }



        // Delete : api/Publishers/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publisher>> DeletePublisher(int id)
        {
            try
            {
                await _publisherService.DeletePublisherAsync(id);
            }
            catch (ArgumentException ) { return NotFound(); }
            return NoContent() ;

        }
    }
}
