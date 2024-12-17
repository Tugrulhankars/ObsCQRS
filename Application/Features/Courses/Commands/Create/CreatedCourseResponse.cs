using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse
{
    public string CourseName { get; set; }
    public long CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
}
