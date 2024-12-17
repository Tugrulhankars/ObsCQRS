using Application.Features.Courses.Constants;
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

namespace Application.Features.Courses.Commands.Assign.AssignInstructor;

public class AssignInstructorToCourseHandler : IRequestHandler<AssignInstructorToCourseCommand, AssignInstructorToCourseResponse>
{
    private readonly ICourseRepository _courseRepository;
    public AssignInstructorToCourseHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public async Task<AssignInstructorToCourseResponse> Handle(AssignInstructorToCourseCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(CourseConstant.SetTag,CourseConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(CourseConstant.AssignInstructorToCourseHandlerHandle);


        Course course = await _courseRepository.AssignInstructorToCourse(request.CourseCode,request.InstructorId);
        activity?.AddEvent(new(CourseConstant.AssignInstructorToCourseAddEvent));
        AssignInstructorToCourseResponse response = new AssignInstructorToCourseResponse();
        activity.Stop();
        return response;
    }
}
