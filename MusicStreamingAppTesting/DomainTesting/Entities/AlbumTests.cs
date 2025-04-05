
using Core.Entities;
using Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class AlbumTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly_WhenValidDataIsProvided()
    {
        var artistId = Guid.NewGuid();
        var title = "Test Album";
        var imageUrl = "cover.jpg";

        var album = new Album(artistId, title, imageUrl);

        album.ArtistId.ShouldBe(artistId);
        album.Title.ShouldBe(title);
        album.ImageUrl.ShouldBe(imageUrl);
        album.Songs.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_ShouldThrowException_IfArtistIsEmpty()
    {
        var exception = Should.Throw<ArgumentException>(() => new Album(Guid.Empty, "Test Title"));
        exception.Message.ShouldContain("ArtistId cannot be empty.");
    }

    [Fact]
    public void Constructor_ShouldThrowException_IfTitleIsEmpty()
    {
        var exception = Should.Throw<ArgumentException>(() => new Album(Guid.NewGuid(), ""));
        exception.Message.ShouldContain("Title cannot be empty.");
    }

    [Fact]
    public void AddSong_ShouldAddSong_WhenValidSong()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");
        var song = new Song("Test Song", 3, 45, Guid.NewGuid(), Guid.NewGuid());

        album.AddSong(song);

        album.Songs.ShouldContain(song);
    }

    [Fact]
    public void AddSong_ShouldThrowException_WhenNull()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");

        var exception = Should.Throw<ArgumentNullException>(() => album.AddSong(null));
        exception.Message.ShouldContain("Song cannot be null.");
    }

    [Fact]
    public void RemoveSong_ShouldRemoveSong_WhenExists()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");
        var song = new Song("Song 1", 3, 30, Guid.NewGuid(), Guid.NewGuid());
        album.AddSong(song);

        album.RemoveSong(song);

        album.Songs.ShouldNotContain(song);
    }

    [Fact]
    public void RemoveSong_ShouldThrowException_WhenNull()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");

        var exception = Should.Throw<ArgumentNullException>(() => album.RemoveSong(null));
        exception.Message.ShouldContain("Song cannot be null.");
    }

    [Fact]
    public void UpdateImageUrl_ShouldUpdate_WhenValidUrl()
    {
        var album = new Album(Guid.NewGuid(), "Album Title", "old.jpg");
        album.UpdateImageUrl("new.jpg");

        album.ImageUrl.ShouldBe("new.jpg");
    }

    [Fact]
    public void UpdateImageUrl_ShouldThrowException_WhenEmpty()
    {
        var album = new Album(Guid.NewGuid(), "Album Title", "old.jpg");

        var exception = Should.Throw<ArgumentException>(() => album.UpdateImageUrl(""));
        exception.Message.ShouldContain("Image URL cannot be empty.");
    }

    [Fact]
    public void GetAlbumDuration_ShouldReturnCorrectDuration()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");
        album.AddSong(new Song("One", 3, 45, Guid.NewGuid(), Guid.NewGuid()));
        album.AddSong(new Song("Two", 2, 30, Guid.NewGuid(), Guid.NewGuid()));

        var duration = album.GetAlbumDuration();

        duration.Minutes.ShouldBe(6);
        duration.Seconds.ShouldBe(15);
    }

    [Fact]
    public void GetAlbumDuration_ShouldReturnZero_WhenNoSongs()
    {
        var album = new Album(Guid.NewGuid(), "Album Title");

        var duration = album.GetAlbumDuration();

        duration.Minutes.ShouldBe(0);
        duration.Seconds.ShouldBe(0);
    }
}
