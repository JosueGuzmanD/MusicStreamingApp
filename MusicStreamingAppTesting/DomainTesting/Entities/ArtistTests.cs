using Core.Entities;
using Shouldly;

namespace MusicStreamingAppTesting;

public class ArtistTests
{
    [Fact]
    public void Constructor_ShouldInitializeArtistCorrectly_WhenValidDataIsProvided()
    {
        var artistName = "Test Artist";
        var artistImage = "image_url";

        var artist = new Artist(artistName, artistImage, false);

        artist.ArtistName.ShouldBe(artistName);
        artist.ArtistImage.ShouldBe(artistImage);
        artist.IsVerified.ShouldBeFalse();
        artist.Albums.ShouldBeEmpty();
        artist.Songs.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenArtistNameIsNull()
    {
        Should.Throw<ArgumentException>(() => new Artist(null, "image_url", false))
            .Message.ShouldContain("Value cannot be null.");
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenArtistImageIsNull()
    {
        Should.Throw<ArgumentException>(() => new Artist("Test Artist", null, false))
            .Message.ShouldContain("Value cannot be null.");
    }

    [Fact]
    public void VerifyArtist_ShouldThrowInvalidOperationException_WhenNoAlbums()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        Should.Throw<InvalidOperationException>(() => artist.VerifyArtist())
            .Message.ShouldBe("An artist must have at least one album to be verified.");
    }

    [Fact]
    public void VerifyArtist_ShouldSetIsVerifiedToTrue_WhenArtistHasAlbums()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var album = new Album(Guid.NewGuid(), "Test Album");

        artist.AddAlbum(album);

        artist.VerifyArtist();

        artist.IsVerified.ShouldBeTrue();
    }

    [Fact]
    public void AddAlbum_ShouldAddAlbum_WhenValidAlbumIsProvided()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var album = new Album(Guid.NewGuid(), "Test Album");

        artist.AddAlbum(album);

        artist.Albums.Count.ShouldBe(1);
        artist.Albums.ShouldContain(album);
    }

    [Fact]
    public void AddAlbum_ShouldThrowArgumentNullException_WhenAlbumIsNull()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        var exception = Should.Throw<ArgumentNullException>(() => artist.AddAlbum(null));
        exception.ParamName.ShouldBe("album");
    }

    [Fact]
    public void AddArtistSong_ShouldAddArtistSong_WhenValidArtistSongIsProvided()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var song = new ArtistSong();

        artist.AddArtistSong(song);

        artist.Songs.Count.ShouldBe(1);
        artist.Songs.ShouldContain(song);
    }

    [Fact]
    public void AddArtistSong_ShouldThrowArgumentNullException_WhenArtistSongIsNull()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        var exception = Should.Throw<ArgumentNullException>(() => artist.AddArtistSong(null));
        exception.ParamName.ShouldBe("artistSong");
    }

    [Fact]
    public void FollowArtist_ShouldSetFollowingToTrue_WhenArtistIsFollowed()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var followedArtist = new Artist("Followed Artist", "image_url", false);

        artist.FollowArtist(followedArtist);

        artist.Following.ShouldBeTrue();
    }

    [Fact]
    public void FollowArtist_ShouldThrowArgumentNullException_WhenArtistIsNull()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        var exception = Should.Throw<ArgumentNullException>(() => artist.FollowArtist(null));
        exception.ParamName.ShouldBe("artist");
    }

    [Fact]
    public void ChangeImage_ShouldUpdateArtistImage_WhenValidImageIsProvided()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var newImage = "new_image_url";

        artist.ChangeImage(newImage);

        artist.ArtistImage.ShouldBe(newImage);
    }

    [Fact]
    public void ChangeImage_ShouldThrowArgumentException_WhenImageIsNull()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        Should.Throw<ArgumentException>(() => artist.ChangeImage(null))
            .Message.ShouldContain("Value cannot be null.");
    }

    [Fact]
    public void ChangeName_ShouldUpdateArtistName_WhenValidNameIsProvided()
    {
        var artist = new Artist("Test Artist", "image_url", false);
        var newName = "Updated Artist";

        artist.ChangeName(newName);

        artist.ArtistName.ShouldBe(newName);
    }

    [Fact]
    public void ChangeName_ShouldThrowArgumentException_WhenNameIsNull()
    {
        var artist = new Artist("Test Artist", "image_url", false);

        Should.Throw<ArgumentException>(() => artist.ChangeName(null))
            .Message.ShouldContain("Value cannot be null.");
    }
}
