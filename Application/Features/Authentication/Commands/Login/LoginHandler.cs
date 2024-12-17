using Application.Features.Authentication.Constants;
using Application.Security.Hashing;
using Application.Services.EventStore;
using Application.Services.Repositories;
using Application.Tools.Constants;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public LoginHandler(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(AuthenticationConstant.SetTag,AuthenticationConstant.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(AuthenticationConstant.LoginHandlerHandle);
        User user = _mapper.Map<User>(request);
        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordhash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
            );
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var result =await _userRepository.Login(user.Email,user.PasswordHash,user.PasswordSalt);
        activity.AddEvent(new(AuthenticationConstant.LoginEvent));
        LoginResponse response=new LoginResponse();
        activity.Stop();
        return response;

    }
}
