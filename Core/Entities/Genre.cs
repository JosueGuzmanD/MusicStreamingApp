using Core.Interfaces;

namespace Core.Entities;

public class Genre : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Song> Songs { get; set; }
    public List<Album> Albums { get; set; }
    public List<Playlist> Playlists { get; set; }
}