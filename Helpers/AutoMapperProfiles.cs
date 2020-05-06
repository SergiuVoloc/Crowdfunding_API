using AutoMapper;
using Crowdfunding_API.DTOs;
using Crowdfunding_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<ProjectCreationDTO, Project>();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserCreationDTO, User>()
                .ForMember(x => x.Avatar_img, options => options.Ignore());
        }
    }
}
