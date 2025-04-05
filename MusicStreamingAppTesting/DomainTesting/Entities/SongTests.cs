
using Core.Entities;
using Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class SongTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        var albumId = Guid.NewGuid();
        var artistId = Guid.NewGuid();
        var song = new Song("Title", 3, 30, albumId, artistId);

        song.Title.ShouldBe("Title");
        song.Duration.Minutes.ShouldBe(3);
        song.Duration.Seconds.ShouldBe(30);
        song.AlbumId.ShouldBe(albumId);
        song.MainArtistId.ShouldBe(artistId);
        song.Explicit.ShouldBeFalse();
        song.Streams.ShouldBe(0);
        song.Artists.ShouldBeEmpty();
    }

    [Fact]
    public void MarkAsExplicit_ShouldSetExplicitToTrue()
    {
        var song = new Song("Title", 3, 30, Guid.NewGuid(), Guid.NewGuid());
        song.MarkAsExplicit();
        song.Explicit.ShouldBeTrue();
    }

    [Fact]
    public void AddStreams_ShouldIncreaseStreams()
    {
        var song = new Song("Title", 3, 30, Guid.NewGuid(), Guid.NewGuid());
        song.AddStreams();
        song.Streams.ShouldBe(1);

        song.AddStreams(4);
        song.Streams.ShouldBe(5);
    }
}
