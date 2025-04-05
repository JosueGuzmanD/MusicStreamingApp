using Core.Enums;
using Core.ValueObjects;

namespace Core.Entities;

public class Playlist : Entity
{
    public string Name { get; private set; }
    public List<Song> Songs { get; private set; } = new();
    public string? ImageUrl { get; private set; }
    public Duration Duration => CalculateDuration();
        

    public ApplicationUser Author { get; set; }
    public string Description { get; set; }
    public PlaylistState State { get; private set; }


    public Playlist(ApplicationUser author,string name, PlaylistState state, string? imageUrl = null)
    {
        Author = author;
        Name = name;
        State = state;
        ImageUrl = imageUrl;
    }

    public void AddSong(Song song)
    {
        if (Songs.Contains(song))
        { throw new InvalidOperationException("Song already added!"); }
        ArgumentNullException.ThrowIfNull(song);
        Songs.Add(song);
    }

    public void ChangeDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(nameof(description));
        }
        Description = description;
    }

    public void ChangeState(PlaylistState newState)
    {
        if (State == newState)
        {
            throw new Exception("Playlist state is the same as the current state");
        }
        State = newState;
    }

    public void ChangeImageUrl(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new ArgumentNullException(nameof(imageUrl));
        }
        ImageUrl = imageUrl;
    }
    private Duration CalculateDuration()
    {
        var minutes = Songs.Sum(s => s.Duration.Minutes);
        var seconds = Songs.Sum(s => s.Duration.Seconds);
        
        return new Duration(minutes,seconds);
    }
    
}