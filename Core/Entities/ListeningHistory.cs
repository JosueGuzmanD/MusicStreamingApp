namespace Core.Entities;

public class ListeningHistory : Entity
{
    public ApplicationUser User { get; }
    public Song Song { get; }
    public DateTime PlayedAt { get;  }

    public ListeningHistory(ApplicationUser user, Song song, DateTime playedAt)
    {
        User = user;
        Song = song;
        PlayedAt = playedAt;
    }
}