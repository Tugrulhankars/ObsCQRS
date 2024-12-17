using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.Delete;

public class DeletedStudentCommand:IRequest<DeletedStudentResponse>
{
    public int StudentId { get; set; }
}
