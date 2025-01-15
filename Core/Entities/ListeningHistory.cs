namespace Core.Entities;

public class ListeningHistory : Entity
{
    public ApplicationUser User { get; set; }
    public Song Song { get; set; }
    public DateTime PlayedAt { get; set; }
}