using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Constants;

public static class InstructorConstants
{
    public static string SetTag = "Asp.Net Core(instrumentation) tag1";
    public static string SetTagValue = "Asp.Net Core(instrumentation) tag value";

    public static string InstructorStream = "instructor-stream";

    public static string CreateInstructorHandlerHandle = "CreateInstructorHandler.Handle";
    public static string InstructorCreatedEvent = "New Instructor Created ";

    public static string DeleteInstructorHandlerHandle = "DeleteInstructorHandler.Handle";
    public static string InstructorDeletedEvent = "Instructor is Deleted";

    public static string UpdateInstructorHandlerHandle = "UpdateInstructorHandler.Handle";
    public static string InstructorUpdatedEvents = "Instructor is Updated";
}
