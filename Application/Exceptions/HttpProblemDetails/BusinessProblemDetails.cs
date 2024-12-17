using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.HttpProblemDetails;

//3
public class BusinessProblemDetails:ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Role Violation";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https//example.com/probs/business";
    }
}
