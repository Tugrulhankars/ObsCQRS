using Application.Features.Authentication.Commands.Login;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Profiles;

public class AuthenticationMapping:Profile
{
    public AuthenticationMapping()
    {
        CreateMap<User,LoginCommand>().ReverseMap();
        CreateMap<User,LoginResponse>().ReverseMap();
      
        CreateMap<LoginCommand,LoginResponse>().ReverseMap();
    }
}
