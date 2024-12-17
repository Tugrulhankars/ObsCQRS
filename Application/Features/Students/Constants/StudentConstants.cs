using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Constants;

public static class StudentConstants
{
    public static string SetTag = "Asp.Net Core(instrumentation) tag1";
    public static string SetTagValue = "Asp.Net Core(instrumentation) tag value";

    public static string StudentStream = "student-stream";

    public static string CreateStudentHandlerHandle = "CreateStudentHandler.Handle";
    public static string StudentCreatedEvent = "New Student Created ";

    public static string DeleteStudentHandlerHandle = "DeleteStudentHandler.Handle";
    public static string StudentDeletedEvent = "Student is Deleted";

    public static string UpdateStudentHandlerHandle = "UpdateStudentHandler.Handle";
    public static string StudentUpdatedEvents = "Student is Updated";
}
