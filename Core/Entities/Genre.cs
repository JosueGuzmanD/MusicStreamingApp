namespace Core.Entities;

public class Genre : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public List<Song> Songs { get; private set; } = new List<Song>();
    public List<Album> Albums { get; private set; } = new List<Album>();
    public List<Playlist> Playlists { get; private set; } = new List<Playlist>();

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddSong(Song song)
    {
        ArgumentNullException.ThrowIfNull(song);
        Songs.Add(song);
    }
}