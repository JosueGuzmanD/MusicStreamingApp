
using Core.Entities;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class ArtistTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly_WhenValidData()
    {
        var artist = new Artist("My Artist", "img.jpg", false);

        artist.ArtistName.ShouldBe("My Artist");
        artist.ArtistImage.ShouldBe("img.jpg");
        artist.IsVerified.ShouldBeFalse();
        artist.Albums.ShouldBeEmpty();
        artist.Songs.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenArtistNameIsNull()
    {
        Should.Throw<ArgumentNullException>(() => new Artist(null, "img.jpg", false))
            .Message.ShouldContain("artistName");
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenArtistImageIsNull()
    {
        Should.Throw<ArgumentNullException>(() => new Artist("My Artist", null, false))
            .Message.ShouldContain("artistImage");
    }

    [Fact]
    public void VerifyArtist_ShouldThrow_WhenAlreadyVerified()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        var album = new Album(Guid.NewGuid(), "Album");
        artist.AddAlbum(album);
        artist.VerifyArtist();

        Should.Throw<InvalidOperationException>(() => artist.VerifyArtist())
            .Message.ShouldBe("Artist is already verified.");
    }

    [Fact]
    public void VerifyArtist_ShouldThrow_WhenNoAlbums()
    {
        var artist = new Artist("Artist", "img.jpg", false);

        Should.Throw<InvalidOperationException>(() => artist.VerifyArtist())
            .Message.ShouldBe("An artist must have at least one album to be verified.");
    }

    [Fact]
    public void VerifyArtist_ShouldSetIsVerifiedTrue_WhenAlbumsExist()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        artist.AddAlbum(new Album(Guid.NewGuid(), "Album"));

        artist.VerifyArtist();

        artist.IsVerified.ShouldBeTrue();
    }

    [Fact]
    public void AddAlbum_ShouldAdd_WhenValidAlbum()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        var album = new Album(Guid.NewGuid(), "Album");

        artist.AddAlbum(album);

        artist.Albums.ShouldContain(album);
    }

    [Fact]
    public void AddAlbum_ShouldThrow_WhenNull()
    {
        var artist = new Artist("Artist", "img.jpg", false);

        Should.Throw<ArgumentNullException>(() => artist.AddAlbum(null))
            .Message.ShouldContain("album");
    }

    [Fact]
    public void AddSong_ShouldAdd_WhenValidSong()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        var song = new Song("S", 3, 10, Guid.NewGuid(), Guid.NewGuid());

        artist.AddSong(song);

        artist.Songs.ShouldContain(song);
    }

    [Fact]
    public void AddSong_ShouldThrow_WhenNull()
    {
        var artist = new Artist("Artist", "img.jpg", false);

        Should.Throw<ArgumentNullException>(() => artist.AddSong(null))
            .Message.ShouldContain("song");
    }

    [Fact]
    public void ChangeImage_ShouldUpdate_WhenValid()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        artist.ChangeImage("new.jpg");

        artist.ArtistImage.ShouldBe("new.jpg");
    }

    [Fact]
    public void ChangeImage_ShouldThrow_WhenNull()
    {
        var artist = new Artist("Artist", "img.jpg", false);

        Should.Throw<ArgumentNullException>(() => artist.ChangeImage(null))
            .Message.ShouldContain("image");
    }

    [Fact]
    public void ChangeName_ShouldUpdate_WhenValid()
    {
        var artist = new Artist("Artist", "img.jpg", false);
        artist.ChangeName("Updated");

        artist.ArtistName.ShouldBe("Updated");
    }

    [Fact]
    public void ChangeName_ShouldThrow_WhenNull()
    {
        var artist = new Artist("Artist", "img.jpg", false);

        Should.Throw<ArgumentNullException>(() => artist.ChangeName(null))
            .Message.ShouldContain("name");
    }
}
