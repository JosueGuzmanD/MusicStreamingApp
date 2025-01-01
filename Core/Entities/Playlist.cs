using Core.Enums;
using Core.Interfaces;
using Core.ValueObjects;

namespace Core.Entities;

public class Playlist : Entity
{
    public string Name { get; set; }
    public List<Song> Songs { get; set; }
    public string ImageUrl { get; set; }
    public Duration Duration { get; set; }
    public ApplicationUser Author { get; set; }
    public string Description { get; set; }
    public PlaylistState State { get; set; }
}