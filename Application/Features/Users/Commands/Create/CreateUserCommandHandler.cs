using Application.Features.Users.Constants;
using Application.Features.Users.Events;
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

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IEventStoreService _eventStoreService;
    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEventStoreService eventStoreService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _eventStoreService = eventStoreService;
    }

    public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Activity.Current.SetTag(UserConstants.SetTag, UserConstants.SetTagValue);
        using var activity = ActivitySourceProvider.Source.StartActivity(UserConstants.CreateUserHandlerHandle);
        User user = _mapper.Map<User>(request);

        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordhash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
            );
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;
        User createdUser = _userRepository.Add(user);
        activity.AddEvent(new(UserConstants.UserCreatedEvent));

        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);
        UserCreatedEvent userCreatedEvent = _mapper.Map<UserCreatedEvent>(createdUser);
        _eventStoreService.AppendToStreamAsync(UserConstants.UserStream, new[] { _eventStoreService.GenerateEventData(userCreatedEvent) });

        activity.Stop();
        return response;
    }
}
