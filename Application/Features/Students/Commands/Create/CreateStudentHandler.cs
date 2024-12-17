using Application.Features.Students.Constants;
using Application.Features.Students.Events;
using Application.Services.EventStore;
using Application.Services.Repositories;
using Application.Tools.Constants;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IEventStoreService _eventStoreService;
    public CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper,IEventStoreService eventStoreService)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _eventStoreService = eventStoreService;
    }
    public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(StudentConstants.SetTag,StudentConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(StudentConstants.CreateStudentHandlerHandle);

        Student student = _mapper.Map<Student>(request);
        _studentRepository.Add(student);
        activity?.AddEvent(new(StudentConstants.StudentCreatedEvent));
        CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(student);
        StudentCreatedEvent studentCreated = _mapper.Map<StudentCreatedEvent>(createdStudentResponse);
        _eventStoreService.AppendToStreamAsync(StudentConstants.StudentStream, new[] {_eventStoreService.GenerateEventData(studentCreated)} );
        activity.Stop();
        return createdStudentResponse;
    }
}
