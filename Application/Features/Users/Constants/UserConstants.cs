using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Constants;

public static class UserConstants
{
    public static string SetTag = "Asp.Net Core(instrumentation) tag1";
    public static string SetTagValue = "Asp.Net Core(instrumentation) tag value";

    public static string UserStream = "student-stream";

    public static string CreateUserHandlerHandle = "CreateUserHandler.Handle";
    public static string UserCreatedEvent = "New User Created ";

    public static string DeleteUserHandlerHandle = "DeleteUserHandler.Handle";
    public static string UserDeletedEvent = "User is Deleted";

    public static string UpdateUserHandlerHandle = "UpdateUserHandler.Handle";
    public static string UserUpdatedEvents = "User is Updated";
}
