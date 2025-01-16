namespace Application.DTOs;

public class ArtistDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVerified { get; set; }
    public bool Following { get; set; }
}