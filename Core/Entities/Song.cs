using Core.Interfaces;
using Core.ValueObjects;

namespace Core.Entities;

public class Song : Entity
{
    public string Title { get; set; }
    public Duration Duration { get; set; }
    public string ImageUrl { get; set; }
    public bool Explicit { get; set; }
    public double Streams { get; set; }
    public Guid AlbumId { get; set; }
    public List<Artist> Artists { get; set; }
}