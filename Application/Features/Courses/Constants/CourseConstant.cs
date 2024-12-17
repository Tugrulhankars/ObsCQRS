using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Constants;

public static class CourseConstant
{
    public static string SetTag = "Asp.Net Core(instrumentation) tag1";
    public static string SetTagValue = "Asp.Net Core(instrumentation) tag value";

    public static string AssignInstructorToCourseAddEvent = "Assign New Instructor to Course";
    public static string AssignInstructorToCourseHandlerHandle = "AssignInstructorToCourseHandler.Handle";


    public const string CreateCourseHandlerStartActivity = "CreateCourseHandler.Handle";
    public static string CreatedNewCourse = "Created New Course";
    public static string CourseStream = "course-stream";

    public static string DeleteCourseHandlerHandle = "DeleteCourseHandler.Handle";
    public static string CourseDeletedEvent = "Course Deleted Course id :";

    public static string UpdateCourseHandlerHandle = "UpdateCourseHandler.Handle";
    public static string UpdatedCourseEvent = "Course Updated ";


}
