using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class ApplicationUser : IdentityUser, IHasDomainEvents
{
    public Name FullName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Address? Address { get; private set; }

    public List<Album> Albums { get; } = new();
    public List<Song> FavouriteSongs { get; } = new();
    public List<Artist> FollowedArtists { get; } = new();

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    public ApplicationUser(string firstName, string lastName, string email, string phoneNumber, Address? address = null)
    {
        FullName = new Name(firstName, lastName);
        Email = email;
        UserName = email;
        NormalizedEmail = email.ToUpperInvariant();
        NormalizedUserName = email.ToUpperInvariant();
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public void SetBirthDate(DateTime birthDate)
    {
        if (birthDate > DateTime.UtcNow)
            throw new ArgumentException("BirthDate cannot be in the future.", nameof(birthDate));

        BirthDate = birthDate;
    }

    public void AddAddress(Address address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void FollowArtist(Artist artist)
    {
        if (artist == null)
            throw new ArgumentNullException(nameof(artist));

        if (FollowedArtists.Contains(artist))
            throw new InvalidOperationException("Already following this artist.");

        FollowedArtists.Add(artist);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}