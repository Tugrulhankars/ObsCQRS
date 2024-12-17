using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator:AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(s => s.FirstName).NotEmpty();
        RuleFor(s=>s.LastName).NotEmpty();
        RuleFor(s => s.EmailAddress).EmailAddress();
    }
}
