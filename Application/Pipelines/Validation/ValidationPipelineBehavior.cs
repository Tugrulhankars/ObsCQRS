using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines.Validation;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v=>v.ValidateAsync(context,cancellationToken)));

        var failures=validationResults
            .SelectMany(result=>result.Errors)
            .Where(f=>f !=null)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next();
    }
}
