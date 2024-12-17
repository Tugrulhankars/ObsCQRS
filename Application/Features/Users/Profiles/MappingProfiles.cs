using Application.Features.Users.Commands.Create;
using Application.Features.Users.Events;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();

        CreateMap<UserCreatedEvent, User>().ReverseMap()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

    }
}
