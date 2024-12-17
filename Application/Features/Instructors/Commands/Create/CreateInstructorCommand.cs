using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommand:IRequest<CreatedInstructorResponse>
{
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorMailAddress { get; set; }
    public string InstructorPhoneNumber { get; set; }
    public string InstructorAddress { get; set; }
}
