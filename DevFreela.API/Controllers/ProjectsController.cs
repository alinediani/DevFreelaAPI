using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService) 
        {
            _projectService = projectService;
        }
        
        [HttpGet("/get")]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _projectService.GetById(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel model)
        {
            if(model.Title.Length > 50) 
            {
                return BadRequest(model.Title);
            }
            var id = _projectService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = id },  model);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] UpdateProjectInputModel model)
        {
            if (model.Description.Length > 50)
            {
                return BadRequest(model.Description);
            }
            _projectService.Update(model);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] UpdateProjectModel model)
        {
            _projectService.Delete(id);
            return NoContent();
        }
        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel createComment)
        {
            _projectService.CreateComment(createComment);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }
}
