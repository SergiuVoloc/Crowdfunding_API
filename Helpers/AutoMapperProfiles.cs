﻿using AutoMapper;
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

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserCreationDTO, User>()
                    .ForMember(x => x.Avatar_img, options => options.Ignore())
                    .ForMember(x => x.FavoriteProjects, options => options.MapFrom(MapFavoriteProjects));

            CreateMap<User, UserPatchDTO>().ReverseMap();


            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<ProjectCreationDTO, Project>();

            CreateMap<Project, ProjectPatchDTO>().ReverseMap();


            CreateMap<Payment, PaymentDTO>().ReverseMap();

            CreateMap<PaymentCreationDTO, Payment>();


            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<RoleCreationDTO, Role>();

        }

        private List<FavoriteProjects> MapFavoriteProjects(UserCreationDTO userCreationDTO, User user)
        {
            var result = new List<FavoriteProjects>();
            foreach (var id in userCreationDTO.FavoriteProjectIds)
            {
                result.Add(new FavoriteProjects() { ProjectId = id });
            }
            return result;
        }
    }
}
