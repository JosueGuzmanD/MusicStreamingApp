
using Core.Entities;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class GenreTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        var genre = new Genre("Rock", "Guitars and drums");

        genre.Name.ShouldBe("Rock");
        genre.Description.ShouldBe("Guitars and drums");
        genre.Songs.ShouldBeEmpty();
        genre.Albums.ShouldBeEmpty();
        genre.Playlists.ShouldBeEmpty();
    }

    [Fact]
    public void AddSong_ShouldAdd_WhenValidSong()
    {
        var genre = new Genre("Rock", "Guitars and drums");
        var song = new Song("Song Title", 3, 15, Guid.NewGuid(), Guid.NewGuid());

        genre.AddSong(song);

        genre.Songs.ShouldContain(song);
    }

    [Fact]
    public void AddSong_ShouldThrow_WhenNull()
    {
        var genre = new Genre("Rock", "Guitars and drums");

        Should.Throw<ArgumentNullException>(() => genre.AddSong(null));
    }
}
