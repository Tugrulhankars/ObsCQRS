using Application.Features.Courses.Constants;
using Application.Features.Courses.Events;
using Application.Features.Users.Events;
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

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CreatedCourseResponse>
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly IEventStoreService _eventStoreService;
    public CreateCourseHandler(IMapper mapper,ICourseRepository courseRepository,IEventStoreService eventStoreService)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _eventStoreService = eventStoreService;
    }
    public async Task<CreatedCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(CourseConstant.SetTag,CourseConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(CourseConstant.CreateCourseHandlerStartActivity);


        Course course = _mapper.Map<Course>(request);
         _courseRepository.Add(course);

        activity?.AddEvent(new(CourseConstant.CreatedNewCourse));

        CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(request);
        CourseCreatedEvent courseCreatedEvent = _mapper.Map<CourseCreatedEvent>(createdCourseResponse);
        _eventStoreService.AppendToStreamAsync(CourseConstant.CourseStream, new[] {_eventStoreService.GenerateEventData(courseCreatedEvent)});
        activity.Stop();
        return createdCourseResponse;

    }
}
