using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Events;
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

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorHandler : IRequestHandler<CreateInstructorCommand, CreatedInstructorResponse>
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    private readonly IEventStoreService _eventStoreService;
    public CreateInstructorHandler(IInstructorRepository instructorRepository,IMapper mapper,IEventStoreService eventStoreService)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _eventStoreService = eventStoreService;
    }
    public async Task<CreatedInstructorResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(InstructorConstants.SetTag,InstructorConstants.SetTagValue);
        using var actvity = ActivitySourceProvider.Source.StartActivity(InstructorConstants.CreateInstructorHandlerHandle);
         Instructor instructor=_mapper.Map<Instructor>(request);
         _instructorRepository.Add(instructor);
        actvity?.AddEvent(new(InstructorConstants.InstructorCreatedEvent));
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(request);
        InstructorCreatedEvent instructorCreated=_mapper.Map<InstructorCreatedEvent>(request);
       await _eventStoreService.AppendToStreamAsync(InstructorConstants.InstructorStream, new[] {_eventStoreService.GenerateEventData(instructorCreated)});
        actvity.Stop();
        return response;

    }
}
