using Application.Features.Courses.Commands.Update;
using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Events;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInstructorCommand,CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor,CreatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor,CreateInstructorCommand>().ReverseMap();
        CreateMap<CreatedInstructorResponse, CreateInstructorCommand>().ReverseMap();
        CreateMap<InstructorCreatedEvent, CreateInstructorCommand>().ReverseMap();

        CreateMap<UpdateInstructorCommand, UpdateInstructorResponse>().ReverseMap();
        CreateMap<UpdateInstructorCommand,Instructor>().ReverseMap();
    }
}
