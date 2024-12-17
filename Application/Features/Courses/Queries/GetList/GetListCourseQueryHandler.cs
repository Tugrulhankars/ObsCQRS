using Application.Features.Courses.Constants;
using Application.Services.Repositories;
using Application.Tools.Constants;
using Application.Tools.Pagination;
using Application.Tools.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseQueryHandler : IRequestHandler<GetListCourseQuery, GetListResponse<GetListCourseDto>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    public GetListCourseQueryHandler(ICourseRepository courseRepository,IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    public async Task<GetListResponse<GetListCourseDto>> Handle(GetListCourseQuery request, CancellationToken cancellationToken)
    {
        Activity.Current?.SetTag(CourseConstant.SetTag,CourseConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity();
        Paginate<Course> course = _courseRepository.GetList(
            index:request.PageRequest.PageIndex,
            size:request.PageRequest.PageSize,
            withDeleted:true
            );
        activity?.AddEvent(new());
        GetListResponse<GetListCourseDto> response = _mapper.Map<GetListResponse<GetListCourseDto>>(course);
        activity.Stop();
        return response;
    }
}
