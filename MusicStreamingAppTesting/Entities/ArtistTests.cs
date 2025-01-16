using Core.Entities;
using Core.ValueObjects;
using Shouldly;

namespace MusicStreamingAppTesting;

public class ArtistTests
{
    [Fact]
    public void IsVerified_ShouldVerifyArtist()
    {
        var artist = new Artist()
        {
            ArtistName = "Artist Name",
            isVerified = false,
            Albums = new List<Album>()
            {
                new Album()
                {
                    Duration = new Duration(3, 0),
                }
            }
        };

        artist.IsVerified();
        Assert.True(artist.ArtistName == "Artist Name");
        Assert.True(artist.isVerified);
    }

    [Fact]
    public void IsVerified_ThrowsInvalidOperationException_WhenNoAlbums()
    {
        var artist = new Artist()
        {
            isVerified = false
        };

        var exception = Should.Throw<InvalidOperationException>(() => artist.IsVerified());
        exception.Message.ShouldBe("An artist must have at least one album to be verified.");
    }

    [Fact]
    public void AddAlbum_ShouldAddAlbum()
    {
        var album = new Album()
        {
            Title = "Album1"
        };

        var artist = new Artist();
        artist.AddAlbum(album);

        artist.Albums.Count.ShouldBe(1);
    }

    [Fact]
    public void AddAlbum_ThrowsArgumentNullException_WhenAlbumIsNull()
    {
        var artist = new Artist();

        var exception = Should.Throw<ArgumentNullException>(() => artist.AddAlbum(null));
        artist.Albums.Count.ShouldBe(0);
    }

    [Fact]
    public void AddArtistSong_ShouldAddArtistSong()
    {
        var artist = new Artist();
        var song = new ArtistSong();
        
        artist.AddArtistSong(song);
        
        artist.ArtistSongs.Count.ShouldBe(1);
    }

    [Fact]
    public void AddArtistSong_ThrowsArgumentNullException_WhenArtistSongIsNull()
    {
        var artist = new Artist();
        
        var exception= Should.Throw<ArgumentNullException>(() => artist.AddArtistSong(null));
    }
}