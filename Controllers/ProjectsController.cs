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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Crowdfunding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ILogger<ProjectsController> logger;
        private readonly IMapper mapper;
        /*
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "projects"; // for Azure data storing
        */

        public ProjectsController(ApplicationDBContext context, 
            ILogger<ProjectsController> logger, 
            IMapper mapper)
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
        public async Task<ActionResult> Post(int id, [FromBody]ProjectCreationDTO projectCreation)
        {
            var project = mapper.Map<Project>(projectCreation);
            project.ID = id;
            context.Entry(project).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult> PostProject([FromBody] ProjectCreationDTO projectCreation)
        {
            var project = mapper.Map<Project>(projectCreation);
            context.Add(project);
            await context.SaveChangesAsync();
            var projectDTO = mapper.Map<ProjectDTO>(project);

            return new CreatedAtRouteResult("GetProject", new { id = projectDTO.ID }, projectDTO);
           

        }

        // DELETE: api/Projects/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var exists = await context.Project.AnyAsync(x => x.ID == id);
            if (!exists == null)
            {
                return NotFound();
            }

            context.Remove(new Project() { ID = id});
            await context.SaveChangesAsync();

            return NoContent();

        }

        private bool ProjectExists(int id)
        {
            return context.Project.Any(e => e.ID == id);
        }
    }
}
