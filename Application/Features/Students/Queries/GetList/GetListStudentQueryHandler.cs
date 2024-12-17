using Application.Services.Repositories;
using Application.Tools.Pagination;
using Application.Tools.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, GetListResponse<GetListStudentDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    public GetListStudentQueryHandler(IStudentRepository studentRepository,IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task<GetListResponse<GetListStudentDto>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
    {
        Paginate<Student> student = _studentRepository.GetList(
            index:request.PageRequest.PageIndex,
            size:request.PageRequest.PageSize,
            withDeleted:true              
            );
        GetListResponse<GetListStudentDto> response = _mapper.Map<GetListResponse<GetListStudentDto>>(student);
        return response;
    }
}
