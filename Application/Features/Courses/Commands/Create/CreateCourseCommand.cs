using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommand:IRequest<CreatedCourseResponse>
{
   

    public string CourseName { get; set; }
    public long CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
    public int InstructorsId { get; set; }
    // public List<Instructor> Instructors { get; set; }
    public CreateCourseCommand()
    {
    }

    public CreateCourseCommand(string courseName, long courseCode, string courseDescription, int courseCredit, int ınstructorsId)
    {
        CourseName = courseName;
        CourseCode = courseCode;
        CourseDescription = courseDescription;
        CourseCredit = courseCredit;
        InstructorsId = ınstructorsId;
    }
}
