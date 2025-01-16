namespace Core.Entities;

public class Artist : Entity
{
    public string ArtistName { get; set; }
    public string ArtistDescription { get; set; }
    public string ArtistImage { get; set; }
    public bool isVerified { get; set; } 
    public bool Following { get; set; }

    public List<Album> Albums { get; set; }= new();
    public List<ArtistSong> ArtistSongs { get; set; } = new();

    public void IsVerified()
    {
        if (Albums.Count == 0)
            throw new InvalidOperationException("An artist must have at least one album to be verified.");
        isVerified = true;
    }

    public void AddAlbum(Album album)
    {
        if(album is null) throw new ArgumentNullException(nameof(album));
        Albums.Add(album);
    }

    public void AddArtistSong(ArtistSong artistSong)
    {
        if(artistSong is null) throw new ArgumentNullException(nameof(artistSong));
        ArtistSongs.Add(artistSong);
    }
    
}
