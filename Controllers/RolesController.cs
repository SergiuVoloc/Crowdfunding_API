using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API;
using Crowdfunding_API.DTOs;
using Crowdfunding_API.Entities;

namespace Crowdfunding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public RolesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            return await dbContext.Role.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}", Name = "GetRole")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await dbContext.Role.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult> PostRole([FromBody] RoleCreationDTO roleCreation)
        {
            var role = mapper.Map<Role>(roleCreation);
            dbContext.Add(role);
            await dbContext.SaveChangesAsync();
            var roleDTO = mapper.Map<RoleDTO>(role);

            return new CreatedAtRouteResult("GetRole", new { id = roleDTO.Id }, roleDTO);
        }   




        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(role).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await dbContext.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            dbContext.Role.Remove(role);
            await dbContext.SaveChangesAsync();

            return role;
        }

        private bool RoleExists(int id)
        {
            return dbContext.Role.Any(e => e.Id == id);
        }
    }
}
