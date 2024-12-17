using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommand:IRequest<UpdateStudentResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string StudentNumber { get; set; }
    public string StudentPhoneNumber { get; set; }
    public string StudentCity { get; set; }
    public string StudentAddress { get; set; }
    public int StudentAge { get; set; }
}
