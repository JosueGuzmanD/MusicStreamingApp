namespace Core.Entities;

public class Artist : Entity
{
    public string ArtistName { get; private set; }
    public string? ArtistDescription { get; private set; }
    public string ArtistImage { get; private set; }
    public bool IsVerified { get; private set; }
    public bool Following { get; private set; }

    public List<Album> Albums { get; private set; } = new();
    public List<Song> Songs { get; private set; } = new();
    

    public Artist(string artistName, string artistImage, bool isVerified)
    {
        ArtistName = EnsureNotNull(artistName, nameof(artistName));
        ArtistImage = EnsureNotNull(artistImage, nameof(artistImage));
        if (isVerified)
        {
            VerifyArtist();
        }
    }

    public void VerifyArtist()
    {
        if (IsVerified)
            throw new InvalidOperationException("Artist is already verified.");

        if (!Albums.Any())
            throw new InvalidOperationException("An artist must have at least one album to be verified.");

        IsVerified = true;
    }

    public void AddAlbum(Album album)
    {
        Albums.Add(EnsureNotNull(album, nameof(album)));
    }

    public void AddSong(Song song)
    {
        Songs.Add(EnsureNotNull(song, nameof(song)));
    }

    public void FollowArtist(Artist artist)
    {
        EnsureNotNull(artist, nameof(artist));
        Following = true;
    }

    public void ChangeImage(string image)
    {
        ArtistImage = EnsureNotNull(image, nameof(image));
    }

    public void ChangeName(string name)
    {
        ArtistName = EnsureNotNull(name, nameof(name));
    }
}