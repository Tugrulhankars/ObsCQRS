using Application.Tools.Pagination;
using Application.Tools.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentQuery:IRequest<GetListResponse<GetListStudentDto>>
{
    public PageRequest PageRequest { get; set; }
}
