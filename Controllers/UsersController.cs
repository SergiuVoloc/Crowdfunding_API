using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API;
using Crowdfunding_API.Entities;
using Crowdfunding_API.DTOs;
using AutoMapper;
using Crowdfunding_API.Services;
using System.IO;

namespace Crowdfunding_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "users";

        public UsersController(ApplicationDBContext context, 
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }



        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUser()
        {
            var users = await context.User.ToListAsync();
            return mapper.Map<List<UserDTO>>(users);
        }



        // GET: api/Users/5
        [HttpGet("{id}", Name = "getUsers")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var users = await context.User.FirstOrDefaultAsync(x => x.ID == id);

            if (users == null)
            {
                return NotFound();
            }

            return mapper.Map<UserDTO>(users);
        }



        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UserCreationDTO userCreationDTO)
        {
            var userDB = await context.User.FirstOrDefaultAsync(x => x.ID == id);

            if (userDB == null) { return NotFound(); }

            userDB = mapper.Map(userCreationDTO, userDB);

            if (userCreationDTO.Avatar_img != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await userCreationDTO.Avatar_img.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(userCreationDTO.Avatar_img.FileName);
                    userDB.Avatar_img = await fileStorageService.EditFile(content, extension, containerName,
                        userDB.Avatar_img, userCreationDTO.Avatar_img.ContentType);
                }
            }
            await context.SaveChangesAsync();
            return NoContent();
        }




        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> PostUser([FromForm] UserCreationDTO userCreation)
        {
            var user = mapper.Map<User>(userCreation);

            if (userCreation.Avatar_img != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await userCreation.Avatar_img.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(userCreation.Avatar_img.FileName);
                    user.Avatar_img = await fileStorageService.SaveFile(content, extension, containerName, userCreation.Avatar_img.ContentType);
                }

            }

            context.Add(user);
            await context.SaveChangesAsync();
            var userDTO = mapper.Map<UserDTO>(user);
            return new CreatedAtRouteResult("getUsers", new { id = userDTO.ID }, userDTO);


        }




        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.User.AnyAsync(x => x.ID == id);
            if (!exists)
            {
                return NotFound();
            }

            context.Remove(new User() { ID = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
 }

