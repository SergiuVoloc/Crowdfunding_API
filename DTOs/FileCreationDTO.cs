using Crowdfunding_API.Validations;
using Microsoft.AspNetCore.Http;
using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class FileCreationDTO
    {
        [FileSizeValidator(50)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Value { get; set; } 
    }
}
