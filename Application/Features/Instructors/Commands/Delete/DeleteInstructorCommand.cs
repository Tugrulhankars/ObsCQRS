using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.Delete;

public class DeleteInstructorCommand:IRequest<DeleteInstructorResponse>
{
    public int InstructorId { get; set; }
}
