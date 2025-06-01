namespace Application.DTOs;

public class UserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Email { get; set; }
}

public class CreateUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}