
using Core.Entities;
using Core.Enums;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class PlaylistTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        var user = new ApplicationUser("John", "Doe", "john@example.com", "123456789");
        var playlist = new Playlist(user, "My Playlist", PlaylistState.Private, "cover.jpg");

        playlist.Author.ShouldBe(user);
        playlist.Name.ShouldBe("My Playlist");
        playlist.State.ShouldBe(PlaylistState.Private);
        playlist.ImageUrl.ShouldBe("cover.jpg");
        playlist.Songs.ShouldBeEmpty();
    }

    [Fact]
    public void AddSong_ShouldAddSong_WhenNotExists()
    {
        var user = new ApplicationUser("John", "Doe", "john@example.com", "123456789");
        var playlist = new Playlist(user, "My Playlist", PlaylistState.Private);
        var song = new Song("Title", 2, 15, Guid.NewGuid(), Guid.NewGuid());

        playlist.AddSong(song);

        playlist.Songs.ShouldContain(song);
    }

    [Fact]
    public void AddSong_ShouldThrow_WhenSongExists()
    {
        var user = new ApplicationUser("John", "Doe", "john@example.com", "123456789");
        var song = new Song("Title", 2, 15, Guid.NewGuid(), Guid.NewGuid());
        var playlist = new Playlist(user, "My Playlist", PlaylistState.Private);
        playlist.AddSong(song);

        Should.Throw<InvalidOperationException>(() => playlist.AddSong(song))
            .Message.ShouldBe("Song already added!");
    }

    [Fact]
    public void ChangeDescription_ShouldUpdate_WhenValid()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);
        playlist.ChangeDescription("New Desc");

        playlist.Description.ShouldBe("New Desc");
    }

    [Fact]
    public void ChangeDescription_ShouldThrow_WhenNullOrEmpty()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);

        Should.Throw<ArgumentNullException>(() => playlist.ChangeDescription(""));
    }

    [Fact]
    public void ChangeImageUrl_ShouldUpdate_WhenValid()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);
        playlist.ChangeImageUrl("cover.jpg");

        playlist.ImageUrl.ShouldBe("cover.jpg");
    }

    [Fact]
    public void ChangeImageUrl_ShouldThrow_WhenInvalid()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);

        Should.Throw<ArgumentNullException>(() => playlist.ChangeImageUrl(""));
    }

    [Fact]
    public void ChangeState_ShouldChange_WhenDifferent()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);
        playlist.ChangeState(PlaylistState.Public);

        playlist.State.ShouldBe(PlaylistState.Public);
    }

    [Fact]
    public void ChangeState_ShouldThrow_WhenSame()
    {
        var playlist = new Playlist(new ApplicationUser("John", "Doe", "john@example.com", "123456789"), "Test", PlaylistState.Private);

        Should.Throw<Exception>(() => playlist.ChangeState(PlaylistState.Private))
            .Message.ShouldBe("Playlist state is the same as the current state");
    }
}
