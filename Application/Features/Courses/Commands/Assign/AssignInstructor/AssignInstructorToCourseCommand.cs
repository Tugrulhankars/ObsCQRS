using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Assign.AssignInstructor;

public class AssignInstructorToCourseCommand:IRequest<AssignInstructorToCourseResponse>
{
    public int CourseCode { get; set; }
    public int InstructorId { get; set; }
}
