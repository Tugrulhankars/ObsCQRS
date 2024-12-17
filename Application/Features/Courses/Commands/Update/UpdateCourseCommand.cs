using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommand:IRequest<UpdateCourseResponse>
{
    public string CourseName { get; set; }
    public long CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
    public int InstructorsId { get; set; }
}
