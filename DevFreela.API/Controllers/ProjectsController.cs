using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        
        [HttpGet("/get")]
        public IActionResult Get(string query)
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel model)
        {
            if(model.Title.Length > 50) 
            {
                return BadRequest(model.Title);
            }
            return CreatedAtAction(nameof(GetById), new { id = model.Id },  model);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] UpdateProjectModel model)
        {
            if (model.Description.Length > 50)
            {
                return BadRequest(model.Description);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] UpdateProjectModel model)
        {
            return NoContent();
        }
    }
}
