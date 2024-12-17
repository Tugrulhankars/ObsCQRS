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

namespace Application.Features.Students.Commands.Delete;

public class DeletedStudentHandler : IRequestHandler<DeletedStudentCommand, DeletedStudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IEventStoreService _eventStoreService;
    public DeletedStudentHandler(IStudentRepository studentRepository,IMapper mapper,IEventStoreService eventStoreService)
    {
        _eventStoreService = eventStoreService;
        _studentRepository = studentRepository;
        _mapper = mapper;   
    }
    public async Task<DeletedStudentResponse> Handle(DeletedStudentCommand request, CancellationToken cancellationToken)
    {
        Activity.Current?.SetTag(StudentConstants.SetTag,StudentConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity();
         Student student = _studentRepository.GetStudentById(request.StudentId);
        _studentRepository.Delete(student);
        activity.AddEvent(new(StudentConstants.StudentDeletedEvent));
        _eventStoreService.AppendToStreamAsync(StudentConstants.StudentStream, new[] {_eventStoreService.GenerateEventData(request)});
        DeletedStudentResponse response=_mapper.Map<DeletedStudentResponse>(request);
        activity.Stop();
        return response;
      
    }
}
