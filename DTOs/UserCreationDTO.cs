using Crowdfunding_API.Validations;
using Microsoft.AspNetCore.Http;
using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Crowdfunding_API.DTOs
{
    public class UserCreationDTO : UserPatchDTO
    {
        [FileSizeValidator(10)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Avatar_img { get; set; }
    }
}
