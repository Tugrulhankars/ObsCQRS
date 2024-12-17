using Application.Security.Constants;
using Application.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? userRoleCliams = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoleCliams==null)
        {
            Console.WriteLine("");
        }

        bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleCliams
            .FirstOrDefault(
            userRoleCliams => userRoleCliams == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleCliams)
            ).IsNullOrEmpty();
        if (isNotMatchedAUserRoleClaimWithRequestRoles)
            Console.WriteLine("");

        TResponse response = await next();
        return response;

    }
}
