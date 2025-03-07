using Core.ValueObjects;

namespace Core.Entities;

public class Album : Entity
{
    public Guid ArtistId { get; private set; }
    public string Title { get; private set; }
    public string? ImageUrl { get; private set; }
    public List<Song> Songs { get; private set; } 
    
    public Album(Guid artistId, string title, string? imageUrl = null)
    {
        if (artistId == Guid.Empty)
            throw new ArgumentException("ArtistId cannot be empty.", nameof(artistId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        ArtistId = artistId;
        Title = title;
        ImageUrl = imageUrl;
        Songs = new List<Song>();
    }
    
    public void AddSong(Song song)
    {
        if (song == null)
            throw new ArgumentNullException(nameof(song), "Song cannot be null.");

        Songs.Add(song);
    }
    public void UpdateImageUrl(string newImageUrl)
    {
        if (string.IsNullOrWhiteSpace(newImageUrl))
            throw new ArgumentException("Image URL cannot be empty.", nameof(newImageUrl));

        ImageUrl = newImageUrl;
    }
    public Duration GetAlbumDuration()
    {
        return CalculateDuration();
    }

    private Duration CalculateDuration()
    {
        var totalMinutes = Songs.Sum(s => s.Duration.Minutes);
        var totalSeconds = Songs.Sum(s => s.Duration.Seconds);

        totalMinutes += totalSeconds / 60;
        totalSeconds %= 60;

        return new Duration(totalMinutes, totalSeconds);
    }

}