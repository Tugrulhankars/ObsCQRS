using Application.Features.Courses.Constants;
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

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IEventStoreService _eventStoreService;
    private readonly IMapper _mapper;
    public UpdateCourseHandler(ICourseRepository courseRepository,IEventStoreService eventStoreService,IMapper mapper)
    {
        _courseRepository = courseRepository;
        _eventStoreService = eventStoreService;
        _mapper = mapper;
    }
    public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(CourseConstant.SetTag,CourseConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(CourseConstant.UpdateCourseHandlerHandle);
        Course course=_mapper.Map<Course>(request);
        _courseRepository.Update(course);
        activity?.AddEvent(new(CourseConstant.UpdatedCourseEvent));
        _eventStoreService.AppendToStreamAsync(CourseConstant.CourseStream, new[] {_eventStoreService.GenerateEventData(course)});
        activity.Stop();
        return new UpdateCourseResponse();
    }
}
