﻿//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Crowdfunding_API.DTOs;
//using Crowdfunding_API.Entities;
//using Crowdfunding_API.Helpers;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;

//namespace Crowdfunding_API.Controllers
//{
//    [Route("api/[accounts]")]
//    [ApiController]
//    public class AccountsController : ControllerBase
//    {
//        private readonly UserManager<IdentityUser> userManager;
//        private readonly SignInManager<IdentityUser> signInManager;
//        private readonly IConfiguration configuration;
//        private readonly ApplicationDbContext context;
//        private readonly IMapper mapper;

//        public AccountsController(UserManager<IdentityUser> userManager,
//            SignInManager<IdentityUser> signInManager,
//            IConfiguration configuration,
//            ApplicationDbContext context,
//            IMapper mapper)
//        {
//            this.userManager = userManager;
//            this.signInManager = signInManager;
//            this.configuration = configuration;
//            this.context = context;
//            this.mapper = mapper;
//        }

      
//        [HttpPost("Create")]
//        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
//        {
//            var user = new IdentityUser { UserName = model.EmailAddress, Email = model.EmailAddress };
//            var result = await userManager.CreateAsync(user, model.Password);

//            if (result.Succeeded)
//            {
//                return  BuildToken(model);
//            }
//            else
//            {
//                return BadRequest(result.Errors);
//            }
//        }

//        private UserToken BuildToken(UserInfo userInfo)
//        {
//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.Name, userInfo.EmailAddress),
//                new Claim(ClaimTypes.Email, userInfo.EmailAddress),
//                new Claim("mykey", "whatever value I want")
//            };
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
//            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

//            var expiration = DateTime.UtcNow.AddYears(1);

//            JwtSecurityToken token = new JwtSecurityToken(
//                issuer: null,
//                audience: null,
//                claims: claims,
//                expires: expiration,
//                signingCredentials: creds);

//            return new UserToken()
//            {
//                Token = new JwtSecurityTokenHandler().WriteToken(token),
//                Expiration = expiration
//            };
//        }


//        [HttpPost("Login")]
//        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo model)
//        {
//            var result = await signInManager.PasswordSignInAsync(model.EmailAddress,
//                model.Password, isPersistent: false, lockoutOnFailure: false);

//            if (result.Succeeded)
//            {
//                return  BuildToken(model);
//            }
//            else
//            {
//                return BadRequest("Invalid login attempt");
//            }
//        }

//        //[HttpPost("RenewToken")]
//        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//        //public async Task<ActionResult<UserToken>> Renew()
//        //{
//        //    var userInfo = new UserInfo
//        //    {
//        //        EmailAddress = HttpContext.User.Identity.Name
//        //    };

//        //    return await BuildToken(userInfo);
//        //}

//        //private async Task<UserToken> BuildToken(UserInfo userInfo)
//        //{
//        //    var claims = new List<Claim>()
//        //    {
//        //        new Claim(ClaimTypes.Name, userInfo.EmailAddress),
//        //        new Claim(ClaimTypes.Email, userInfo.EmailAddress),
//        //        new Claim("mykey", "whatever value I want")
//        //    };

//        //    var identityUser = await userManager.FindByEmailAsync(userInfo.EmailAddress);
//        //    var claimsDB = await userManager.GetClaimsAsync(identityUser);

//        //    claims.AddRange(claimsDB);

//        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
//        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        //    var expiration = DateTime.UtcNow.AddYears(1);

//        //    JwtSecurityToken token = new JwtSecurityToken(
//        //        issuer: null,
//        //        audience: null,
//        //        claims: claims,
//        //        expires: expiration,
//        //        signingCredentials: creds);

//        //    return new UserToken()
//        //    {
//        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
//        //        Expiration = expiration
//        //    };

//        //}





//        //[HttpGet("Users")]
//        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
//        //public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
//        //{
//        //    var queryable = context.Users.AsQueryable();
//        //    queryable = queryable.OrderBy(x => x.Email);
//        //    await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
//        //    var users = await queryable.Paginate(paginationDTO).ToListAsync();
//        //    return mapper.Map<List<UserDTO>>(users);
//        //}

//        //[HttpGet("Roles")]
//        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
//        //public async Task<ActionResult<List<string>>> GetRoles()
//        //{
//        //    return await context.Roles.Select(x => x.Name).ToListAsync();
//        //}

//        //[HttpPost("AssignRole")]
//        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
//        //public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
//        //{
//        //    var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
//        //    if (user == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
//        //    return NoContent();
//        //}

//        //[HttpPost("RemoveRole")]
//        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
//        //public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
//        //{
//        //    var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
//        //    if (user == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
//        //    return NoContent();
//        //}
//    }
//}
