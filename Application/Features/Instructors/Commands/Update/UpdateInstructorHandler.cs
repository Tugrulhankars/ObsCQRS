using Application.Features.Instructors.Constants;
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

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorHandler : IRequestHandler<UpdateInstructorCommand, UpdateInstructorResponse>
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    public UpdateInstructorHandler(IInstructorRepository instructorRepository,IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;   
    }
    public async Task<UpdateInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(InstructorConstants.SetTag,InstructorConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(InstructorConstants.UpdateInstructorHandlerHandle);
        Instructor instructor =_mapper.Map<Instructor>(request);
        _instructorRepository.Update(instructor);
        activity.AddEvent(new(InstructorConstants.InstructorUpdatedEvents));
        
        UpdateInstructorResponse response=_mapper.Map<UpdateInstructorResponse>(request);

        return response;
       
        
    }
}
