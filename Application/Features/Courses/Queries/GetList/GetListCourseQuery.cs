using Application.Tools.Pagination;
using Application.Tools.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseQuery:IRequest<GetListResponse<GetListCourseDto>>
{
    public PageRequest  PageRequest { get; set; }
}
