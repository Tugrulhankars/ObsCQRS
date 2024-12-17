using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Events;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, CreateStudentCommand>().ReverseMap();
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();

        CreateMap<CreateStudentCommand,StudentCreatedEvent>().ReverseMap();
        CreateMap<CreatedStudentResponse, StudentCreatedEvent>();

        CreateMap<DeletedStudentCommand,DeletedStudentCommand>().ReverseMap();

        CreateMap<Student,UpdateStudentCommand>().ReverseMap();
        CreateMap<UpdateStudentResponse,UpdateStudentCommand>();
    }
}
