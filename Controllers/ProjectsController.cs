using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Crowdfunding_API.DTOs;

namespace Crowdfunding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ILogger<ProjectsController> logger;
        private readonly IMapper mapper;

        public ProjectsController(ApplicationDBContext context, ILogger<ProjectsController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        // api/Projects
        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> GetProject()
        {
            var projects = await context.Project.AsNoTracking().ToListAsync();
            var projectsDTOs = mapper.Map<List<ProjectDTO>>(projects);
            return projectsDTOs;

        }

        // GET: api/Projects/{id}
        [HttpGet("{id}", Name = "GetProject")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await context.Project.FirstOrDefaultAsync(x => x.ID == id);

            if (project == null)
            {
                logger.LogWarning($" Project with id {id} not found");
                return NotFound();
                throw new ApplicationException();
            }

            var projectDTO = mapper.Map<ProjectDTO>(project);

            return projectDTO;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Post([FromBody]ProjectCreationDTO projectCreation)
        {
            var project = mapper.Map<Project>(projectCreation);
            context.Add(project); 
            await context.SaveChangesAsync();
            var projectDTO = mapper.Map<ProjectDTO>(project);

            return new CreatedAtRouteResult("GetProject", new { projectDTO.ID }, projectDTO); 
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
           
            context.Project.Add(project);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ID }, project);
           

        }

        // DELETE: api/Projects/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            context.Project.Remove(project);
            await context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return context.Project.Any(e => e.ID == id);
        }
    }
}
