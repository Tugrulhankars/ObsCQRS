using Application.Features.Courses.Constants;
using Application.Services.EventStore;
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

namespace Application.Features.Courses.Commands.Delete;

public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IEventStoreService _eventStoreService;
    public DeleteCourseHandler(ICourseRepository courseRepository,IEventStoreService eventStoreService)
    {
        _courseRepository = courseRepository;
        _eventStoreService = eventStoreService;
    }
    public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(CourseConstant.SetTag,CourseConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(CourseConstant.DeleteCourseHandlerHandle);
        Course course=await _courseRepository.GetById(request.CourseId);
        _courseRepository.Delete(course);
        activity?.AddEvent(new(CourseConstant.CourseDeletedEvent));
        _eventStoreService.AppendToStreamAsync(CourseConstant.CourseStream, new[] {_eventStoreService.GenerateEventData(course)});
        DeleteCourseResponse deleteCourseResponse = new DeleteCourseResponse();
        return deleteCourseResponse;
    }
}
