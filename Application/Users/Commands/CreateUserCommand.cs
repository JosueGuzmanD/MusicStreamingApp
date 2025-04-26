using Application.DTOs;
using Infrastructure;

namespace Application.Users.Commands;

public class CreateUserCommand : IRequest<Guid>
{
    public NameDto Name { get; }
    public AddressDto? Address { get; }
    public DateTime? BirthDate { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
}