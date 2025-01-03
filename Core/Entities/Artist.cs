using Core.Interfaces;

namespace Core.Entities;

public class Artist : Entity
{
    public string ArtistName { get; set; }
    public string ArtistDescription { get; set; }
    public string ArtistImage { get; set; }
    public bool isVerified { get; set; }
    public bool Following { get; set; }

    public List<Album> Albums { get; set; }
    public List<Song> Songs { get; set; }
}
