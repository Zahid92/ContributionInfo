using ContributionInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContributionInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private ProjectContext _dbContext;
        public ProjectsController(ProjectContext projectContext)
        {
                _dbContext = projectContext;
        }
        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            if (_dbContext.Projects == null)
            {
                return NotFound();
            }
            return await _dbContext.Projects.ToListAsync();
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            if (_dbContext.Projects == null)
            {
                return NotFound();
            }
            var project = await _dbContext.Projects.FindAsync(id);
            if(project == null)
            {
                return NotFound();
            }
            return project;
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            _dbContext.Projects.Add(project);   
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = project.Id}, project);
        }
    }
}
