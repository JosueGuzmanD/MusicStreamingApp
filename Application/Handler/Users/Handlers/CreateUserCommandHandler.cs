using Application.Users.Commands;
using Core.Entities;
using Core.Interfaces;
using Core.ValueObjects;
using Infrastructure;

namespace Application.Handler.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IRepository<ApplicationUser> _userRepository;

    public CreateUserCommandHandler(IRepository<ApplicationUser> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request)
    {
        var address = request.Address != null
            ? new Address(request.Address.Street, request.Address.City, request.Address.State, request.Address.Country,
                request.Address.PostalCode)
            : null;

        var user = new ApplicationUser
        (request.Name.FirstName,
            request.Name.LastName,
            request.Email,
            request.PhoneNumber,
            address);

          await _userRepository.AddAsync(user);
         
         return Guid.Parse(user.Id);
    }
}