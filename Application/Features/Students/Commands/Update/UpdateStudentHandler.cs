using Application.Features.Students.Constants;
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

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IEventStoreService _eventStoreService;
    public UpdateStudentHandler(IStudentRepository studentRepository,IMapper mapper,IEventStoreService eventStoreService)
    {
        _eventStoreService = eventStoreService;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(StudentConstants.SetTag,StudentConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity();
        Student student=_mapper.Map<Student>(request);
        _studentRepository.Update(student);
        activity?.AddEvent(new());
        _eventStoreService.AppendToStreamAsync(StudentConstants.StudentStream, new[] {_eventStoreService.GenerateEventData(request)});
        UpdateStudentResponse response=_mapper.Map<UpdateStudentResponse>(request);
        activity.Stop();
        return response;
    }
}
