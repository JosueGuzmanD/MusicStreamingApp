using Core.ValueObjects;

namespace Core.Entities;

public class Song : Entity
{
    public string Title { get; set; }
    public Duration Duration { get; set; }
    public string? ImageUrl { get; set; }
    public bool Explicit { get; private set; }
    public int Streams { get; private set; }
    public Guid AlbumId { get; init; }
    public Guid MainArtistId { get; private set; }
    public List<Artist> Artists { get; init; }

    public Song(string title, int minutes,int seconds, Guid albumId, Guid mainArtistId, List<Artist>? artists = null ,string? imageUrl = null)
    {
        Title = title;
        Duration = new Duration(minutes, seconds);
        AlbumId = albumId;
        MainArtistId = mainArtistId;
        Artists = artists != null ? new List<Artist>(artists) : new List<Artist>();
        ImageUrl = imageUrl;
    }

    public void MarkAsExplicit()
    {
        Explicit = true;
    }

    public void AddStreams(int amount = 1)
    {
        Streams += amount;
    }
    
}