using Core.Entities;
using Core.ValueObjects;
using Shouldly;

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
    public void Constructor_ShouldThrowException_IfArtistIsNull()
    {
        var emptyArtistId = Guid.Empty;
        var title = "Test Album";

        var exception = Should.Throw<ArgumentException>(() => new Album(emptyArtistId, title));

        exception.Message.ShouldContain("ArtistId cannot be empty.");
    }

    [Fact]
    public void Constructor_ShouldThrowException_IfTitleIsNull()
    {
        var artistId = Guid.NewGuid();
        var title = string.Empty;

        var exception = Should.Throw<ArgumentException>(() => new Album(artistId, title));
        exception.Message.ShouldContain("Title cannot be empty.");
    }

    [Fact]
    public void AddSong_ShouldAddSong_IfIsCorrect()
    {
        var song = new Song();
        var album = new Album(Guid.NewGuid(), "AlbumTitle");

        album.AddSong(song);

        album.Songs.ShouldContain(song);
        album.Songs.Count.ShouldBe(1);
    }

    [Fact]
    public void AddSong_ShouldThrowException_IfSongIsNull()
    {
        var album = new Album(Guid.NewGuid(), "AlbumTitle");
        var exception = Should.Throw<ArgumentNullException>(() => album.AddSong(null));

        exception.Message.ShouldContain("Song cannot be null.");
        album.Songs.Count.ShouldBe(0);
    }

    [Fact]
    public void GetAlbumDuration_ShouldReturnZero_WhenNoSongsAreAdded()
    {
        var album = new Album(Guid.NewGuid(), "Test Album");

        var duration = album.GetAlbumDuration();

        duration.Minutes.ShouldBe(0);
        duration.Seconds.ShouldBe(0);
    }
    [Fact]
    public void UpdateImageUrl_ShouldUpdateImageUrl_WhenValidUrlIsProvided()
    {
        var album = new Album(Guid.NewGuid(), "Test Album");
        var newImageUrl = "new-cover.jpg";

        album.UpdateImageUrl(newImageUrl);

        
        album.ImageUrl.ShouldBe(newImageUrl);
    }

    [Fact]
    public void UpdateImageUrl_ShouldThrowArgumentException_WhenImageUrlIsEmpty()
    {
        var album = new Album(Guid.NewGuid(), "Test Album");

        Should.Throw<ArgumentException>(() => album.UpdateImageUrl(""))
            .Message.ShouldContain("Image URL cannot be empty.");
    }
    [Fact]
    public void GetAlbumDuration_ShouldReturnCorrectDuration_WhenSongsAreAdded()
    {
        var album = new Album(Guid.NewGuid(), "Test Album");
        album.AddSong(new Song { Duration = new Duration(3, 45) }); 
        album.AddSong(new Song { Duration = new Duration(4, 30) }); 

        var duration = album.GetAlbumDuration();

        duration.Minutes.ShouldBe(8); 
        duration.Seconds.ShouldBe(15); 
    }
    
    
}