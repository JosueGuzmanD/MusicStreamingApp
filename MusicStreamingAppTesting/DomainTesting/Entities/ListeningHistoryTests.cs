
using Core.Entities;
using Shouldly;
using Xunit;
using System;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class ListeningHistoryTests
{
    [Fact]
    public void ListeningHistory_Properties_ShouldBeSetCorrectly()
    {
        var user = new ApplicationUser("John", "Doe", "john@example.com", "123456789");
        var song = new Song("Title", 3, 30, Guid.NewGuid(), Guid.NewGuid());
        var history = new ListeningHistory(user, song, DateTime.UtcNow);

        history.User.ShouldBe(user);
        history.Song.ShouldBe(song);
        history.PlayedAt.ShouldBeLessThanOrEqualTo(DateTime.UtcNow);
    }
}
