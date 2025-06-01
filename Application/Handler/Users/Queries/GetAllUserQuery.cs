using Application.DTOs;
using Application.Users.Queries;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Application.Handler.Users.Queries;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IRepository<ApplicationUser> _repository;

    public GetAllUserQueryHandler(IRepository<ApplicationUser> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request)
    {
        var users = await _repository.GetAllAsync();

        return users.Select(u => new UserDto
        {
            Name = u.FullName.FirstName,
            Email = u.Email,
            Surname = u.FullName.LastName
        });
    }
}