using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Events;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCourseCommand, CreatedCourseResponse>().ReverseMap();
        CreateMap<CreateCourseCommand,Course>().ReverseMap();

        CreateMap<CourseCreatedEvent,CreateCourseCommand>().ReverseMap();
        CreateMap<CourseCreatedEvent,CreatedCourseResponse>().ReverseMap();

        CreateMap<Course,UpdateCourseCommand>().ReverseMap();
    }
}
