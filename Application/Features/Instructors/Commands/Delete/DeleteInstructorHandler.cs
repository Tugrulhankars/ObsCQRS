using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using Application.Tools.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.Delete;

public class DeleteInstructorHandler : IRequestHandler<DeleteInstructorCommand, DeleteInstructorResponse>
{
    private readonly IInstructorRepository _instructorRepository;
    public DeleteInstructorHandler(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }
    public async Task<DeleteInstructorResponse> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(InstructorConstants.SetTag,InstructorConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity();
        Instructor instructor= await _instructorRepository.GetById(request.InstructorId);
         _instructorRepository.Delete(instructor);
        activity.AddEvent(new(InstructorConstants.InstructorDeletedEvent));
        DeleteInstructorResponse deleteInstructorResponse = new DeleteInstructorResponse();
        activity.Stop();
        return deleteInstructorResponse;
    }
}
