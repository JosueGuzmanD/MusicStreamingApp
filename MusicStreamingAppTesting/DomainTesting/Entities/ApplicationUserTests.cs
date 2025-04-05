
using Core.Entities;
using Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class ApplicationUserTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        var address = new Address("Calle", "Ciudad", "Estado", "Pais", "12345");
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", address);

        user.FullName.FirstName.ShouldBe("Jane");
        user.FullName.LastName.ShouldBe("Doe");
        user.Email.ShouldBe("jane@example.com");
        user.PhoneNumber.ShouldBe("123456789");
        user.UserName.ShouldBe("jane@example.com");
        user.NormalizedEmail.ShouldBe("JANE@EXAMPLE.COM");
        user.Address.ShouldBe(address);
        user.Albums.ShouldBeEmpty();
        user.FavouriteSongs.ShouldBeEmpty();
        user.FollowedArtists.ShouldBeEmpty();
    }

    [Fact]
    public void SetBirthDate_ShouldAssign_WhenValidDate()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);
        var date = new DateTime(1990, 1, 1);

        user.SetBirthDate(date);

        user.BirthDate.ShouldBe(date);
    }

    [Fact]
    public void SetBirthDate_ShouldThrow_WhenDateInFuture()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);

        var futureDate = DateTime.UtcNow.AddDays(1);

        Should.Throw<ArgumentException>(() => user.SetBirthDate(futureDate))
            .Message.ShouldContain("BirthDate cannot be in the future.");
    }

    [Fact]
    public void AddAddress_ShouldAssignAddress()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);
        var address = new Address("Street", "City", "State", "Country", "00000");

        user.AddAddress(address);

        user.Address.ShouldBe(address);
    }

    [Fact]
    public void AddAddress_ShouldThrow_WhenAddressIsNull()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);

        Should.Throw<ArgumentNullException>(() => user.AddAddress(null))
            .Message.ShouldContain("address");
    }

    [Fact]
    public void FollowArtist_ShouldAdd_WhenValidArtist()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);
        var artist = new Artist("Artist", "image.jpg", false);

        user.FollowArtist(artist);

        user.FollowedArtists.ShouldContain(artist);
    }

    [Fact]
    public void FollowArtist_ShouldThrow_WhenArtistIsNull()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);

        Should.Throw<ArgumentNullException>(() => user.FollowArtist(null))
            .Message.ShouldContain("artist");
    }

    [Fact]
    public void FollowArtist_ShouldThrow_WhenArtistAlreadyFollowed()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);
        var artist = new Artist("Artist", "image.jpg", false);

        user.FollowArtist(artist);

        Should.Throw<InvalidOperationException>(() => user.FollowArtist(artist))
            .Message.ShouldBe("Already following this artist.");
    }

    [Fact]
    public void ClearDomainEvents_ShouldRemoveAllEvents()
    {
        var user = new ApplicationUser("Jane", "Doe", "jane@example.com", "123456789", null);

        user.DomainEvents.ShouldBeEmpty();
        user.ClearDomainEvents(); // Should not throw
        user.DomainEvents.ShouldBeEmpty();
    }
}
