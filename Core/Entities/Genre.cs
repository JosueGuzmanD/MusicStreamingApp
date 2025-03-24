namespace Core.Entities;

public class Genre : Entity
{
    public string Name { get; internal set; }
    public string Description { get; internal set; }

    public List<Song> Songs { get; set; }
    public List<Album> Albums { get; set; }
    public List<Playlist> Playlists { get; set; }
}